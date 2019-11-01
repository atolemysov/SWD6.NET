using System;
namespace courseProject.Models
{
    public class User_Answers
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string Answer { get; set; }
    }
}
