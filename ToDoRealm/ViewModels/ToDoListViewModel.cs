using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PropertyChanged;
using Xamarin.Forms;

using ToDoRealm.Models;
using ToDoRealm.Views;
using System.Windows.Input;
using Realms;
using System.Collections.Generic;

namespace ToDoRealm.ViewModels
{

    public class ToDoListViewModel : BaseViewModel
    {

        Realm _realm;

        public object SelectedItem
        {
            get;
            set;
        }

        public ICommand ItemSelectedCommand
        {
            get;
            set;
        }

        public ICommand AddItemCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new ToDoItemPage(new ToDoItemViewModel(string.Empty))));
                });
            }
        }

        public IEnumerable<ToDoItem> Items { get; private set; }


        public ToDoListViewModel()
        {
            _realm = Realm.GetInstance();
            Title = "ToDo";
            Items = _realm.All<ToDoItem>();
            ItemSelectedCommand = new Command<string>(OnItemSelected);

        }

        async void OnItemSelected(string id)
        {

            await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new ToDoItemPage(new ToDoItemViewModel(id))));

        }


    }
}