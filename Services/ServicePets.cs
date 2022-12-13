using MyPetBackEnd.Connection;
using MyPetBackEnd.Entity.Pets;
using MyPetBackEnd.Entity.Pets.Dto;
using MySql.Data.MySqlClient;

namespace MyPetBackEnd.Services
{
    public class ServicePets
    {
        ConnectionDB cn = new ConnectionDB();
        ServicePhotos servicePhoto = new ServicePhotos();

        public async Task<List<Pets>> GetPets()
        {
            var photosList = new List<Pets>();
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("SELECT * FROM Pet", sqlCon))
                {
                    await sqlCon.OpenAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var entityPets = new Pets();
                            entityPets.PetId = (int)item["PetId"];
                            entityPets.Name = (string)item["Name"];
                            entityPets.Breed = (string)item["Breed"];
                            entityPets.Gender = (string)item["Gender"];
                            entityPets.Family = (string)item["Family"];
                            entityPets.Size = (string)item["Size"];
                            entityPets.Personality = (string)item["Personality"];
                            entityPets.Health = (string)item["Health"];
                            entityPets.Story = (string)item["Story"];
                            entityPets.City = (string)item["City"];
                            entityPets.Adopted = (Boolean)item["Adopted"];
                            photosList.Add(entityPets);
                        }
                    }
                }
            }
            return photosList;
        }

        public async Task<Pets> GetOnePet(int id)
        {
            var petsList = new Pets();
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("SELECT * FROM Pet WHERE PetId=@id", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await sqlCon.OpenAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var entityPets = new Pets();
                            entityPets.PetId = (int)item["PetId"];
                            entityPets.Name = (string)item["Name"];
                            entityPets.Breed = (string)item["Breed"];
                            entityPets.Gender = (string)item["Gender"];
                            entityPets.Family = (string)item["Family"];
                            entityPets.Size = (string)item["Size"];
                            entityPets.Personality = (string)item["Personality"];
                            entityPets.Health = (string)item["Health"];
                            entityPets.Story = (string)item["Story"];
                            entityPets.City = (string)item["City"];
                            entityPets.Adopted = (Boolean)item["Adopted"];
                            petsList = entityPets;
                        }
                    }
                }
            }
            return petsList;
        }

        public async Task<long> AddPet(CreatePetDto createPetDto)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("INSERT INTO Pet (Name,Breed,Gender,Family,Size,Personality,Health,Story,City,Adopted)" +
                    " VALUES (@Name, @Breed, @Gender, @Family, @Size, @Personality, @Health, @Story, @City, @Adopted)", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Name", createPetDto.Name);
                    cmd.Parameters.AddWithValue("@Breed", createPetDto.Breed);
                    cmd.Parameters.AddWithValue("@Gender", createPetDto.Gender);
                    cmd.Parameters.AddWithValue("@Family", createPetDto.Family);
                    cmd.Parameters.AddWithValue("@Size", createPetDto.Size);
                    cmd.Parameters.AddWithValue("@Personality", createPetDto.Personality);
                    cmd.Parameters.AddWithValue("@Health", createPetDto.Health);
                    cmd.Parameters.AddWithValue("@Story", createPetDto.Story);
                    cmd.Parameters.AddWithValue("@City", createPetDto.City);
                    cmd.Parameters.AddWithValue("@Adopted", createPetDto.Adopted);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    long v = _ = cmd.LastInsertedId;
                    return v;
                }
            }
        }

        public async Task UpdatePet(int id, UpdatePetDto updatePetDto)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("UPDATE Pet SET" +
                    " Name=@Name" +
                    ", Breed=@Breed" +
                    ", Gender=@Gender" +
                    ", Family=@Family" +
                    ", Size=@Size" +
                    ", Personality=@Personality" +
                    ", Health=@Health" +
                    ", Story=@Story " +
                    ", City=@City " +
                    ", Adopted=@Adopted " +
                    "WHERE PetId=@PetId", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Name", updatePetDto.Name);
                    cmd.Parameters.AddWithValue("@Breed", updatePetDto.Breed);
                    cmd.Parameters.AddWithValue("@Gender", updatePetDto.Gender);
                    cmd.Parameters.AddWithValue("@Family", updatePetDto.Family);
                    cmd.Parameters.AddWithValue("@Size", updatePetDto.Size);
                    cmd.Parameters.AddWithValue("@Personality", updatePetDto.Personality);
                    cmd.Parameters.AddWithValue("@Health", updatePetDto.Health);
                    cmd.Parameters.AddWithValue("@Story", updatePetDto.Story);
                    cmd.Parameters.AddWithValue("@City", updatePetDto.City);
                    cmd.Parameters.AddWithValue("@Adopted", updatePetDto.Adopted);
                    cmd.Parameters.AddWithValue("@PetId", id);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePet(int id)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("DELETE FROM Pet WHERE PetId=@PetId", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@PetId", id);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await servicePhoto.DeletePhoto(id);
                }
            }
        }
    }
}
