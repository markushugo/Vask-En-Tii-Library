using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Vask_En_Tid_Library.IRepos.ITenantRepo" />
    public class TenantRepo : ITenantRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantRepo"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public TenantRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Tenant> GetAll()
        {
            var tenants = new List<Tenant>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT TenantId, FirstName, LastName, ApartmentId FROM Tenant",
                connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                tenants.Add(new Tenant
                {
                    TenantID = (int)reader["TenantId"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    ApartmentId = (int)reader["ApartmentId"]   
                });
            }

            return tenants;
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetById(int tenantId)
        {
            Tenant tenant = null;
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT TenantId, FirstName, LastName, ApartmentId FROM Tenant WHERE TenantId = @TenantId",
                connection);

            command.Parameters.AddWithValue("@TenantId", tenantId);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                tenant = new Tenant
                {
                    TenantID = (int)reader["TenantId"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    ApartmentId = (int)reader["ApartmentId"]
                };
            }

            return tenant;
        }

        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void CreateTenant(Tenant tenant)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "INSERT INTO Tenant (FirstName, LastName, ApartmentId) VALUES (@FirstName, @LastName, @ApartmentId)",
                connection);

            command.Parameters.AddWithValue("@FirstName", tenant.FirstName);
            command.Parameters.AddWithValue("@LastName", tenant.LastName);
            command.Parameters.AddWithValue("@ApartmentId", tenant.ApartmentId);

            connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void UpdateTenant(Tenant tenant)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Tenant SET FirstName = @FirstName, LastName = @LastName, ApartmentId = @ApartmentId WHERE TenantId = @TenantId",
                connection);

            command.Parameters.AddWithValue("@FirstName", tenant.FirstName);
            command.Parameters.AddWithValue("@LastName", tenant.LastName);
            command.Parameters.AddWithValue("@ApartmentId", tenant.ApartmentId);
            command.Parameters.AddWithValue("@TenantId", tenant.TenantID);

            connection.Open();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void DeleteTenant(int tenantId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Tenant WHERE TenantId = @TenantId",
                connection);

            command.Parameters.AddWithValue("@TenantId", tenantId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}