using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using courseProject.Utilities;

namespace courseProject.Models
{
    public class Survey : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        public int Min { get; set; }
        public string Desc1 { get; set; }

        //[ValidLengthClass(v: "10", ErrorMessage = "Max value must be equal to 10!!!")] -> Custom attribute validation
        public int Max { get; set; }

        public string Desc2 { get; set; }

        public int TherapyId { get; set; }
        [ForeignKey("TherapyId")]
        public Therapy Survey_Therapy { get; set; }

        public List<User_Answers> User_Answers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Max > 10 || Max < 1)
            {
                yield return new ValidationResult(
                    $"Max value must be equal to 10!!! {Max}.",
                    new[] { "ReleaseDate" });
            }
        }
    }

}
