using System.ComponentModel.DataAnnotations;

namespace MyPetBackEnd.Entity.Pets.Dto
{
    public class UpdatePetDto
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Breed { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Gender { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Family { get; set; }

        [Required]
        public float Size { get; set; }

        [Required]
        public string Personality { get; set; }

        [Required]
        public string Health { get; set; }

        [Required]
        public string Story { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string City { get; set; }
        public Boolean Adopted { get; set; }
    }
}
