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
    public class AppLocator
    {
        //public RoutingState Router { get; }
        //public AppLocator()
        //{
        //    Router = new RoutingState();
        //    Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
        //    RegisterServices();
        //    RegisterViews();
        //    // Первая отображенная страница это LoginVM а.к. LoginPage
        //    Router.Navigate.Execute(new LoginVM()).Subscribe();
        //}
        public static TodosVM TodosVM => Locator.Current.GetService<TodosVM>();
        public static LoginVM LoginVM => Locator.Current.GetService<LoginVM>();
        static public void Init()
        {
            Locator.CurrentMutable.Register(() => new TodosVM());
            Locator.CurrentMutable.Register(() => new LoginVM());

            //registered without splat... skipped this step for simplicity.
            DependencyService.Register<TodoService>();
        }
        // Регистрируем сервис
        //private void RegisterServices()
        //{
        //    Locator.CurrentMutable.Register(() => new TodoService(), typeof(ITodoService));
        //    Locator.CurrentMutable.Register(() => new AuthService(), typeof(IAuthService));
        //}

        //// Связка страницы с VM
        //private void RegisterViews()
        //{
        //    Locator.CurrentMutable.Register(() => new LoginPage(), typeof(IViewFor<LoginVM>));
        //    Locator.CurrentMutable.Register(() => new TodosPage(), typeof(IViewFor<TodosVM>));
        //    Locator.CurrentMutable.Register(() => new MainPage(), typeof(IViewFor<MainPageVM>));
        //}
        //public Page CreateMainPage()
        //{
        //    return new RoutedViewHost();
        //}
    }
}
