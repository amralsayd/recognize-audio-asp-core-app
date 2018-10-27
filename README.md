# recognize-audio-asp-core-app

This porject for this task description:

Music recogniser app

We want to create a web app (one page) that will have a place to put a video url (youtube music video), then the app will be able to recognize the name of the song and will fetch a list of other songs for the same artist (from youtube) and will display on the app page (with title thumbnails and links to play it)


To perform this we will need several apis and tools

For downloading video from youtube you can use youtube-dl  

<strong>I am use differnet lib youtube Explode</strong> 

To split the audio from the downloaded video you will use ffmpeg (only 1 minute audio file should be extracted in mp3 format)

<strong>I am use MediaToolkit lib to convert the donloaded file and split it to 20 sec because the Audd Api request the media file must be smaller than 25 seconds</strong>

The audio file should be sent to https://audd.io api for recognition (you will use the free version 10 requests per day, so use carefully)

Once the song is recognized and you got the artist name, you will use youtube api to search for songs of that artists and create a playlist on that page with the resulting data

<strong>I am use Google.Apis.YouTube.v3</strong>

If the song is not recognized a nice message should appear

While the file is being downloaded, converted, recognized in background, user should get status message of the current progress with some loading icon
 
For this task you need to use asp.net core 2.0 deployed on linux


You can set the configration in the App.config file:
```xml
<appSettings>
    <add key="YoutubeApiKey" value="" />
    <add key="AuddApiToken" value="test" />
    <add key="AuddApiUrl" value="https://api.audd.io/" />
    <add key="AuddApiMethod" value="recognize" />
    <add key="CutInterval" value="20" />
</appSettings>
```
