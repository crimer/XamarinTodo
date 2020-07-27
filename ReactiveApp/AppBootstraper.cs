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
            RegisterViews();
            //RegisterServices();
        }
        // Регистрируем сервис
        private void RegisterServices()
        {
            throw new NotImplementedException();
        }

        // Связка страницы с VM
        private void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new LoginPage(), typeof(IViewFor<LoginVM>));
            // Первая отображенная страница это LoginVM а.к. LoginPage
            this.Router.NavigateAndReset.Execute(new LoginVM()).Subscribe();
        }
        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
