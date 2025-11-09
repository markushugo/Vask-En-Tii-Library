using Microsoft.Data.SqlClient;
using System.Data;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Vask_En_Tid_Library.IRepos.IUnitRepo" />
    public class UnitRepo : IUnitRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitRepo"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public UnitRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void CreateUnit(Unit unit)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Unit (MachineType, IsAvailable) VALUES (@type, @available);",
                con);

            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 255).Value = unit.MachineType;
            cmd.Parameters.Add("@available", SqlDbType.Bit).Value = unit.IsAvailable;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        public void DeleteUnit(int machineId)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM Unit WHERE MachineId = @id;", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = machineId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(Unit unit)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "UPDATE Unit SET MachineType = @type, IsAvailable = @available WHERE MachineId = @id;",
                con);

            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 255).Value = unit.MachineType;
            cmd.Parameters.Add("@available", SqlDbType.Bit).Value = unit.IsAvailable;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = unit.MachineId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets all units.
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetAllUnits()
        {
            var list = new List<Unit>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT MachineId, MachineType, IsActive FROM Machine;", con);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Unit
                {
                    MachineId = reader.GetInt32(reader.GetOrdinal("MachineId")),
                    MachineType = reader.GetString(reader.GetOrdinal("MachineType")),
                    IsAvailable = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                });
            }

            return list;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <returns></returns>
        public Unit GetById(int machineId)
        {
            Unit unit = null;

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT MachineId, MachineType, IsAvailable FROM Unit WHERE MachineId = @id;",
                con);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = machineId;

            con.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                unit = new Unit
                {
                    MachineId = reader.GetInt32(reader.GetOrdinal("MachineId")),
                    MachineType = reader.GetString(reader.GetOrdinal("MachineType")),
                    IsAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                };
            }

            return unit;
        }
    }
}