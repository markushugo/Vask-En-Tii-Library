using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Vask_En_Tid_Library.IRepos.ITimeslotRepo" />
    public class TimeslotRepo : ITimeslotRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeslotRepo"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public TimeslotRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Timeslot> GetAll()
        {
            var list = new List<Timeslot>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT TimeslotId, SlotName, StartTime, EndTime FROM Timeslot",
                con);

            con.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Timeslot
                {
                    TimeslotId = reader.GetInt32(reader.GetOrdinal("TimeslotId")),
                    SlotName = reader.GetString(reader.GetOrdinal("SlotName")),
                    StartTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime")),
                    EndTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime"))
                });
            }

            return list;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Timeslot GetById(int id)
        {
            Timeslot slot = null;

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT TimeslotId, SlotName, StartTime, EndTime FROM Timeslot WHERE TimeslotId = @id",
                con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                slot = new Timeslot
                {
                    TimeslotId = reader.GetInt32(reader.GetOrdinal("TimeslotId")),
                    SlotName = reader.GetString(reader.GetOrdinal("SlotName")),
                    StartTime = reader.GetTimeSpan(reader.GetOrdinal("StartTime")),
                    EndTime = reader.GetTimeSpan(reader.GetOrdinal("EndTime"))
                };
            }

            return slot;
        }
    }
}