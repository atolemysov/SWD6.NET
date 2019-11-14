using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace courseProject.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Role_Name { get; set; }
        public List<User> Users { get; set; }
    }
}
