using System;
using System.Collections.Generic;
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
    [QueryProperty("EmployeeId", "employeeid")]
    public class ToDoListViewModel : ReactiveObject
    {

        Realm _realm;


        public string Title { get; set; }
        [Reactive]
        public Assignee Employee { get; set; }
        string id;
        [Reactive]
        public string EmployeeId
        {
            get { return id; }
            set
            {
                id = Uri.UnescapeDataString(value);
            }
        }

        public ICommand DeleteToDoItemCommand { get; set; }
        public ICommand EditToDoItemCommand { get; set; }
        public ICommand SetValuesCommand { get; set; }

        public ICommand AddItemCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.GoToAsync($"todoitempage?employeeid={EmployeeId}");
                });
            }
        }

        [Reactive]
        public IEnumerable<ToDoItem> Items { get; set; }


        public ToDoListViewModel()
        {
            _realm = Realm.GetInstance();
            if (!string.IsNullOrWhiteSpace(EmployeeId))
            {
                Items = _realm.All<ToDoItem>().Where(x => x.Employee == Employee);
            }

            _realm.RealmChanged += _realm_RealmChanged;
            DeleteToDoItemCommand = new Command<ToDoItem>(async (item) => await DeleteToDoItem(item));
            EditToDoItemCommand = new Command<ToDoItem>(async (item) => await EditToDoItem(item));
            SetValuesCommand = new Command(async () => await SetValues());
            this.WhenAnyValue(x => x.EmployeeId)
  .Where(x => !String.IsNullOrWhiteSpace(x))
  .InvokeCommand(SetValuesCommand);
        }

        private void _realm_RealmChanged(object sender, EventArgs e)
        {
            Items = _realm.All<ToDoItem>().Where(x => x.Employee == Employee);
        }

        async Task SetValues()
        {
            Employee = _realm.Find<Assignee>(EmployeeId);
            Title = Employee.Name;
            Items = _realm.All<ToDoItem>().Where(x => x.Employee == Employee);

        }

        async Task EditToDoItem(ToDoItem item)
        {
            await Shell.Current.GoToAsync($"todoitempage?todoitemid={item.Id}");
        }

        async Task DeleteToDoItem(ToDoItem item)
        {
            if (item == null)
                return;
            _realm.Write(() => _realm.Remove(item));
        }



    }
}