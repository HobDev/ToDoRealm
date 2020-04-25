using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToDoRealm.Models;
using ToDoRealm.Views;
using ToDoRealm.ViewModels;

namespace ToDoRealm.Views
{


    public partial class ToDoListPage : ContentPage
    {

        public ToDoListPage()
        {
            InitializeComponent();

            BindingContext = new ToDoListViewModel();

        }


    }
}
