using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Vask_En_Tid_Library.IRepos.IApartmentRepo" />
    public class ApartmentRepo : IApartmentRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApartmentRepo" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ApartmentRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates the apartment.
        /// </summary>
        /// <param name="apartment">The apartment.</param>
        public void CreateApartment(Apartment apartment)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "INSERT INTO Apartment (FloorNumber, ApartmentCode) VALUES (@FloorNumber, @ApartmentCode)",
                connection);

       
            command.Parameters.AddWithValue("@FloorNumber", apartment.Number); 
            command.Parameters.AddWithValue("@ApartmentCode", apartment.ApartmentCode);

            connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
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

        /// <summary>
        /// Gets all apartments.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the apartment.
        /// </summary>
        /// <param name="apartment">The apartment.</param>
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