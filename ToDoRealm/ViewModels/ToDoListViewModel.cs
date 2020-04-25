using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

using ToDoRealm.Models;
using ToDoRealm.Views;
using System.Windows.Input;
using Realms;
using System.Collections.Generic;
using ReactiveUI.Fody.Helpers;

namespace ToDoRealm.ViewModels
{

    public class ToDoListViewModel
    {

        Realm _realm;

        public string Title { get; set; }

        public ToDoItem SelectedItem { get; set; }


        public ICommand ItemSelectedCommand { get; set; }


        public ICommand AddItemCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.GoToAsync($"itempage?id={string.Empty}");
                });
            }
        }

        [Reactive]
        public IEnumerable<ToDoItem> Items { get; private set; }


        public ToDoListViewModel()
        {
            _realm = Realm.GetInstance();
            Title = "ToDo";
            Items = _realm.All<ToDoItem>();
            ItemSelectedCommand = new Command(OnItemSelected);

        }

        async void OnItemSelected()
        {

            await Shell.Current.GoToAsync($"itempage?id={SelectedItem.Id}");
            SelectedItem = null;
        }


    }
}