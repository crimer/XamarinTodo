using Xamarin.Forms;

namespace ReactiveApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var bootstraper = new AppLocator();
            // главная "Начальная" страница
            //MainPage = bootstraper.CreateMainPage();
            AppLocator.Init();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
