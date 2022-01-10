using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Model
{
    public class Movie


    {
        public Movie(string error)
        {
            Title = error;
        }

        public Movie()
        { }
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
