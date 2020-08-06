using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public class TodoService : ITodoService
    {
        private readonly List<Models.Todo> todos;
        public TodoService()
        {
            todos = new List<Models.Todo>()
            {
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_1",Title="Sleep",IsComplete = false},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_2",Title="Buy milk",IsComplete = false},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_3",Title="Go to shop",IsComplete = true},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_4",Title="Play in Dark Souls",IsComplete = true},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_5",Title="Complete first task",IsComplete = false},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_6",Title="Sleep",IsComplete = false},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_7",Title="Buy milk",IsComplete = false},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_8",Title="Go to shop",IsComplete = true},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_9",Title="Play in Dark Souls",IsComplete = true},
                new Models.Todo{Id=Guid.NewGuid().ToString(),CreatedAt = DateTime.Now, Description="Decs_10",Title="Complete first task",IsComplete = false},
            };
        }
        public async Task<bool> AddTodoAsync(Models.Todo todo)
        {
            todos.Add(todo);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTodoAsync(string id)
        {
            var item = await GetTodoByIdAsync(id);
            todos.Remove(item);
            return await Task.FromResult(true);
        }


        public async Task<Models.Todo> GetTodoByIdAsync(string id)
        {
            var item = todos.Where(t => t.Id == id).FirstOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Models.Todo>> GetTodosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(todos);
        }

        public async Task<bool> UpdateTodoAsync(Models.Todo newTodo)
        {
            var oldItem = await GetTodoByIdAsync(newTodo.Id);
            todos.Remove(oldItem);
            todos.Add(newTodo);
            return await Task.FromResult(true);
        }
    }
}
