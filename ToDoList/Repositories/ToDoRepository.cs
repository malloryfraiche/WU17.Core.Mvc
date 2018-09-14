using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    // Creating this Repository class to save the information that the user has entered in the Create New ToDo form.
    public static class ToDoRepository
    {
        private static List<ToDo> _toDos = new List<ToDo>();

        public static IEnumerable<ToDo> ToDos
        {
            get { return _toDos; }
        }

        // Here is where we take the entered To Do from the user (toDo) and add it to the list we created above.
        public static void AddToDo (ToDo toDo)
        {
            _toDos.Add(toDo);
        }

    }
}
