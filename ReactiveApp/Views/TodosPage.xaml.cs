using ReactiveApp.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosPage : ReactiveContentPage<TodosVM>
    {
        public TodosPage()
        {
            InitializeComponent();
        }
    }
}