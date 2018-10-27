$(document).ready(function () {
    var current_progress = 0;
    $("#btnYoutubeSearch").click(function () {
        clearResultData();
        updateProgress(20, "Get video information from Youtube site");
        var youtubeUrl = $("input[name='youtubeUrl']").val();
        $.ajax({
            url: ParseUrlUrl,
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                youtubeUrl: youtubeUrl,
            }),
            success: function (data) {
                if (data.status == false)
                    return errorProgress(0, data.message);
                $("#divVideoResult").html(data.partialViewData.content);
                download(youtubeUrl);
            },
            error: function (xhr) {
            }
        });
    });

    function download(youtubeUrl) {
        updateProgress(20, "Download full audio file");
        $.ajax({
            url: DownloadAudioFileUrl,
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                youtubeUrl: youtubeUrl,
            }),
            success: function (data) {
                debugger;
                console.log(data);
                $("#divDownloadFile").html(data.partialViewData.content);
                splitAudioFile(data.audioFileViewModel);
            },
            error: function (xhr) {
            }
        });
    }


    function splitAudioFile(audioFileViewModel) {
        updateProgress(20, "Split downloaded full audio file");
        debugger;

        $.ajax({
            url: SplitAudioFileUrl,
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(audioFileViewModel) ,
            success: function (data) {
                debugger;
                if (data.status == false)
                    return errorProgress(0, data.message);
                console.log(data);
                $("#divSplitAudioFile").html(data.partialViewData.content);
                recognizeAudioFile(data.audioFileViewModel);
            },
            error: function (xhr) {
            }
        });
    }

    function recognizeAudioFile(audioFileViewModel) {
        updateProgress(20, "Recognize Splited audio file");
        $.ajax({
            url: RecognizeAudioFileUrl,
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(audioFileViewModel),
            success: function (data) {
                if (data.status == false) {
                    $("#divRecognizeAudioFile").html(data.partialViewData.content);
                    return errorProgress(0, data.message + " " + data.partialViewData.content);
                }
                searchArtistData(data.artistViewModel);
            },
            error: function (xhr) {
            }
        });
    }

    function searchArtistData(artistViewModel) {
        updateProgress(10, "Search on Youtube for artist '" + artistViewModel.artist + "'");
        $.ajax({
            url: SerachYoutubeUrl,
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(artistViewModel),
            success: function (data) {
                if (data.status == false)
                    return errorProgress(0, data.message);
                console.log(data);
                $("#divSearchResult").html(data.partialViewData.content);
                updateProgress(10, "Complete");
            },
            error: function (xhr) {
                errorProgress(0, xhr);
            }
        });
    }

    function updateProgress(precentage, message) {
        current_progress += precentage;
        $("#dynamic")
            .css("width", current_progress + "%")
            .attr("aria-valuenow", current_progress)
            .text(current_progress + "% " + message);
        if (current_progress >= 100) {
            $("#dynamic").addClass("progress-bar-success");
            current_progress = 0;
        }
    }

    function errorProgress(precentage, message) {
        current_progress = 100;
        $("#dynamic")
            .css("width", current_progress + "%")
            .attr("aria-valuenow", current_progress)
            .text(current_progress + "% ERROR : " + message);
        $("#dynamic").addClass("progress-bar-danger");
    }

    function clearResultData() {
        $("#divSearchResult").html("");
        $("#divRecognizeAudioFile").html("");
        $("#divSplitAudioFile").html("");
        $("#divDownloadFile").html("");
        $("#divVideoResult").html("");
        $("#dynamic").removeClass("progress-bar-success");
        $("#dynamic").removeClass("progress-bar-danger");
        current_progress = 0;
        //test
    }

});
