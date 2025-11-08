using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;


namespace Vask_En_Tid_Library.Repos
{
    public class ApartmentRepo : IApartmentRepo
    {
        private readonly string _connectionString;

        public ApartmentRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateApartment(Apartment apartment)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "INSERT INTO Apartment (FloorNumber, ApartmentCode) VALUES (@FloorNumber, @ApartmentCode)",
                connection);

            // hvis du ikke bruger FloorNumber kan du bare sætte 0
            command.Parameters.AddWithValue("@FloorNumber", apartment.Number); // eller apartment.FloorNumber hvis du har det
            command.Parameters.AddWithValue("@ApartmentCode", apartment.ApartmentCode);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteApartment(int apartmentId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Apartment WHERE ApartmentId = @ApartmentId",
                connection);
            command.Parameters.AddWithValue("@ApartmentId", apartmentId);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Apartment> GetAll()
        {
            var apartments = new List<Apartment>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT ApartmentId, FloorNumber, ApartmentCode FROM Apartment",
                connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                apartments.Add(new Apartment
                {
                    ApartmentId = (int)reader["ApartmentId"],
                    Number = (int)reader["FloorNumber"],
                    ApartmentCode = (string)reader["ApartmentCode"]
                });
            }

            return apartments;
        }

        public Apartment GetById(int apartmentId)
        {
            Apartment apartment = null;
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT ApartmentId, FloorNumber, ApartmentCode FROM Apartment WHERE ApartmentId = @ApartmentId",
                connection);
            command.Parameters.AddWithValue("@ApartmentId", apartmentId);

            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                apartment = new Apartment
                {
                    ApartmentId = (int)reader["ApartmentId"],
                    Number = (int)reader["FloorNumber"],
                    ApartmentCode = (string)reader["ApartmentCode"]
                };
            }

            return apartment;
        }

        public void UpdateApartment(Apartment apartment)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Apartment SET FloorNumber = @FloorNumber, ApartmentCode = @ApartmentCode WHERE ApartmentId = @ApartmentId",
                connection);

            command.Parameters.AddWithValue("@FloorNumber", apartment.Number);
            command.Parameters.AddWithValue("@ApartmentCode", apartment.ApartmentCode);
            command.Parameters.AddWithValue("@ApartmentId", apartment.ApartmentId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}





