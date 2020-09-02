using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ReactiveApp.ViewModels
{
    public class MainPageVM : BaseVM, IRoutableViewModel
    {
        public string UrlPathSegment => "Tabbed page";

        public IScreen HostScreen { get; }
        public MainPageVM(IScreen screen = null)
        {
            Title = "Главная";
            
        }

    }
}
