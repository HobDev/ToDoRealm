using ToDoRealm.Views;
using Xamarin.Forms;

namespace ToDoRealm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ToDoItemPage), typeof(ToDoItemPage));
            Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
            Routing.RegisterRoute(nameof(ToDoListPage), typeof(ToDoListPage));
        }
    }
}
