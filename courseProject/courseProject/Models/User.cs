using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using courseProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace courseProject.Models
{
    public class User : IdentityUser
    {
        
        [StringLength(99)]
        public string Full_Name { get; set; }

        public List<User_Answers> User_Answers { get; set; }
        public List<User_Therapy> User_Therapies { get; set; }
    }
}
