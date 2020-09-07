using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Org.Json;

namespace ProchaskaHouseClient.RestAPICode
{
    class ProchaskaHomeAPI
    {

        public static async Task<string> LoadShoppingList()
        {
            //string url = "https://localhost:44350/api/ShoppingList/GetList";
            string url = "https://xkcd.com/info.0.json";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    return content;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }


    }
}