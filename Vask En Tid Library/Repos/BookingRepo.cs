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
        private string _connectionString = "Default";

        public List<Booking> _bookings;

        private static readonly Dictionary<string, int> _caps =
        new(StringComparer.OrdinalIgnoreCase)
        { ["Washer"] = 3, ["Dryer"] = 2, ["Roller"] = 1 };

        public BookingRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateBooking(Booking booking)
        {

            using var connection = new SqlConnection(_connectionString);
            if (!_caps.TryGetValue(booking.MachineType, out var max))
                throw new ArgumentException("Ukendt MachineType. Tilladt: Washer, Dryer, Roller.");

            using var con = new SqlConnection(_connectionString);
            con.Open();

            using var tx = con.BeginTransaction();

            const string countSql = @"
            SELECT COUNT(*)
            FROM Booking WITH (UPDLOCK, HOLDLOCK)
            WHERE BookingDate = @BookingDate
            AND BookingTime = @BookingTime
            AND MachineType = @MachineType
            AND IsBooked = 1;";

            using (var countCmd = new SqlCommand(countSql, con, tx))
            {
                countCmd.Parameters.Add("@BookingDate", SqlDbType.Date).Value = booking.BookingDate.Date;
                countCmd.Parameters.Add("@BookingTime", SqlDbType.Time).Value = booking.BookingTime; // TimeSpan
                countCmd.Parameters.Add("@MachineType", SqlDbType.NVarChar, 20).Value = booking.MachineType;

                var used = (int)countCmd.ExecuteScalar()!;
                if (used >= max)
                {
                    tx.Rollback();
                    throw new InvalidOperationException("Ingen ledige maskiner af den type på det tidspunkt.");
                }
            }

            const string insertSql = @"
            INSERT INTO Booking (BookingTime, BookingDate, IsBooked, MachineType)
            VALUES (@BookingTime, @BookingDate, 1, @MachineType);";

            using (var ins = new SqlCommand(insertSql, con, tx))
            {
                ins.Parameters.Add("@BookingTime", SqlDbType.Time).Value = booking.BookingTime;
                ins.Parameters.Add("@BookingDate", SqlDbType.Date).Value = booking.BookingDate.Date;
                ins.Parameters.Add("@MachineType", SqlDbType.NVarChar, 20).Value = booking.MachineType;
                ins.ExecuteNonQuery();
            }

            tx.Commit();

        }
        public void DeleteBooking(int bookingId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                    "DELETE FROM Booking WHERE BookingId = @Bookingid", connection);
            command.Parameters.Add("@Bookingid", SqlDbType.Int).Value = bookingId;

            connection.Open();
            command.ExecuteNonQuery();
        }

        public int CountBookings(DateTime bookingDate, TimeSpan bookingTime, string machineType)
        {
            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
            SELECT COUNT(*)
            FROM Booking
            WHERE MachineType=@type AND BookingDate=@BookingDate AND BookingTime=@BookingTime AND IsBooked=1;", con);
            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = machineType;
            cmd.Parameters.Add("@BookingDate", SqlDbType.Date).Value = bookingDate.Date;
            cmd.Parameters.Add("@BookingTime", SqlDbType.Time).Value = bookingTime;
            con.Open();
            return (int)cmd.ExecuteScalar()!;
        }

        public void UpdateBooking(Booking booking)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Booking SET BookingTime = @BookingTime, BookingDate = @BookingDate, IsBooked = @IsBooked, @MachineType = MachineType WHERE BookingId = @BookingId",
                connection);

            command.Parameters.AddWithValue("@BookingTime", booking.BookingTime);
            command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
            command.Parameters.AddWithValue("@IsBooked", booking.BookingId);
            command.Parameters.AddWithValue("@MachineType", booking.MachineType);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Booking> GetUpcoming()
        {
            var bookings = new List<Booking>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(@"
            SELECT BookingId, BookingTime, BookingDate, MachineType, IsBooked
            FROM Booking
            WHERE BookingDate >= CAST(GETDATE() AS date)
            ORDER BY BookingDate, BookingTime;", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read()) {  }
            return bookings;
        }
        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();

            using var con = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
            SELECT BookingId, BookingTime, BookingDate, MachineType, IsBooked
            FROM Booking
            ORDER BY BookingDate, BookingTime, MachineType;", con);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bookings.Add(new Booking
                {
                    BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                    BookingTime = reader.GetTimeSpan(reader.GetOrdinal("BookingTime")),
                    BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                    MachineType = reader.GetString(reader.GetOrdinal("MachineType")),
                    IsBooked = reader.GetBoolean(reader.GetOrdinal("IsBooked"))
                });
            }

            return bookings;   // <- VIGTIGT: returnér den lokale liste
        }

        public Booking GetById(int bookingId)
        {
            Booking booking = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT BookingTime, BookingDate, IsBooked, MachineType FROM Booking WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        booking = new Booking
                        {
                            BookingTime = (TimeSpan)reader["BookingTime"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            IsBooked = (bool)reader["IsBooked"],
                            MachineType = (string)reader["MachineType"]
                        };
                    }
                }
            }
            return booking;
        }

    }
}
