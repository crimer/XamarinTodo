using ReactiveApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ReactiveContentPage<LoginVM>
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new LoginVM();
            //this.WhenActivated(d =>
            //{
            //    // Подключить валидацию во View нельзя, ее приходится тут програмно 
            //    this.BindValidation(ViewModel, vm => vm.Email, page => page.validationEmail.Text)
            //    .DisposeWith(d);
            //    this.BindValidation(ViewModel, vm => vm.Password, page => page.validationPassword.Text)
            //    .DisposeWith(d);
            //});
            
        }
    }
}