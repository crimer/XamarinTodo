using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public interface ITodoService
    {
<<<<<<< HEAD
        Task<bool> AddTodoAsync(Models.Todo item);
        Task<bool> UpdateItemAsync(Models.Todo item);
        Task<bool> DeleteItemAsync(string id);
        Task<Models.Todo> GetTodoByIdAsync(string id);
        Task<IEnumerable<Models.Todo>> GetTodosAsync();
=======
        Task<bool> AddTodoAsync(Models.Todo todo);
        Task<bool> UpdateTodoAsync(Models.Todo todo);
        Task<bool> DeleteTodoAsync(string id);
        Task<Models.Todo> GetTodoByIdAsync(string id);
        Task<IEnumerable<Models.Todo>> GetTodosAsync(bool forceRefresh = false);
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
    }
}
