using MyPetBackEnd.Connection;
using MyPetBackEnd.Entity.Photos;
using MyPetBackEnd.Entity.Photos.Dto;
using MySql.Data.MySqlClient;

namespace MyPetBackEnd.Services
{
    public class ServicePhotos
    {
        ConnectionDB cn = new ConnectionDB();
        public async Task<List<Photos>> GetPhotos()
        {
            var photosList = new List<Photos>();
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("SELECT * FROM Photos", sqlCon))
                {
                    await sqlCon.OpenAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var entityPhotos = new Photos();
                            entityPhotos.PhotoId = (int)item["PhotoId"];
                            entityPhotos.PetPhoto = (string)item["PetPhoto"];
                            entityPhotos.PetId = (int)item["PetId"];
                            photosList.Add(entityPhotos);
                        }
                    }
                }
            }
            return photosList;
        }

        public async Task<Photos> GetOnePhoto(int id)
        {
            var photosList = new Photos();
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("SELECT * FROM Photos WHERE PetId=@id", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await sqlCon.OpenAsync();
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var entityPhotos = new Photos();
                            entityPhotos.PhotoId = (int)item["PhotoId"];
                            entityPhotos.PetPhoto = (string)item["PetPhoto"];
                            entityPhotos.PetId = (int)item["PetId"];
                            photosList=entityPhotos;
                        }
                    }
                }
            }
            return photosList;
        }

        public async Task<long> AddPhoto(CreatePhotoDto createPhotoDto)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("INSERT INTO Photos (PetPhoto,PetId) VALUES (@PetPhoto, @PetId)", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@PetPhoto", createPhotoDto.PetPhoto);
                    cmd.Parameters.AddWithValue("@PetId", createPhotoDto.PetId);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    long v = _ = cmd.LastInsertedId;
                    return v;
                }
            }
        }

        public async Task UpdatePhoto(int id, UpdatePhotoDto updatePhotoDto)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("UPDATE Photos SET PetPhoto=@PetPhoto WHERE PetId=@PetId", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@PetPhoto", updatePhotoDto.PetPhoto);
                    cmd.Parameters.AddWithValue("@PetId", id);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePhoto(int id)
        {
            using (var sqlCon = new MySqlConnection(cn.SqlString()))
            {
                using (var cmd = new MySqlCommand("DELETE FROM Photos WHERE PetId=@PetId", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@PetId", id);
                    await sqlCon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
