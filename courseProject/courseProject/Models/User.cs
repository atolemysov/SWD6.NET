using System;
using System.Collections.Generic;

namespace courseProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
        public Role User_Role { get; set; }
        public List<User_Answers> User_Answers { get; set; }
        public List<User_Therapy> User_Therapies { get; set; }
    }
}
