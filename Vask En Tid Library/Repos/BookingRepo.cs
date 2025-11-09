using Microsoft.Data.SqlClient;
using System.Data;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repos
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Vask_En_Tid_Library.IRepos.IBookingRepo" />
    public class BookingRepo : IBookingRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRepo"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public BookingRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        public void CreateBooking(Booking booking)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO Booking (TenantId, MachineId, BookingDate, TimeslotId, IsCancelled)
                VALUES (@tenant, @machine, @date, @slot, 0);", con);

            cmd.Parameters.Add("@tenant", SqlDbType.Int).Value = booking.TenantId;
            cmd.Parameters.Add("@machine", SqlDbType.Int).Value = booking.MachineId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = booking.BookingDate.Date;
            cmd.Parameters.Add("@slot", SqlDbType.Int).Value = booking.TimeslotId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void DeleteBooking(int bookingId)
        {
           
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM Booking WHERE BookingId = @id;",
                con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = bookingId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        public void UpdateBooking(Booking booking)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                UPDATE Booking
                SET TenantId = @tenant,
                    MachineId = @machine,
                    BookingDate = @date,
                    TimeslotId = @slot,
                    IsCancelled = @cancelled
                WHERE BookingId = @id;", con);

            cmd.Parameters.Add("@tenant", SqlDbType.Int).Value = booking.TenantId;
            cmd.Parameters.Add("@machine", SqlDbType.Int).Value = booking.MachineId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = booking.BookingDate.Date;
            cmd.Parameters.Add("@slot", SqlDbType.Int).Value = booking.TimeslotId;
            cmd.Parameters.Add("@cancelled", SqlDbType.Bit).Value = booking.IsCancelled;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = booking.BookingId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetAll()
        {
            var list = new List<Booking>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
        SELECT
            b.BookingId,
            b.TenantId,
            b.MachineId,
            b.BookingDate,
            b.TimeslotId,
            b.IsCancelled,

            t.FirstName,
            t.LastName,

            a.ApartmentId,
            a.FloorNumber,
            a.ApartmentCode,

            ts.SlotName
            -- hvis du HAR en Unit/Machine-tabel, kan du også tage den med:
            -- , u.MachineType
        FROM Booking b
        INNER JOIN Tenant t      ON b.TenantId = t.TenantId
        INNER JOIN Apartment a   ON t.ApartmentId = a.ApartmentId
        INNER JOIN Timeslot ts   ON b.TimeslotId = ts.TimeslotId
        -- LEFT JOIN Unit u        ON b.MachineId = u.MachineId   -- kun hvis tabellen findes
        ORDER BY b.BookingDate, b.TimeslotId;
    ", con);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var booking = new Booking
                {
                    BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                    TenantId = reader.GetInt32(reader.GetOrdinal("TenantId")),
                    MachineId = reader.GetInt32(reader.GetOrdinal("MachineId")),
                    BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                    TimeslotId = reader.GetInt32(reader.GetOrdinal("TimeslotId")),
                    IsCancelled = reader.GetBoolean(reader.GetOrdinal("IsCancelled")),

                    Tenant = new Tenant
                    {
                        TenantID = reader.GetInt32(reader.GetOrdinal("TenantId")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName"))
                    },
                    Apartment = new Apartment
                    {
                        ApartmentId = reader.GetInt32(reader.GetOrdinal("ApartmentId")),
                      
                        Number = reader.GetInt32(reader.GetOrdinal("FloorNumber")),
                        ApartmentCode = reader.GetString(reader.GetOrdinal("ApartmentCode"))
                    },
                    Timeslot = new Timeslot
                    {
                        TimeslotId = reader.GetInt32(reader.GetOrdinal("TimeslotId")),
                        SlotName = reader.GetString(reader.GetOrdinal("SlotName"))
                    }
                   
                };

                list.Add(booking);
            }

            return list;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns></returns>
        public Booking GetById(int bookingId)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                SELECT BookingId, TenantId, MachineId, BookingDate, TimeslotId, IsCancelled
                FROM Booking
                WHERE BookingId = @id;", con);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = bookingId;

            con.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Booking
                {
                    BookingId = reader.GetInt32(0),
                    TenantId = reader.GetInt32(1),
                    MachineId = reader.GetInt32(2),
                    BookingDate = reader.GetDateTime(3),
                    TimeslotId = reader.GetInt32(4),
                    IsCancelled = reader.GetBoolean(5)
                };
            }
            return null;
        }

        /// <summary>
        /// Gets the upcoming.
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetUpcoming()
        {
            var list = new List<Booking>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                SELECT BookingId, TenantId, MachineId, BookingDate, TimeslotId, IsCancelled
                FROM Booking
                WHERE BookingDate >= CAST(GETDATE() AS date)
                ORDER BY BookingDate, TimeslotId;", con);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Booking
                {
                    BookingId = reader.GetInt32(0),
                    TenantId = reader.GetInt32(1),
                    MachineId = reader.GetInt32(2),
                    BookingDate = reader.GetDateTime(3),
                    TimeslotId = reader.GetInt32(4),
                    IsCancelled = reader.GetBoolean(5)
                });
            }

            return list;
        }

        /// <summary>
        /// Tenants the has booking.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        public bool TenantHasBooking(int tenantId, DateTime bookingDate, int timeslotId)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Booking
                WHERE TenantId = @tenant
                  AND BookingDate = @date
                  AND TimeslotId = @slot
                  AND IsCancelled = 0;", con);

            cmd.Parameters.Add("@tenant", SqlDbType.Int).Value = tenantId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = bookingDate.Date;
            cmd.Parameters.Add("@slot", SqlDbType.Int).Value = timeslotId;

            con.Open();
            var count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        /// <summary>
        /// Machines the is booked.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        public bool MachineIsBooked(int machineId, DateTime bookingDate, int timeslotId)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Booking
                WHERE MachineId = @machine
                  AND BookingDate = @date
                  AND TimeslotId = @slot
                  AND IsCancelled = 0;", con);

            cmd.Parameters.Add("@machine", SqlDbType.Int).Value = machineId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = bookingDate.Date;
            cmd.Parameters.Add("@slot", SqlDbType.Int).Value = timeslotId;

            con.Open();
            var count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        /// <summary>
        /// Gets the booked machine ids.
        /// </summary>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        public List<int> GetBookedMachineIds(DateTime bookingDate, int timeslotId)
        {
            var list = new List<int>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
        SELECT MachineId
        FROM Booking
        WHERE BookingDate = @date
          AND TimeslotId = @slot
          AND IsCancelled = 0;", con);

            cmd.Parameters.AddWithValue("@date", bookingDate.Date);
            cmd.Parameters.AddWithValue("@slot", timeslotId);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }

            return list;
        }
    }
}