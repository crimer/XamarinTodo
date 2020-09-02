using ReactiveApp.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ReactiveContentPage<AboutVM>
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}