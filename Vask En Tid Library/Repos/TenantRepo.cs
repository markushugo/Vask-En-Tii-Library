using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;



namespace Vask_En_Tid_Library.Repos
{
    public class TenantRepo : ITenantRepo
    {

        private string _connectionString = "Default";
        public TenantRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Tenant> GetAll()
        {
            var tenants = new List<Tenant>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT TenantId, Firstname, LastName FROM Tenant", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tenant = new Tenant
                        {
                            TenantID = (int)reader["TenantId"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };
                        tenants.Add(tenant);
                    }
                }
            }
            return tenants;
        }

        public Tenant GetById(int tenantId)
        {
            Tenant tenant = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT TenantId, FirstName, LastName FROM Tenant WHERE TenantId = @TenantID", connection);
                command.Parameters.AddWithValue("@TenantID", tenantId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tenant = new Tenant
                        {
                            TenantID = (int)reader["TenantId"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };
                    }
                }
            }
            return tenant;
        }

        public void CreateTenant(Tenant tenant)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(

                "INSERT INTO Tenant (FirstName, LastName) VALUES (@FirstName, @LastName)",
                connection);
            command.Parameters.AddWithValue("@FirstName", tenant.FirstName);
            command.Parameters.AddWithValue("@LastName", tenant.LastName);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateTenant(Tenant tenant)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Tenant SET FirstName = @FirstName, LastName = @LastName WHERE TenantId = @TenantID",
                connection);

            command.Parameters.AddWithValue("@FirstName", tenant.FirstName);
            command.Parameters.AddWithValue("@LastName", tenant.LastName);
            command.Parameters.AddWithValue("@TenantID", tenant.TenantID); 

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteTenant(int tenantId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Tenant WHERE TenantId = @TenantID", connection);
            command.Parameters.AddWithValue("@TenantID", tenantId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}


