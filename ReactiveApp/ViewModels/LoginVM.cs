using ReactiveApp.Services.Auth;
using ReactiveApp.Views;
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
    public class LoginVM : BaseVM, IRoutableViewModel, IValidatableViewModel
    {
        public string UrlPathSegment => "Login Page";
        public IScreen HostScreen { get; }
        public ReactiveCommand<Unit, Unit> LogIn { get; private set; }
        #region Props
        public ValidationContext ValidationContext { get; } = new ValidationContext();
        [Reactive] public string Email { get; set; } = string.Empty;
        [Reactive] public string Password { get; set; } = string.Empty;
        [ObservableAsProperty] public bool IsLoading { get; set; }

        #endregion
        private IAuthService _authService;
        public LoginVM(IScreen screen = null, IAuthService authService = null)
        {
            Title = "Вход";
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _authService = authService ?? (IAuthService)Locator.Current.GetService<IAuthService>();

            // Валидация логина и пароля
            //this.ValidationRule(vm => vm.Email,
            //    val => (val.Length > 5) && (Regex.Matches(val, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1),
            //    "Email должен быть валидным test@mail.ru");
            this.ValidationRule(vm => vm.Email,
                val => !string.IsNullOrWhiteSpace(val),
                "Email не должен быть пустым");

             this.ValidationRule(vm => vm.Password,
                val => !string.IsNullOrWhiteSpace(val),
                "Password не должен быть пустым");


            //this.ValidationRule(vm => vm.Password,
            //    val => !string.IsNullOrEmpty(val) && val.Length >= 5,
            //    "Пароль делжен быть длинее 5 символов");

            var isValid = this.IsValid();

            // Взможно не работает IsLoading и индикотор загрузки
            this.WhenAnyObservable(vm => vm.LogIn.IsExecuting)
                .ToPropertyEx(this, vm => vm.IsLoading, initialValue: false);

            LogIn = ReactiveCommand.CreateFromTask(LogInImpl, isValid);
            LogIn.ThrownExceptions.Select(ex => ex.Message).Subscribe(ex => Debug.WriteLine(ex));

        }
        public async Task LogInImpl()
        {
            var lg = await _authService.Login(Email, Password);
            if (lg)
            {
                Debug.WriteLine($"Is loading: {IsLoading}");
                Debug.WriteLine($"User Loged In: {Email} - {Password}");
                HostScreen.Router.Navigate.Execute(new MainPageVM()).Subscribe();
            }
            else
            {
                Debug.WriteLine($"Login faild: {Email} - {Password}");
            }
        }
    }
}
