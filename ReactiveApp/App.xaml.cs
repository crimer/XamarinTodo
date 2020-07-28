using Xamarin.Forms;

namespace ReactiveApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var bootstraper = new AppBootstraper();
            // главная "Начальная" страница
            MainPage = bootstraper.CreateMainPage();
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
