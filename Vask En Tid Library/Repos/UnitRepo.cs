using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    public class UnitRepo : IUnitRepo
    {
        private readonly string _connectionString;

        public UnitRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

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

        public void DeleteUnit(int machineId)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM Unit WHERE MachineId = @id;", con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = machineId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

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
