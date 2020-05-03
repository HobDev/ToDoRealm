using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Realms;
using ToDoRealm.Models;
using Xamarin.Forms;

namespace ToDoRealm.ViewModels
{
    [QueryProperty("Id", "id")]
    public class ToDoItemViewModel : ReactiveObject
    {

        Realm _realm;
        bool update = false;
        [Reactive]
        public ToDoItem Item { get; set; }
        string id;
        [Reactive]
        public string Id
        {

            get { return id; }
            set
            {
                id = Uri.UnescapeDataString(value);

            }


        }

        public ICommand SetValuesCommand { get; set; }

        public ICommand SaveButtonCommand { get; set; }

        public ICommand DeleteButtonCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (Item == null)
                        return;
                    _realm.Write(() => _realm.Remove(Item));
                    await Shell.Current.GoToAsync("..");
                });
            }
        }



        public ToDoItemViewModel()
        {

            _realm = Realm.GetInstance();
            Item = new ToDoItem();
            SaveButtonCommand = new Command(async () => await SaveToDoItem());
            SetValuesCommand = new Command(async () => await SetValues());
            this.WhenAnyValue(x => x.Id)
    .Where(x => !String.IsNullOrWhiteSpace(x))
    .InvokeCommand(SetValuesCommand);
        }

        async Task SetValues()
        {
            Item = _realm.Find<ToDoItem>(Id);
            update = true;
        }

        async Task SaveToDoItem()
        {

            if (string.IsNullOrWhiteSpace(Item.Name) && string.IsNullOrWhiteSpace(Item.Description))
                return;
            if (Item == null)
                Item = new ToDoItem();
            _realm.Write(() =>
            {
                if (!update)
                {
                    _realm.Add(Item);
                }

            });

            await Shell.Current.GoToAsync("..");
        }
    }
}
