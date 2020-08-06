
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        //private async Task MenuItem_Clicked(object sender, System.EventArgs e)
        //{
        //    await DisplayAlert("", "Привет Хабр!", "OK");
        //}
    }
}