using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public interface ITodoService
    {
        Task<bool> AddTodoAsync(Models.Todo item);
        Task<bool> UpdateItemAsync(Models.Todo item);
        Task<bool> DeleteItemAsync(string id);
        Task<Models.Todo> GetTodoByIdAsync(string id);
        Task<IEnumerable<Models.Todo>> GetTodosAsync();
    }
}
