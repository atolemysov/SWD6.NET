using System;
namespace courseProject.Models
{
    public class User_Therapy
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public int TherapyId { get; set; }
        public Therapy Therapy { get; set; }
    }
}
