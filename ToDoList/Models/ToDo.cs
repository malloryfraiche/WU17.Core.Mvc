using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a priority.")]
        public int Priority { get; set; }


        public bool Done { get; set; }

        // Define the DataType so we can get the right format in the html.
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
    }
}
