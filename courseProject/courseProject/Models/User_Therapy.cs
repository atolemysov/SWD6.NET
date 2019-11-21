using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseProject.Models
{
    public class User_Therapy
    {
        //[Key]
        //public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string TherapyId { get; set; }
        [ForeignKey("TherapyId")]
        public Therapy Therapy { get; set; }
    }
}
