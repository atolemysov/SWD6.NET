using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace firstProject.Models.Movies
{
    public class Movie
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Display(Name = "Url to poster")]
        public string Poster { get; set; }

        [Display(Name = "Duration in minutes")]
        public int DurationInMinutes { get; set; }

        //[Display(Name = "List of rating")]
        //public List<Rating> Ratings { get; set; }

    }
}
