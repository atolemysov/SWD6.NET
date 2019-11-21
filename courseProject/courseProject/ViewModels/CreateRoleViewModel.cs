using System;
using System.ComponentModel.DataAnnotations;

namespace courseProject.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Role_Name { get; set; }
    }
}
