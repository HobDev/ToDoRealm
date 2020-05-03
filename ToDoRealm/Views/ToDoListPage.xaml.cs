using ToDoRealm.ViewModels;
using Xamarin.Forms;

namespace ToDoRealm.Views
{


    public partial class ToDoListPage : ContentPage
    {

        public ToDoListPage()
        {
            InitializeComponent();

            BindingContext = new ToDoListViewModel();

        }


    }
}
