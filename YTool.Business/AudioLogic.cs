using System;
using System.Collections.Generic;
using System.Text;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
//using NReco.VideoConverter;
namespace YTool.Business
{
    public class AudioLogic
    {
        public void TrimWavFile(string inPath, string inExt, string outPath, string outExt, int cutFromStart, int cutFromEnd)
        {

            var inputFile = new MediaFile { Filename = inPath };
            var outputFile = new MediaFile { Filename = outPath };

            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile, new ConversionOptions {
                    MaxVideoDuration = new TimeSpan(0,0, cutFromEnd)
                });
                
                //engine.GetMetadata(inputFile);

                // Saves the frame located on the 15th second of the video.
                //var options = new ConversionOptions {
                //    Seek = TimeSpan.FromSeconds(15),
                //};
                //engine.GetThumbnail(inputFile, outputFile, options);
            }

            //var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            //ffMpeg.ConvertMedia(inPath, inExt, outPath, outExt, new ConvertSettings()
            //{
            //    Seek = cutFromStart,
            //    MaxDuration = cutFromEnd,
            //});
        }
    }
}
