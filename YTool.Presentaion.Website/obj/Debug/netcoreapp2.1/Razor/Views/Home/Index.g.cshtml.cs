#pragma checksum "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c5f0ce028f492b00e15ec82eae945e5e85d5069"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/_ViewImports.cshtml"
using YTool.Presentaion.Website;

#line default
#line hidden
#line 2 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/_ViewImports.cshtml"
using YTool.Presentaion.Website.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5f0ce028f492b00e15ec82eae945e5e85d5069", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fb88712b419b98d63004bc96a46e7eeb9cdef46", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmYoutube"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 12, true);
            WriteLiteral("\r\n\r\n<br />\r\n");
            EndContext();
            BeginContext(57, 450, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945d9946845b441ba51e10efef7f7847", async() => {
                BeginContext(111, 389, true);
                WriteLiteral(@"
    <div class=""form-group mb-2"">
        <label for=""staticEmail2"" class=""sr-only"">Youtube URL</label>
        <input id=""youtubeUrl"" name=""youtubeUrl"" type=""text"" size=""100"" value=""https://www.youtube.com/watch?v=qcN8GkfaOZo"" class=""form-control"" placeholder=""Youtube url.."">
    </div>
    <button type=""button"" id=""btnYoutubeSearch"" class=""btn btn-primary mb-2"">Submit</button>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(507, 790, true);
            WriteLiteral(@"
<br />

<div class=""progress"">
    <div id=""dynamic"" class=""progress-bar progress-bar-striped active"" role=""progressbar"" aria-valuenow=""0"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width: 0%"">
        <span id=""current-progress""></span>
    </div>
</div>

<br />
<div class=""row"">
    <div class=""col-md-6"">
        <div id=""divVideoResult""></div>
    </div>
    <div class=""col-md-6"">
        <div id=""divRecognizeAudioFile""></div>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-6"">

        <div id=""divDownloadFile""></div>

    </div>
    <div class=""col-md-6"">

        <div id=""divSplitAudioFile""></div>

    </div>
</div>
<div class=""row"">
    <div class=""col-md-12"">
        <div id=""divSearchResult""></div>
    </div>
</div>



");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1320, 43, true);
                WriteLiteral("\r\n    <script>\r\n        var ParseUrlUrl = \'");
                EndContext();
                BeginContext(1364, 22, false);
#line 54 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
                      Write(Url.Action("ParseUrl"));

#line default
#line hidden
                EndContext();
                BeginContext(1386, 40, true);
                WriteLiteral("\';\r\n        var DownloadAudioFileUrl = \'");
                EndContext();
                BeginContext(1427, 31, false);
#line 55 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
                               Write(Url.Action("DownloadAudioFile"));

#line default
#line hidden
                EndContext();
                BeginContext(1458, 35, true);
                WriteLiteral("\'\r\n        var SerachYoutubeUrl = \'");
                EndContext();
                BeginContext(1494, 27, false);
#line 56 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
                           Write(Url.Action("SerachYoutube"));

#line default
#line hidden
                EndContext();
                BeginContext(1521, 36, true);
                WriteLiteral("\'\r\n        var SplitAudioFileUrl = \'");
                EndContext();
                BeginContext(1558, 28, false);
#line 57 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
                            Write(Url.Action("SplitAudioFile"));

#line default
#line hidden
                EndContext();
                BeginContext(1586, 41, true);
                WriteLiteral("\';\r\n        var RecognizeAudioFileUrl = \'");
                EndContext();
                BeginContext(1628, 32, false);
#line 58 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
                                Write(Url.Action("RecognizeAudioFile"));

#line default
#line hidden
                EndContext();
                BeginContext(1660, 30, true);
                WriteLiteral("\';\r\n    </script>\r\n    <script");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1690, "\"", 1729, 1);
#line 60 "/home/amr/Documents/YTools/YTool.Presentaion.Website/Views/Home/Index.cshtml"
WriteAttributeValue("", 1696, Url.Content("~/js/app/index.js"), 1696, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1730, 124, true);
                WriteLiteral("></script>\r\n    <style>\r\n        .progress {\r\n            margin: 10px;\r\n            width: 100%;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
