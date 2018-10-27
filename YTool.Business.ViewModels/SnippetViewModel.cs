using System;
using System.Collections.Generic;
using System.Text;

namespace YTool.Business.ViewModels
{
    public class SnippetViewModel
    {
        public string id { set; get; }
        public string title { set; get; }
        public YTool.Bases.Enums.YoutubeSnippetKind kind { set; get; }
    }
}
