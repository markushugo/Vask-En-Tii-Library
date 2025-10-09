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
    public class BookingRepo : IBookingRepo
    {
        private string _connectionString = "Default";
        public List<Booking> _bookings;
        public BookingRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateBooking(Booking booking)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(

                "INSERT INTO Booking (BookingTime, BookingDate, IsBooked) VALUES (@BookingTime, @BookingDate, @IsBooked)",
                connection);
            command.Parameters.AddWithValue("@BookingTime", booking.BookingTime);
            command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
            command.Parameters.AddWithValue("IsBooked", booking.IsBooked);

            connection.Open();
            command.ExecuteNonQuery();
        }
        public void DeleteBooking(int bookingId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM Booking WHERE BookingId = @BookingId", connection);
            command.Parameters.AddWithValue("@BookingId", bookingId);

            connection.Open();
            command.ExecuteNonQuery();
        }
        public void UpdateBooking(Booking booking)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Booking SET BookingTime = @BookingTime, BookingDate = @BookingDate, IsBooked = @IsBooked WHERE BookingId = @BookingId",
                connection);

            command.Parameters.AddWithValue("@BookingTime", booking.BookingTime);
            command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
            command.Parameters.AddWithValue("@IsBooked", booking.BookingId);

            connection.Open();
            command.ExecuteNonQuery();
        }
        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT BookingId, BookingTime, BookingDate, IsBooked FROM Booking", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = new Booking
                        {
                            BookingId = (int)reader["BookingId"],
                            BookingTime = (DateTime)reader["BookingTime"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            IsBooked = (bool)reader["IsBooked"]
                        };
                        bookings.Add(booking);
                    }
                }
            }
            return _bookings;
        }

        public Booking GetById(int bookingId)
        {
            Booking booking = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT BookingTime, BookingDate, IsBooked FROM Booking WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        booking = new Booking
                        {
                            BookingTime = (DateTime)reader["BookingTime"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            IsBooked = (bool)reader["IsBooked"]
                        };
                    }
                }
            }
            return booking;
        }

    }
}
