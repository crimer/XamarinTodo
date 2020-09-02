using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public class TodoService : ITodoService
    {
        readonly List<Models.Todo> _todos;
        public TodoService()
        {
            _todos = new List<Models.Todo>()
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

        public async Task<bool> AddTodoAsync(Models.Todo item)
        {
            _todos.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var todo = await GetTodoByIdAsync(id);
            _todos.Remove(todo);
            return await Task.FromResult(true);
        }

        public async Task<Models.Todo> GetTodoByIdAsync(string id)
        {
            var todo = _todos.Where(t => t.Id == id).FirstOrDefault();
            return await Task.FromResult(todo);
        }

        public async Task<IEnumerable<Models.Todo>> GetTodosAsync()
        {
            return await Task.FromResult(_todos);
        }

        public async Task<bool> UpdateItemAsync(Models.Todo newTodo)
        {
            var oldTodo = await GetTodoByIdAsync(newTodo.Id);
            _todos.Remove(oldTodo);
            _todos.Add(newTodo);
            return await Task.FromResult(true);
        }
    }
}
