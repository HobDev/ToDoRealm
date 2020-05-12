using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Realms;
using ToDoRealm.Models;
using Xamarin.Forms;

namespace ToDoRealm.ViewModels
{
    public class EmployeeListViewModel
    {
        Realm _realm;


        public string Title { get; set; }


        public ICommand EmployeeSelectedCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }

        public ICommand AddEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Shell.Current.GoToAsync($"employeepage");
                });
            }
        }


        public IEnumerable<Assignee> Employees { get; set; }

        public EmployeeListViewModel()
        {
            _realm = Realm.GetInstance();
            Employees = _realm.All<Assignee>();
            EmployeeSelectedCommand = new Command<Assignee>(async (assignee) => await OnEmployeeSelected(assignee));
            DeleteEmployeeCommand = new Command<Assignee>(async (assignee) => await DeleteEmployee(assignee));
            EditEmployeeCommand = new Command<Assignee>(async (assignee) => await EditEmployee(assignee));
        }

        async Task EditEmployee(Assignee assignee)
        {
            await Shell.Current.GoToAsync($"employeepage?employeeid={assignee.Id}");
        }

        async Task DeleteEmployee(Assignee assignee)
        {
            if (assignee == null)
                return;
            _realm.Write(() => _realm.Remove(assignee));
        }

        async Task OnEmployeeSelected(Assignee assignee)
        {

            await Shell.Current.GoToAsync($"todolistpage?employeeid={assignee.Id}");

        }

    }
}
