using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public interface ITodoService
    {
        IEnumerable<Models.Todo> GetAllTodosAsync();
    }
}
