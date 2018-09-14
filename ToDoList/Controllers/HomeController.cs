using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var dayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var message = string.Empty;
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                message = "Chill, it's the weekend!";
            }
            else
            {
                message = "Business as usual!";
            }
            ViewBag.Message = message;

            var p1 = new Person
            {
                FirstName = "Mallory",
                LastName = "Fraiche",
                Age = 101
            };
            ViewBag.Person = p1;

            return View("HomeView");
        }

        [HttpGet]
        public ViewResult NewToDo()
        {
            // Using this method when the user loads the site with the Create new ToDo form. HttpGet action happens. 
            return View();
        }

        [HttpPost]
        public ViewResult NewToDo(ToDo toDo)
        {
            // Here we have the logics to save/post the new todo entered but the user when they click a save button for example.

            if (ModelState.IsValid)
            {
                // Sending the users added info to our Repository.
                ToDoRepository.AddToDo(toDo);


                /* This is using View(string viewName, object model) two parameters.
                   First parameter = name of the view we want to show.
                   Second parameter = send the new To Do as the model to the view. */
                return View("ToDoAdded", toDo);
            }
            else
            {
                // Something is wrong with the model. Will return the original NewToDo.cshtml view.
                return View();
            }
        }

        public ViewResult AllToDos()
        {
            // Action method to get the list of all my ToDos entered and to return the view to see them. 

            var todos = ToDoRepository.ToDos;
            return View(todos);
        }

    }
}
