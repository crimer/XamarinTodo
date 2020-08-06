using ReactiveApp.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ReactiveApp.Controls.Search
{
    public class ObjectSearchHandler : SearchHandler
    {
        public IEnumerable<Todo> Todos { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = Todos.Where(todo => todo.Title.ToLower().Contains(newValue.ToLower()));
            }
            else
            {
                ItemsSource = null;
            }
        }
    }
}
