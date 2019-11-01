using System;
using System.Collections.Generic;

namespace courseProject.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int Min { get; set; }
        public string Desc1 { get; set; }
        public int Max { get; set; }
        public string Desc2 { get; set; }
        public Therapy Survey_Therapy { get; set; }
        public List<User_Answers> User_Answers { get; set; }
    }

}
