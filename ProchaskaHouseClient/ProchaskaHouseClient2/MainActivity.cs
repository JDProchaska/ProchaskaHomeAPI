using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ProchaskaHouseAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ProchaskaHouseClient2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        GridView gridView;
        ArrayAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            gridView = FindViewById<GridView>(Resource.Id.gridView1);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            gridView.Adapter = null;
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.Enabled = true;
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_shoppingList:
                    textMessage.Enabled = false;
                    SetShoppingList();
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.Enabled = true;
                    textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }

        private void SetShoppingList()
        {
            var client = new RestClient("http://10.0.0.180:45457/api/ShoppingList/GetList");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = client.Execute<List<ShoppingListItem>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                SetListView(response.Data);
        }

        private void SetListView(List<ShoppingListItem> data)
        {
            adapter = new ArrayAdapter<string>(BaseContext, Android.Resource.Layout.SimpleListItem1);
            foreach (ShoppingListItem item in data)
            {
                adapter.Add(item.Name);
                adapter.Add(item.Qty);
            }
            FindViewById<GridView>(Resource.Id.gridView1).Adapter = adapter;
        }
    }
}

