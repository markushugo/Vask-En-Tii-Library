using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BookingService
    {
        /// <summary>
        /// The booking repo
        /// </summary>
        private readonly IBookingRepo _bookingRepo;
        /// <summary>
        /// The booking
        /// </summary>
        private Booking _booking;

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void CreateBooking(Booking booking)
        {
            _bookingRepo.CreateBooking(booking);
        }
        /// <summary>
        /// Deletes the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void DeleteBooking(int bookingId)
        {
            _bookingRepo.DeleteBooking(bookingId);
        }
        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void UpdateBooking(Booking booking)
        {
            _bookingRepo.UpdateBooking(booking);
        }
        /// <summary>
        /// Gets all bookings.
        /// </summary>
        public void GetAll()
        {
            _bookingRepo.GetAll();
        }

        public List<Booking> GetUpcoming()
        {
            var allBookings = _bookingRepo.GetAll();
            var upcomingBookings = allBookings.Where(b => b.BookingDate >= DateTime.Today).ToList();
            return upcomingBookings;

        }

        public int CountBookings(DateTime bookingDate, TimeSpan bookingTime, string machineType)
        {
            return _bookingRepo.CountBookings(bookingDate, bookingTime, machineType);

        }

    }
}
