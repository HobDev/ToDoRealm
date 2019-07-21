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


        ToDoListViewModel viewModel;

        public ToDoListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ToDoListViewModel();

        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            ToDoItem item = e.SelectedItem as ToDoItem;
            string id = item.Id;
            viewModel.ItemSelectedCommand.Execute(id);
            ItemsListView.SelectedItem = null;
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

        }




    }
}
