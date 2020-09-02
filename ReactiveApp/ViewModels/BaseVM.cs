using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System;

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
        }
    }
}
