using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTool.Business.ViewModels;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using YTool.Utilities.Helper;
namespace YTool.Business
{
    public class RecognizeLogic
    {
        string AuddApiToken = System.Configuration.ConfigurationManager.AppSettings["AuddApiToken"] ?? "test";
        string AuddApiUrl = System.Configuration.ConfigurationManager.AppSettings["AuddApiUrl"] ?? "https://api.audd.io/";
        string AuddApiMethod = System.Configuration.ConfigurationManager.AppSettings["AuddApiMethod"] ?? "recognize";

        public ArtistViewModel GetArtist(string filePath)
        {
            RequestHelper requestHelper = new RequestHelper();
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("method", AuddApiMethod);
            parameters.Add("api_token", AuddApiToken);
            string response = requestHelper.ExecuteRequestSendFile(AuddApiUrl, parameters, null, filePath);
            ArtistWrapperViewModel jsonResult = null;
            try
            {
                //string response = @"
                //{
                //    'status': 'success',
                //    'result': {
                //        'artist': 'Justin Timberlake',
                //        'title': 'Cannot Stop the Feeling!)',
                //        'album': 'BRIT Awards 2017',
                //        'release_date': '2016-05-06',
                //        'label': 'RCA Records Label',
                //        'underground': false
                //    }
                //}";
                jsonResult = JsonConvert.DeserializeObject<ArtistWrapperViewModel>(response);
                return jsonResult.result;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
