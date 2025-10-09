using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;


namespace Vask_En_Tid_Library.IRepos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookingRepo
    {

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void CreateBooking(Booking booking);


        /// <summary>
        /// Deletes the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void DeleteBooking(int bookingId);

        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        public void UpdateBooking(Booking booking);

        /// <summary>
        /// Gets all bookings.
        /// </summary>
        public List<Booking> GetAllBookings();



    }
}
