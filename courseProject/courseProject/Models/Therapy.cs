using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace courseProject.Models
{
    public class Therapy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Therapy_Name { get; set; }

        public List<Survey> Surveys { get; set; }

        public List<Video> Videos { get; set; }

        public List<User_Therapy> User_Therapies { get; set; }
    }
}
