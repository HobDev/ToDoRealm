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


        public ICommand ItemSelectedCommand { get; set; }


        public ICommand AddItemCommand
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
            Title = "Employees";
            Employees = _realm.All<Assignee>();
            ItemSelectedCommand = new Command<Assignee>(async (assignee) => await OnItemSelected(assignee));
        }

        async Task OnItemSelected(Assignee assignee)
        {

            await Shell.Current.GoToAsync($"todolistpage?id={assignee.Id}");

        }

    }
}
