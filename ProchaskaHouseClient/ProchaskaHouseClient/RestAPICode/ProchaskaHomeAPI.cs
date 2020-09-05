using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProchaskaHouseClient.RestAPICode
{
    class ProchaskaHomeAPI
    {

        public string endPoint { get; set; }
        public string httpMethod { get; set; }

        public ProchaskaHomeAPI()
        {
            endPoint = string.Empty;
            httpMethod = "GET";
        }

        public string makeRequest()
        {
            string strResponse = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new ApplicationException("error code " + response.StatusCode);
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponse = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponse;
        }
    }
}