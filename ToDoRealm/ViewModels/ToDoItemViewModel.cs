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
    [QueryProperty("ToDoItemId", "todoitemid")]
    [QueryProperty("EmployeeId", "employeeid")]
    public class ToDoItemViewModel : ReactiveObject
    {

        Realm _realm;
        bool update = false;
        [Reactive]
        public ToDoItem Item { get; set; }
        [Reactive]
        public Assignee Employee { get; set; }
        string todoitemid;
        [Reactive]
        public string ToDoItemId
        {

            get { return todoitemid; }
            set
            {
                todoitemid = Uri.UnescapeDataString(value);

            }
        }


        string employeeid;
        [Reactive]
        public string EmployeeId
        {

            get { return employeeid; }
            set
            {
                employeeid = Uri.UnescapeDataString(value);

            }

        }

        public ICommand SetEmployeeCommand { get; set; }

        public ICommand SetToDoItemCommand { get; set; }

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
            SetToDoItemCommand = new Command(async () => await SetToDoItem());
            SetEmployeeCommand = new Command(async () => await SetEmployee());

            this.WhenAnyValue(x => x.ToDoItemId)
    .Where(x => !String.IsNullOrWhiteSpace(x))
    .InvokeCommand(SetToDoItemCommand);

            this.WhenAnyValue(x => x.EmployeeId)
   .Where(x => !String.IsNullOrWhiteSpace(x))
   .InvokeCommand(SetEmployeeCommand);
        }

        async Task SetEmployee()
        {
            Employee = _realm.Find<Assignee>(EmployeeId);
        }

        async Task SetToDoItem()
        {
            Item = _realm.Find<ToDoItem>(ToDoItemId);
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

                    Item.Employee = Employee;
                    _realm.Add(Item);

                }

            });

            await Shell.Current.GoToAsync("..");
        }
    }
}
