using System.ComponentModel.DataAnnotations;

namespace MyPetBackEnd.Entity.Photos.Dto
{
    public class CreatePhotoDto
    {
        [Required]
        public string PetPhoto { get; set; }

        [Required]
        public int PetId { get; set; }
    }
}
