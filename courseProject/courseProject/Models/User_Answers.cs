using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseProject.Models
{
    public class User_Answers
    {
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

        public string Answer { get; set; }
    }
}
