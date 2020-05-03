using ToDoRealm.ViewModels;
using Xamarin.Forms;

namespace ToDoRealm.Views
{

    public partial class ToDoItemPage : ContentPage
    {

        public ToDoItemPage()
        {
            InitializeComponent();

            BindingContext = new ToDoItemViewModel();
        }


    }
}


