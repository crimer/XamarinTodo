using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using Splat;
using System.Diagnostics;
using System.Reactive;

namespace ReactiveApp.ViewModels
{
    public class LoginVM : ReactiveObject, IRoutableViewModel, IValidatableViewModel
    {
        #region Navigations
        public string UrlPathSegment => "LoginPage";
        public IScreen HostScreen { get; }
        #endregion

        #region Commands
        public ReactiveCommand<Unit, Unit> LogIn { get; }
        #endregion

        #region Props
        public ValidationContext ValidationContext { get; } = new ValidationContext();
        [Reactive] public string Email { get; set; }
        [Reactive] public string Password { get; set; }
        [ObservableAsProperty] public bool CanCreateUser { get; set; }
        #endregion

        public LoginVM(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            //  Regex.Matches(val, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1
            //this.ValidationRule(vm => vm.Email,
            //    val => val.Length > 5,
            //    "Email должен быть валидным");

            //this.ValidationRule(vm => vm.Password,
            //    val => !string.IsNullOrEmpty(val) && val.Length >= 5,
            //    "Пароль делжен быть длинее 5 символов");

            //var isValid = this.IsValid();
            this.WhenAnyValue(vm => vm.Email, vm => vm.Password,
            (email, password) =>
            {
                Debug.WriteLine(email);
                Debug.WriteLine(password);
            }).ToProperty(this, vm => vm.CanCreateUser);
            LogIn = ReactiveCommand.CreateFromTask(async () =>
            {
                Debug.WriteLine("User Loged In");
            });
            //LogIn.ThrownExceptions.Subscribe((ex)=> { 
            //    Debug.WriteLine("User Loged In");

            //});
        }
    }
}
