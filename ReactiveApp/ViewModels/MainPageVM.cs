using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveApp.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Threading.Tasks;

namespace ReactiveApp.ViewModels
{
    public class MainPageVM : ReactiveObject, IRoutableViewModel
    {

        public ButtonPageVM ButtonPage => new ButtonPageVM();
        public TodosVM TodosPage = new TodosVM();
        public string UrlPathSegment => "Tabbed page";
        #region Props
        private readonly ReadOnlyObservableCollection<Todo> _todosList;
        public ReadOnlyObservableCollection<Todo> Todos => _todosList;
        // Объявляем изменяемый список задач
        private SourceList<Todo> _todos = new SourceList<Todo>();
        private ITodoService _todoService;
        #endregion

        public IScreen HostScreen { get; }
        public MainPageVM(IScreen screen = null, ITodoService todoService = null)
        {
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
        }

    }
}
