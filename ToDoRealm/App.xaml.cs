﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoRealm.Views;



namespace ToDoRealm
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "SwipeView_Experimental" });
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
