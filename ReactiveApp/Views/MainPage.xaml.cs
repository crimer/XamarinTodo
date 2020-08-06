using ReactiveApp.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ReactiveTabbedPage<MainPageVM>
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new MainPageVM();

        }
    }
}