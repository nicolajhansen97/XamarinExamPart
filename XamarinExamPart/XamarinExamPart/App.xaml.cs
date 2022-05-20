﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamPart.Views;

namespace XamarinExamPart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
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
    }
}