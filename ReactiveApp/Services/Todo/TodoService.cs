using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public class TodoService : ITodoService
    {
<<<<<<< HEAD
        readonly List<Models.Todo> _todos;
        public TodoService()
        {
            _todos = new List<Models.Todo>()
=======
        private readonly List<Models.Todo> todos;
        public TodoService()
        {
            todos = new List<Models.Todo>()
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
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
<<<<<<< HEAD

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
=======
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
>>>>>>> 5e81c7cf63e07d3ae5ee97dc6b11a8aa55fd53e3
            return await Task.FromResult(true);
        }
    }
}
