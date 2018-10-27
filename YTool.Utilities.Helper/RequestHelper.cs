using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTool.Utilities.Helper
{
    public class RequestHelper
    {
        public string ExecuteRequest(string url, string method, NameValueCollection parameters, NameValueCollection headers)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.QueryString = parameters;
            var responseBytes = webClient.UploadValues(url, method, parameters);
            //string response = Encoding.ASCII.GetString(responseBytes);
            string response = Encoding.UTF8.GetString(responseBytes);
            return response;
        }

        public string ExecuteRequestSendFile(string url, NameValueCollection paramters, NameValueCollection headers, string filePath)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.QueryString = paramters;
            var responseBytes = webClient.UploadFile(url, filePath);
            //string response = Encoding.ASCII.GetString(responseBytes);
            string response = Encoding.UTF8.GetString(responseBytes);
            return response;
        }
    }
}
