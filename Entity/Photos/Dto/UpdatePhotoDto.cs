using System.ComponentModel.DataAnnotations;

namespace MyPetBackEnd.Entity.Photos.Dto
{
    public class UpdatePhotoDto
    {
        [Required]
        public string PetPhoto { get; set; }
    }
}
