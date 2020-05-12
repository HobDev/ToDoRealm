using System;
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
    public class EmployeeViewModel : ReactiveObject
    {
        Realm _realm;
        bool update = false;
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

        public ICommand SetValuesCommand { get; set; }

        public ICommand SaveButtonCommand { get; set; }

        public ICommand DeleteButtonCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (Employee == null)
                        return;
                    _realm.Write(() => _realm.Remove(Employee));
                    await Shell.Current.GoToAsync("..");
                });
            }
        }

        public EmployeeViewModel()
        {
            _realm = Realm.GetInstance();
            Employee = new Assignee();
            SaveButtonCommand = new Command(async () => await SaveEmployee());
            SetValuesCommand = new Command(async () => await SetValues());
            this.WhenAnyValue(x => x.EmployeeId)
    .Where(x => !String.IsNullOrWhiteSpace(x))
    .InvokeCommand(SetValuesCommand);
        }


        async Task SetValues()
        {
            Employee = _realm.Find<Assignee>(EmployeeId);
            update = true;
        }

        async Task SaveEmployee()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Employee.Name) && string.IsNullOrWhiteSpace(Employee.Role))
                    return;
                if (Employee == null)
                    Employee = new Assignee();
                _realm.Write(() =>
                {
                    if (!update)
                    {
                        _realm.Add(Employee);
                    }

                });


            }
            catch (Exception ex)
            {

            }

            await Shell.Current.GoToAsync("..");

        }


    }
}
