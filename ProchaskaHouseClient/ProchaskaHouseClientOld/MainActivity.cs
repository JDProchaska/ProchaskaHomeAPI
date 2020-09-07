using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using RestSharp;
using Java.Net;
using System;
using Org.Apache.Http.Impl.Client;
using ProchaskaHouseClient.RestAPICode;
using ProchaskaHouseAPI.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;

namespace ProchaskaHouseClient
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(BaseContext, Android.Resource.Layout.SimpleListItem1);
            GetShoppingList(adapter);
        }

        private void GetShoppingList(ArrayAdapter<string> adapter)
        {
            var client = new RestClient("http://10.0.0.180:45457/api/ShoppingList/GetList");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = client.Execute<List<ShoppingListItem>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                SetListView(response.Data, adapter);
                //FindViewById<List>(Resource.Id.shoppinglist).Text = response.Data.ToString(); 
        }

        private void SetListView(List<ShoppingListItem> data, ArrayAdapter<string> adapter)
        {
            foreach (ShoppingListItem item in data)
            {
                adapter.Add(item.Name);
            }
            FindViewById<GridView>(Resource.Id.gridView1).Adapter = adapter;
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}