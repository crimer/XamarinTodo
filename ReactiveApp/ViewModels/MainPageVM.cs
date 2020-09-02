using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
<<<<<<< HEAD
using System.Reactive.Linq;
=======
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
using System.Reactive.Threading.Tasks;

namespace ReactiveApp.ViewModels
{
    public class MainPageVM : BaseVM, IRoutableViewModel
    {
        public string UrlPathSegment => "Tabbed page";

        public IScreen HostScreen { get; }
        public MainPageVM(IScreen screen = null)
        {
<<<<<<< HEAD
            Title = "Главная";
            
=======
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _todoService = todoService ?? Locator.Current.GetService<ITodoService>();
            var items = _todoService.GetTodosAsync();
            _todos = items;
            _todos
                // Трансформируем источник в наблюдаемый набор изменений.
                // Имеем тип IObservable<IChangeSet<Trade, long>>
                .Connect()
                // Привяжем список объектов
                // к коллекции из System.Collections.ObjectModel.
                .Bind(out _todosList).Subscribe();
            Debug.WriteLine(Todos);
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
        }

    }
}
