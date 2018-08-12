using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using System.Collections.Generic;
using Java.Lang;
using System.Runtime.Remoting.Contexts;
using Android.Content;

namespace TestProcessApp.Droid
{
    [Activity(Label = "TestProcessApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            var apps = PackageManager.GetInstalledApplications(PackageInfoFlags.Services);
            foreach (ApplicationInfo app in apps)
            {
                Console.WriteLine("Aho : " + app.PackageName);
            }

        }
    }
}

