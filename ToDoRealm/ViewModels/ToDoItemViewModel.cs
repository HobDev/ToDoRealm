using System;
using ToDoRealm.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Realms;
using System.Linq;

namespace ToDoRealm.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {

        Realm _realm;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        bool update;

        public ICommand SaveButtonCommand
        {
            get;
            set;
        }

        public ICommand DeleteButtonCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Item == null)
                        return;
                    _realm.Write(() => _realm.Remove(Item));
                    Shell.Current.Navigation.PopModalAsync();
                });
            }
        }

        public ICommand CancelButtonCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.Navigation.PopModalAsync();

                });
            }
        }


        public ToDoItem Item { get; set; }
        public ToDoItemViewModel(string id)
        {
            _realm = Realm.GetInstance();

            if (id != string.Empty)
            {
                Item = _realm.Find<ToDoItem>(id);
                Name = Item.Name;
                Description = Item.Description;
                Done = Item.Done;
                update = true;

            }

            SaveButtonCommand = new Command(async () => await SaveToDoItem());
        }

        async Task SaveToDoItem()
        {

            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Description))
                return;
            _realm.Write(() =>
            {
                if (update)
                {
                    Item.Name = Name;
                    Item.Description = Description;
                    Item.Done = Done;
                }

                else
                {
                    _realm.Add(new ToDoItem { Name = Name, Description = Description, Done = Done });
                }

            });

            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
