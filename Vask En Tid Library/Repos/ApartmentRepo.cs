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
       

        private string _connectionString = "Default";
        public ApartmentRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateApartment(Apartment apartment)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(

                "INSERT INTO Apartment (Number, ApartmentCode) VALUES (@Number, @ApartmentCode)",
                connection);
            command.Parameters.AddWithValue("@Number", apartment.Number);
            command.Parameters.AddWithValue("@ApartmentCode", apartment.ApartmentCode);

            connection.Open();
            command.ExecuteNonQuery();

        }

        public void DeleteApartment(int apartmentId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Apartment WHERE ApartmentId = @ApartmentId", connection);
            command.Parameters.AddWithValue("@ApartmentId", apartmentId);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Apartment> GetAll()
        {
            var apartments = new List<Apartment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT ApartmentId, Number, ApartmentCode FROM Apartment", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var apartment = new Apartment
                        {
                            ApartmentId = (int)reader["ApartmentId"],
                            Number = (int)reader["Number"],
                            ApartmentCode = (int)reader["ApartmentCode"]
                        };
                        apartments.Add(apartment);
                    }
                }
            }
            return apartments;
        }

        public void UpdateApartment(Apartment apartment)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Apartment SET Number = @Number, ApartmentCode = @ApartmentCode WHERE ApartmentId = @ApartmentId",
                connection);

            command.Parameters.AddWithValue("@Number", apartment.Number);
            command.Parameters.AddWithValue("@ApartmentCode", apartment.ApartmentCode);
            command.Parameters.AddWithValue("@ApartmentId", apartment.ApartmentId);

            connection.Open();
            command.ExecuteNonQuery();

        }


        public Apartment GetById(int apartmentId)
        {
            Apartment apartment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT ApartmentId, Number, ApartmentCode FROM Apartment WHERE ApartmentId = @ApartmentId", connection);
                command.Parameters.AddWithValue("@ApartmentId", apartmentId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        apartment = new Apartment
                        {
                            ApartmentId = (int)reader["ApartmentId"],
                            Number = (int)reader["Number"],
                            ApartmentCode = (int)reader["ApartmentCode"]
                        };
                    }
                }
            }
            return apartment;
        }
    }



}

