using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;

namespace ReactiveApp.ViewModels
{
    public class TodosVM : ReactiveObject, IRoutableViewModel
    {
        #region Navigation
        public string UrlPathSegment => "TodosPage";
        public IScreen HostScreen { get; }
        #endregion

        #region Props
        private readonly ReadOnlyObservableCollection<Todo> _todosList;
        public ReadOnlyObservableCollection<Todo> Todos => _todosList;
        private SourceList<Todo> _todos =  new SourceList<Todo>();
        #endregion

        private ITodoService _todoService;
        public TodosVM(IScreen screen = null, ITodoService todoService = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _todoService = todoService ?? Locator.Current.GetService<ITodoService>();
            _todos.AddRange(_todoService.GetAllTodosAsync());
            _todos.Connect().Bind(out _todosList).Subscribe();
        }
    }
}
