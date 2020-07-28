using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ReactiveApp.ViewModels
{
    public class TodosVM : ReactiveObject, IRoutableViewModel
    {
        #region Navigation
        public string UrlPathSegment => "TodosPage";
        public IScreen HostScreen { get; }
        #endregion

        #region Props
        [Reactive] public string UserName { get; private set; }
        #endregion
        public TodosVM(string userName = "User", IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            UserName = userName;
        }
    }
}
