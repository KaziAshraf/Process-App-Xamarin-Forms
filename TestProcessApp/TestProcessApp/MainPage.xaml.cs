using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.Content.PM;

using Java.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProcessApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            events.Clicked += Events_Clicked;

        }

        private void Events_Clicked(object sender, EventArgs e)
        {
            AppUsage();
        }

        public void AppUsage()
        {
            ActivityManager am = (ActivityManager)Android.App.Application.Context.GetSystemService(Context.ActivityService);
            IList<ActivityManager.RunningAppProcessInfo> l = am.RunningAppProcesses;
            foreach (ActivityManager.RunningAppProcessInfo r in l)
            {
                Console.WriteLine("Aho : " + r.ProcessName);
            }
            string s = string.Empty;
            foreach (var item in am.RunningAppProcesses)
            {
                //am.GetProcessMemoryInfo()                

                var uid = item.Uid;
                s = item.ProcessName;

                var receivedByApp = Android.Net.TrafficStats.GetUidRxBytes(uid);
                var transmittedByApp = Android.Net.TrafficStats.GetUidTxBytes(uid);

                Console.WriteLine("User:Process: " + s + ", Rx: " + receivedByApp.ToString() + ", Tx: " + transmittedByApp.ToString());
            }


            //UsageStatsManager us = (UsageStatsManager)Android.App.Application.Context.GetSystemService(Context.UsageStatsService);
            //Calendar cal = Calendar.GetInstance(Locale.Default);
            //cal.Add(Calendar.Year, -1);
            //IList<UsageStats> list = us.QueryUsageStats(UsageStatsInterval.Yearly, 2015, 2019);
            //Console.WriteLine("Test1: " + cal.TimeInMillis);
            //Console.WriteLine("Test2: " + Java.Lang.JavaSystem.CurrentTimeMillis());
            //Console.WriteLine("Test3: " + list.Count);
            //foreach (UsageStats l in list)
            //{
            //    Console.WriteLine("Test3: " + l.ToString());
            //}
            //long currTime = Java.Lang.JavaSystem.CurrentTimeMillis();
            //long startTime= currTime - 1000 * 3600 * 20;
            //UsageStatsManager us = (UsageStatsManager)Android.App.Application.Context.GetSystemService(Context.UsageStatsService);
            //UsageEvents AllEvents = us.QueryEvents(startTime,currTime);
            //while (AllEvents.HasNextEvent) {
            //    var e = new UsageEvents.Event();
            //    Console.WriteLine(AllEvents.ToString());
            //    AllEvents.GetNextEvent(e);

            //}
            //if (!AllEvents.HasNextEvent) {
            //    Console.WriteLine("No Events MAn");
            //}

        }
    }
}
