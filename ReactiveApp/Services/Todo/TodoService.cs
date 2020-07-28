using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactiveApp.Services.Todo
{
    public class TodoService : ITodoService
    {
        public IEnumerable<Models.Todo> GetAllTodosAsync()
        {
            //await Task.Delay(2000);
            IEnumerable<Models.Todo> todos = new List<Models.Todo>()
            {
                new Models.Todo{Id=1,CreatedAt = DateTime.Now, Description="Decs_1",Title="Sleep",IsComplete = false},
                new Models.Todo{Id=2,CreatedAt = DateTime.Now, Description="Decs_2",Title="Buy milk",IsComplete = false},
                new Models.Todo{Id=3,CreatedAt = DateTime.Now, Description="Decs_3",Title="Go to shop",IsComplete = true},
                new Models.Todo{Id=4,CreatedAt = DateTime.Now, Description="Decs_4",Title="Play in Dark Souls",IsComplete = true},
                new Models.Todo{Id=5,CreatedAt = DateTime.Now, Description="Decs_5",Title="Complete first task",IsComplete = false},
                new Models.Todo{Id=6,CreatedAt = DateTime.Now, Description="Decs_6",Title="Sleep",IsComplete = false},
                new Models.Todo{Id=7,CreatedAt = DateTime.Now, Description="Decs_7",Title="Buy milk",IsComplete = false},
                new Models.Todo{Id=8,CreatedAt = DateTime.Now, Description="Decs_8",Title="Go to shop",IsComplete = true},
                new Models.Todo{Id=9,CreatedAt = DateTime.Now, Description="Decs_9",Title="Play in Dark Souls",IsComplete = true},
                new Models.Todo{Id=10,CreatedAt = DateTime.Now, Description="Decs_10",Title="Complete first task",IsComplete = false},
            };
            return todos;
        }
    }
}
