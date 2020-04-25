using System;
using ToDoRealm.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Realms;
using System.Linq;
using ReactiveUI.Fody.Helpers;

namespace ToDoRealm.ViewModels
{
    [QueryProperty("Id", "id")]
    public class ToDoItemViewModel
    {

        Realm _realm;
        [Reactive]
        public ToDoItem Item { get; set; }
        string id;
        [Reactive]
        public string Id
        {

            set
            {
                id = Uri.UnescapeDataString(value);
                if (id != string.Empty)
                {
                    SetValues();
                }

            }

            get
            {
                return id;
            }
        }



        bool update = false;

        public ICommand SaveButtonCommand { get; set; }

        public ICommand DeleteButtonCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Item == null)
                        return;
                    _realm.Write(() => _realm.Remove(Item));
                    Shell.Current.SendBackButtonPressed();
                });
            }
        }



        public ToDoItemViewModel()
        {
            _realm = Realm.GetInstance();
            Item = new ToDoItem();
            SaveButtonCommand = new Command(async () => await SaveToDoItem());
        }

        private void SetValues()
        {
            Item = _realm.Find<ToDoItem>(Id);
            update = true;
        }

        async Task SaveToDoItem()
        {

            if (string.IsNullOrWhiteSpace(Item.Name) && string.IsNullOrWhiteSpace(Item.Description))
                return;
            _realm.Write(() =>
            {
                if (update)
                {
                    //Item.Name = Name;
                    //Item.Description = Description;
                    //Item.Done = Done;
                }

                else
                {
                    _realm.Add(Item);
                }

            });

            Shell.Current.SendBackButtonPressed();
        }
    }
}
