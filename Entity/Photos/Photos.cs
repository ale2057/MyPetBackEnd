using System.Data.Common;

namespace MyPetBackEnd.Entity.Photos
{
    public class Photos
    {
        public int PhotoId { get; set; }

        public string PetPhoto { get; set; }

        public int PetId { get; set; }
    }
}
