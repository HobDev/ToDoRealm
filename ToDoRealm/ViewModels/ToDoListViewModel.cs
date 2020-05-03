using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Realms;
using ToDoRealm.Models;
using Xamarin.Forms;

namespace ToDoRealm.ViewModels
{

    public class ToDoListViewModel : ReactiveObject
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
                    await Shell.Current.GoToAsync($"itempage");
                });
            }
        }


        public IEnumerable<ToDoItem> Items { get; set; }


        public ToDoListViewModel()
        {
            _realm = Realm.GetInstance();
            Title = "ToDo";
            Items = _realm.All<ToDoItem>();
            ItemSelectedCommand = new Command<ToDoItem>(async (item) => await OnItemSelected(item));

        }



        async Task OnItemSelected(ToDoItem item)
        {

            await Shell.Current.GoToAsync($"itempage?id={item.Id}");

        }


    }
}