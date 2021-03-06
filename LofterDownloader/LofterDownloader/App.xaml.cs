﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LofterDownloader.Views;
using LofterDownloader.Services;
using System.IO;

namespace LofterDownloader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CheckSettings();
            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void CheckSettings()
        {
            // 如果不包含一定没运行
            if (!Properties.ContainsKey("MainPath") || (string)Properties["MainPath"] == string.Empty)
            {
                string folderPath = DependencyService.Get<IChooseFolderService>().GetFolder();
                Properties.Add("MainPath", folderPath);
            }
            CheckSetting("IsDownloadBlogImg", true);
            CheckSetting("IsDownloadLinkImg", true);
            CheckSetting("IsDownloadBlogContent", true);
            CheckSetting("IsDownloadBlogWhileItHasImg", true);
            CheckSetting("IsSortByAuthor", true);
            CheckSetting("MaxDegreeOfParallelism", 4);
            CheckSetting("IsDownloadLongBlogImg", true);
            CheckSetting("LongBlogLength", 200);
        }
        private void CheckSetting(string key, object defaultValue)
        {
            if (!Properties.ContainsKey(key))
                Properties.Add(key, defaultValue);
        }
    }
}
