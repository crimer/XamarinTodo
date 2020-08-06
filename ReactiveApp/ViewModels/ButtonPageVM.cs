using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System.Diagnostics;

namespace ReactiveApp.ViewModels
{
    public class ButtonPageVM : ReactiveObject, IRoutableViewModel
    {
        [Reactive]
        public string Title { get; set; } = "Hello";

        public string UrlPathSegment => "Button page";

        public IScreen HostScreen { get; }
        public ButtonPageVM(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Debug.WriteLine("Button page");
        }
    }
}
