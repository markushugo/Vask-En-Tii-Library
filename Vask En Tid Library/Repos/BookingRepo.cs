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
    public class BookingRepo : IBookingRepo
    {
        private readonly string _connectionString;

        public BookingRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

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

        public void DeleteBooking(int bookingId)
        {
            // du kan også vælge at sætte IsCancelled = 1 i stedet
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM Booking WHERE BookingId = @id;",
                con);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = bookingId;

            con.Open();
            cmd.ExecuteNonQuery();
        }

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

        public List<Booking> GetAll()
        {
            var list = new List<Booking>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                SELECT BookingId, TenantId, MachineId, BookingDate, TimeslotId, IsCancelled
                FROM Booking
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
    }
}
