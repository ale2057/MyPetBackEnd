﻿namespace MyPetBackEnd.Connection
{
    public class ConnectionDB
    {
        private string connectionString = string.Empty;
        public ConnectionDB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:MySqlConnection").Value;
        }

        public string SqlString()
        {
            return connectionString;
        }
    }
}
