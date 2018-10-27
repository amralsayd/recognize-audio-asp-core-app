using System;
using System.Collections.Generic;
using System.Text;

namespace YTool.Business.ViewModels
{
    public class VideoViewModel
    {
        // Summary:
        //     Author of this video.
        public string Author { set; get; }
        //
        // Summary:
        //     Description of this video.
        public string Description { set; get; }
        //
        // Summary:
        //     Duration of this video.
        public TimeSpan Duration { set; get; }
        //
        // Summary:
        //     ID of this video.
        public string Id { set; get; }
        //
        // Summary:
        //     Search keywords of this video.
        public IReadOnlyList<string> Keywords { set; get; }
        //
        // Summary:
        //     Title of this video.
        public string Title { set; get; }
        //
        // Summary:
        //     Upload date of this video.
        public DateTimeOffset UploadDate { set; get; }
    }
}
