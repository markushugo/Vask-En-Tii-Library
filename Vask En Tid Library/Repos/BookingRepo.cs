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
        public List<Booking> _bookings;
        public BookingRepo() 
        {
            _bookings = new List<Booking>();
        }
        public void CreateBooking(Booking bookings)
        {
            _bookings.Add(bookings);
        }
        public void DeleteBooking(int bookingId)
        {
            _bookings.RemoveAt(bookingId);
            int n = 0;
            foreach (Booking booking in _bookings)
            {
                n++;
            }

            for (int i = 0; i < n; i++)
            {
                _bookings.RemoveAt(i);
            }
        }
        public void UpdateBooking(Booking booking)
        {
           
        }
        public List<Booking> GetAllBookings()
        {
            return _bookings;
        }




    }
}
