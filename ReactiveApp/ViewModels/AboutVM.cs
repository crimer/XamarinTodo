using ReactiveUI;
using Splat;

namespace ReactiveApp.ViewModels
{
    public class AboutVM : BaseVM, IRoutableViewModel
    {
        public string UrlPathSegment => "About Page";

        public IScreen HostScreen { get; }
        public AboutVM(IScreen screen = null)
        {
            Title = "О нас";
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }

    }
}
