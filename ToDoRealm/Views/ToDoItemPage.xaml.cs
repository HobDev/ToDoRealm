using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoRealm.Models;
using ToDoRealm.ViewModels;

namespace ToDoRealm.Views
{

    public partial class ToDoItemPage : ContentPage
    {

        public ToDoItemPage()
        {
            InitializeComponent();

            BindingContext = new ToDoItemViewModel();
        }


    }
}


