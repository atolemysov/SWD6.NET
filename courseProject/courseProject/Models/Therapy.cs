using System;
using System.Collections.Generic;

namespace courseProject.Models
{
    public class Therapy
    {
        public int Id { get; set; }
        public string Therapy_Name { get; set; }
        public List<Survey> Surveys { get; set; }
        public List<Video> Videos { get; set; }
        public List<User_Therapy> User_Therapies { get; set; }
    }
}
