using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using courseProject.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace courseProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ValidLengthClass]
        [Remote(action: "Create", controller: "UserController")]
        public string Login { get; set; }
        [Required]
        [StringLength(99)]
        public string Password { get; set; }
        [Required]
        [StringLength(99)]
        public string Full_Name { get; set; }

        
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role User_Role { get; set; }

        public List<User_Answers> User_Answers { get; set; }
        public List<User_Therapy> User_Therapies { get; set; }
    }
}
