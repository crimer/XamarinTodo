using DynamicData;
using ReactiveApp.Models;
using ReactiveApp.Services.Todo;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReactiveApp.ViewModels
{
    public class TodosVM : BaseVM
    {
        SourceList<Todo> _todos;
        public ObservableCollection<Todo> Todos { get; set; }
        public ICommand LoadItemsCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddNewItemCommand { get; private set; }

        public TodosVM()
        {
            Title = "Задачи";
            Todos = new ObservableCollection<Todo>();
            LoadItemsCommand = ReactiveCommand.CreateFromTask(ExecuteLoadItemsCommand, NotBusyObservable);
            DeleteCommand = ReactiveCommand.CreateFromTask<Todo>(ExecuteDeleteItem, NotBusyObservable);
            AddNewItemCommand = ReactiveCommand.CreateFromTask(ExecuteAddNewItem);
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Todos.Clear();
                var items = TodoService.GetTodosAsync(true);
                foreach (var item in items)
                {
                    Todos.Add(item);
                }
                _todos = new SourceList<Todo>(Todos.ToObservable().ToObservableChangeSet());
                //Observe when a list's item value changed
                var itemChangeObservable = _todos.Connect().WhenValueChanged(todo => todo.Completed);
                //Observe when a list's item property changed
                //Add the autorefresh to observe everytime the property changes value
                var completedPropertyChangeObservable = _todos.Connect().AutoRefresh(t => t.Completed).WhenPropertyChanged(todo => todo.Completed);
                completedPropertyChangeObservable.Subscribe(async observer =>
                {
                    var item = observer.Sender;
                    var completed = observer.Value;
                    if (completed)
                    {
                        IsBusy = true;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        Todos.Remove(item);
                        IsBusy = false;
                    }
                });
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ExecuteDeleteItem(Todo todo)
        {
            // Call an interaction to confirm item deletion
            var result = await DeleteItemInteraction.Handle(this);
            if (result)
            {
                IsBusy = true;
                await Task.Delay(TimeSpan.FromSeconds(2));
                Todos.Remove(todo);
            }

            IsBusy = false;
        }
        private async Task ExecuteAddNewItem()
        {

        }
    }
}
