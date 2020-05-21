using ToDoRealm.Views;
using Xamarin.Forms;

namespace ToDoRealm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("todoitempage", typeof(ToDoItemPage));
            Routing.RegisterRoute("employeepage", typeof(EmployeePage));
            Routing.RegisterRoute("todolistpage", typeof(ToDoListPage));
        }
    }
}
