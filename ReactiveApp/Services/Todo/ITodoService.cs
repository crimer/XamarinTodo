using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public interface ITodoService
    {
        Task<bool> AddTodoAsync(Models.Todo todo);
        Task<bool> UpdateTodoAsync(Models.Todo todo);
        Task<bool> DeleteTodoAsync(string id);
        Task<Models.Todo> GetTodoByIdAsync(string id);
        Task<IEnumerable<Models.Todo>> GetTodosAsync(bool forceRefresh = false);
    }
}
