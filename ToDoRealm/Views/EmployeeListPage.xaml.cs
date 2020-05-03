using ToDoRealm.ViewModels;
using Xamarin.Forms;

namespace ToDoRealm.Views
{
    public partial class EmployeeListPage : ContentPage
    {
        public EmployeeListPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeListViewModel();
        }
    }
}
