using ReactiveApp.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ReactiveContentPage<SettingsVM>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}