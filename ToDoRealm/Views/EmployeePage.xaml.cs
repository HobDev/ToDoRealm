using ToDoRealm.ViewModels;
using Xamarin.Forms;

namespace ToDoRealm.Views
{
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
            BindingContext = new EmployeeViewModel();
        }
    }
}
