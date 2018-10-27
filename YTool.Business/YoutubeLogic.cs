using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YTool.Business.ViewModels;
using YoutubeExplode.Models.MediaStreams;
using System.IO;
using System.Reflection;
namespace YTool.Business
{
    public class YoutubeLogic
    {
        private string baseDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        string CutInterval = System.Configuration.ConfigurationManager.AppSettings["CutInterval"] ?? "20";
        public async Task<VideoViewModel> GetVideoInfoByUrl(string url)
        {
            var id = YoutubeClient.ParseVideoId(url);
            return await GetVideoInfoByVideoId(id);
        }

        public async Task<VideoViewModel> GetVideoInfoByVideoId(string videoId)
        {
            VideoViewModel currentViewModel = new ViewModels.VideoViewModel();
            var client = new YoutubeClient();
            var video = await client.GetVideoAsync(videoId);

            currentViewModel.Author = video.Author;
            currentViewModel.Description = video.Description;
            currentViewModel.Duration = video.Duration;
            currentViewModel.Id = video.Id;
            currentViewModel.Keywords = video.Keywords;
            currentViewModel.Title = video.Title;
            currentViewModel.UploadDate = video.UploadDate;

            return currentViewModel;
        }


        public async Task<VideoFileViewModel> DownloadVideoByUrl(string url)
        {
            var id = YoutubeClient.ParseVideoId(url);
            return await DownloadVideo(id);
        }

        public async Task<VideoFileViewModel> DownloadVideo(string videoId)
        {
            var client = new YoutubeClient();
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            var ext = streamInfo.Container.GetFileExtension();
            await client.DownloadMediaStreamAsync(streamInfo, "downloaded_video_" + videoId + "." + ext);

            return new VideoFileViewModel();
        }

        public async Task<AudioFileViewModel> DownloadAudioByUrl(string url)
        {
            var id = YoutubeClient.ParseVideoId(url);
            return await DownloadAudioFile(id);
        }

        public async Task<AudioFileViewModel> DownloadAudioFile(string videoId)
        {
            var client = new YoutubeClient();
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
            var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
            var ext = streamInfo.Container.GetFileExtension();
            await client.DownloadMediaStreamAsync(streamInfo, baseDir + "\\wwwroot\\Downloads\\Audio\\file_" + videoId + "." + ext);

            return new AudioFileViewModel()
            {
                ext = ext,
                fileName = "file_" + videoId + "." + ext,
                filePath = baseDir + "\\wwwroot\\Downloads\\Audio\\file_" + videoId + "." + ext
            };


        }

        public AudioFileViewModel SplitAudioFile(AudioFileViewModel audioFileViewModel)
        {
            AudioLogic audioLogic = new AudioLogic();
            string newSplitedFileName = audioFileViewModel.fileName.Replace("." + audioFileViewModel.ext, "_20sec.mp3");
            string newSplitedFilePath = audioFileViewModel.filePath.Replace("." + audioFileViewModel.ext, "_20sec.mp3");
            int cutAudioInterval = int.Parse(CutInterval);
            audioLogic.TrimWavFile(audioFileViewModel.filePath, audioFileViewModel.ext,
                newSplitedFilePath, "mp3", 0, cutAudioInterval);
            return new AudioFileViewModel()
            {
                ext = "mp3",
                fileName = newSplitedFileName,
                filePath = newSplitedFilePath
            };
        }

        public async Task<ArtistViewModel> RecognizeAudioFile(AudioFileViewModel audioFileViewModel)
        {
            RecognizeLogic recognizeLogic = new RecognizeLogic();
            ArtistViewModel artistViewModel = recognizeLogic.GetArtist(audioFileViewModel.filePath);
            return artistViewModel;
        }


        public async Task<List<SnippetViewModel>> SearchYoutubeSnippets(string artistName)
        {
            YoutubeApiLogic youtubeApiLogic = new YoutubeApiLogic();
            List<SnippetViewModel> snippetViewModelList = await youtubeApiLogic.Search(artistName);
            return snippetViewModelList;
        }
    }
}
