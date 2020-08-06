using ReactiveApp.Services.Todo;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System;
using Xamarin.Forms;

namespace ReactiveApp.ViewModels
{
    public class BaseVM : ReactiveObject, IValidatableViewModel
    {
        public ValidationContext ValidationContext => new ValidationContext();
        public ITodoService TodoService => DependencyService.Get<TodoService>();
        [Reactive] public bool IsBusy { get; set; }
        [Reactive] public string Title { get; set; } = string.Empty;
        protected IObservable<bool> NotBusyObservable { get; private set; }
        public BaseVM()
        {
            NotBusyObservable = this.WhenAnyValue(vm => vm.IsBusy, IsBusy => !IsBusy);
        }
    }
}
