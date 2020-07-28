using ReactiveApp.Services.Auth;
using ReactiveApp.Services.Todo;
using ReactiveApp.ViewModels;
using ReactiveApp.Views;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using System;
using Xamarin.Forms;

namespace ReactiveApp
{
    // Класс единой регистрации сервисов и роутов
    public class AppBootstraper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public AppBootstraper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            RegisterServices();
            RegisterViews();
            // Первая отображенная страница это LoginVM а.к. LoginPage
            //Router.Navigate.Execute(new LoginVM());
            this.Router
                .NavigateAndReset
                .Execute(new LoginVM())
                .Subscribe();
        }
        // Регистрируем сервис
        private void RegisterServices()
        {
            Locator.CurrentMutable.Register(() => new TodoService(), typeof(ITodoService));
            Locator.CurrentMutable.Register(() => new AuthService(), typeof(IAuthService));
        }

        // Связка страницы с VM
        private void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new LoginPage(), typeof(IViewFor<LoginVM>));
            Locator.CurrentMutable.Register(() => new TodosPage(), typeof(IViewFor<TodosVM>));
        }
        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
