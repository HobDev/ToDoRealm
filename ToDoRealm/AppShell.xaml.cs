using System;
using System.Collections.Generic;
using ToDoRealm.Views;
using Xamarin.Forms;

namespace ToDoRealm
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("itempage", typeof(ToDoItemPage));
        }
    }
}
