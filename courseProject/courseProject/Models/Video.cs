using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courseProject.Models
{
    public class Video
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(199)]
        public string Desc { get; set; }
        [Required]
        public string Url_Video { get; set; }

        public string TherapyId { get; set; }
        [ForeignKey("TherapyId")]
        public Therapy Video_Therapy { get; set; }
    }
     
}

