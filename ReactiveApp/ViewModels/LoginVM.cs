using ReactiveApp.Services.Auth;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using Splat;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReactiveApp.ViewModels
{
    public class LoginVM : ReactiveObject, IRoutableViewModel, IValidatableViewModel
    {
        #region Navigations
        public string UrlPathSegment => "LoginPage";
        public IScreen HostScreen { get; }
        #endregion

        #region Commands
        public ReactiveCommand<Unit, Unit> LogIn { get; private set; }
        #endregion

        #region Props
        public ValidationContext ValidationContext { get; } = new ValidationContext();
        [Reactive] public string Email { get; set; } = string.Empty;
        [Reactive] public string Password { get; set; } = string.Empty;
        [ObservableAsProperty] public bool IsLoading { get; set; }
        #endregion
        private IAuthService _authService;
        public LoginVM(IScreen screen = null, IAuthService authService = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            _authService = authService ?? (IAuthService)Locator.Current.GetService<IAuthService>();

            // Валидация логина и пароля
            this.ValidationRule(vm => vm.Email,
                val => (val.Length > 5) && (Regex.Matches(val, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1),
                "Email должен быть валидным test@mail.ru");


            this.ValidationRule(vm => vm.Password,
                val => !string.IsNullOrEmpty(val) && val.Length >= 5,
                "Пароль делжен быть длинее 5 символов");

            var isValid = this.IsValid();

            // Взможно не работает IsLoading и индикотор загрузки
            this.WhenAnyObservable(vm => vm.LogIn.IsExecuting)
                .ToPropertyEx(this, vm => vm.IsLoading, initialValue: false);

            LogIn = ReactiveCommand.CreateFromTask(LogInImpl, isValid);
            LogIn.ThrownExceptions.Subscribe(ex => this.Log().ErrorException("Error = ", ex));

        }
        public async Task LogInImpl()
        {
            var lg = await _authService.Login(Email, Password);
            if (lg)
            {
                Debug.WriteLine($"Is loading: {IsLoading}");
                Debug.WriteLine($"User Loged In: {Email} - {Password}");
                HostScreen.Router.Navigate.Execute(new TodosVM()).Subscribe();
            }
            else
            {
                Debug.WriteLine($"Login faild: {Email} - {Password}");
            }
        }
    }
}
