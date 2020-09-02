using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ReactiveApp.ViewModels
{
    public class TodosVM : BaseVM, IRoutableViewModel
    {
        #region Navigation
        public string UrlPathSegment => "Todos page";
        public IScreen HostScreen { get; }
        #endregion

        public ReadOnlyObservableCollection<Todo> Todos => _todosList;
        private readonly ReadOnlyObservableCollection<Todo> _todosList;

        // Объявляем изменяемый список задач
        private SourceList<Todo> _todos = new SourceList<Todo>();
        private ITodoService _todoService;
        public TodosVM(IScreen screen = null, ITodoService todoService = null)
        {
            Title = "Задачи";
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _todoService = todoService ?? Locator.Current.GetService<ITodoService>();
            //_todos = taskList;
            //_todos.Connect().Bind(out _todosList).Subscribe();
            _todos.AddRange(_todoService.GetTodosAsync().Result);
            _todos
                // Трансформируем источник в наблюдаемый набор изменений.
                // Имеем тип IObservable<IChangeSet<Trade, long>>
                .Connect()
                // Привяжем список объектов
                // к коллекции из System.Collections.ObjectModel.
                .Bind(out _todosList).Subscribe();
            Debug.WriteLine(Todos);
            Debug.WriteLine("Todos page");
        }
    }
}
