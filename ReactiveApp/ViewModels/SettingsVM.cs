using ReactiveUI;
using Splat;

namespace ReactiveApp.ViewModels
{
    public class SettingsVM : BaseVM, IRoutableViewModel
    {
        public string UrlPathSegment => "Settings Page";

        public IScreen HostScreen { get; }
        public SettingsVM(IScreen screen = null)
        {
            Title = "Настройки";
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }

    }
}
