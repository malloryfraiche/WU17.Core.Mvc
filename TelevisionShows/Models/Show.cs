using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelevisionShows.Models
{
    public class Show
    {
        public string Name { get; set; }
        public double ImdbRating { get; set; }

        public static List<Show> GetShows()
        {
            Show ray = new Show { Name = "Ray Donovan", ImdbRating = 8.3 };
            var animal = new Show { Name = "Animal Kingdom", ImdbRating = 8.1 };
            var someShow = new Show { Name = null, ImdbRating = 5.0 };

            return new List<Show> { ray, animal, null, someShow };
        }
    }
}
