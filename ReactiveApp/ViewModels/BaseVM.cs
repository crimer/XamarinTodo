<<<<<<< HEAD
﻿using ReactiveUI;
=======
﻿using ReactiveApp.Services.Todo;
using ReactiveUI;
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System;
<<<<<<< HEAD

namespace ReactiveApp.ViewModels
{
    public class BaseVM : ReactiveObject
    {
        [Reactive] public bool IsBusy { get; set; }
        [Reactive] public string Title { get; set; }
        protected IObservable<bool> NotBusyObservable { get; private set; }
        //public ValidationContext ValidationContext => throw new NotImplementedException();

        public BaseVM()
        {
            NotBusyObservable = this.WhenAnyValue(vm => vm.IsBusy, Isbusy => !Isbusy);
=======
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
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
        }
    }
}
