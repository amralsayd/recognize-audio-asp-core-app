using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YTool.Business.ViewModels;
using YTool.Business;
using System.IO;
using YTool.Presentaion.Website.Helpers;

namespace YTool.Presentaion.Website.Controllers
{
    public class HomeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IViewRenderService _viewRenderService;

        public HomeController(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ParseUrl([FromBody]SearchFormViewModel searchFormViewModel)
        {
            try
            {
                YoutubeLogic YLogic = new YoutubeLogic();
                VideoViewModel videoViewModel = await YLogic.GetVideoInfoByUrl(searchFormViewModel.youtubeUrl);
                var result =  await _viewRenderService.RenderToStringAsync("_VideoResult", videoViewModel);
                return Json(new
                {
                    status = true,
                    videoViewModel = videoViewModel,
                    partialViewData = Content(result)
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> DownloadAudioFile([FromBody]SearchFormViewModel searchFormViewModel)
        {
            try
            {
                YoutubeLogic YLogic = new YoutubeLogic();
                AudioFileViewModel audioFileViewModel = await YLogic.DownloadAudioByUrl(searchFormViewModel.youtubeUrl);
                audioFileViewModel.fileWebsitePath = Request.Scheme + "://" + Request.Host + Request.PathBase + "/Downloads/Audio/" + audioFileViewModel.fileName;
                var result = await _viewRenderService.RenderToStringAsync("_AudioResult", audioFileViewModel);
                return Json(new
                {
                    status = true,
                    audioFileViewModel = audioFileViewModel,
                    partialViewData = Content(result)
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SplitAudioFile([FromBody]AudioFileViewModel audioFileViewModel)
        {
            try
            {
                YoutubeLogic YLogic = new YoutubeLogic();
                AudioFileViewModel splitAudioFileViewModel = YLogic.SplitAudioFile(audioFileViewModel);
                splitAudioFileViewModel.fileWebsitePath = Request.Scheme + "://" + Request.Host + Request.PathBase + "/Downloads/Audio/" + splitAudioFileViewModel.fileName;
                var result = await _viewRenderService.RenderToStringAsync("_AudioResult", splitAudioFileViewModel);
                return Json(new
                {
                    status = true,
                    audioFileViewModel = splitAudioFileViewModel,
                    partialViewData = Content(result)
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> RecognizeAudioFile([FromBody]AudioFileViewModel audioFileViewModel)
        {
            try
            {
                bool operationStatus = false;
                YoutubeLogic YLogic = new YoutubeLogic();
                ArtistViewModel artistViewModel = await YLogic.RecognizeAudioFile(audioFileViewModel);
                var result = "";
                if (artistViewModel == null || string.IsNullOrWhiteSpace(artistViewModel.artist))
                    result = "Sorry, No artist match your video!!";
                else
                {
                    result = await _viewRenderService.RenderToStringAsync("_ArtistResult", artistViewModel);
                    operationStatus = true;
                }
                return Json(new
                {
                    status = operationStatus,
                    artistViewModel = artistViewModel,
                    partialViewData = Content(result)
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SerachYoutube([FromBody]ArtistViewModel artistViewModel)
        {
            try
            {
                YoutubeLogic YLogic = new YoutubeLogic();
                List<SnippetViewModel> snippetViewModelList = await YLogic.SearchYoutubeSnippets(artistViewModel.artist);
                var result = await _viewRenderService.RenderToStringAsync("_SearchResult", snippetViewModelList);
                return Json(new
                {
                    status = true,
                    snippetViewModelList = snippetViewModelList,
                    partialViewData = Content(result)
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json(new { status = false, message = ex.Message });
            }
        }

        //we can add this method in base controller to reuse it in all website
        //public string RenderRazorViewToString(string viewName, object model)
        //{
        //    ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
        //        var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
