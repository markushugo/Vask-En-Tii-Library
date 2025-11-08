using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
 
    public class BookingService
    {
        private readonly IBookingRepo _bookingRepo;

   
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void CreateBooking(Booking booking)
        {
      
            if (_bookingRepo.TenantHasBooking(booking.TenantId, booking.BookingDate, booking.TimeslotId))
                throw new InvalidOperationException("Du har allerede en booking i dette tidsrum.");

          
            if (_bookingRepo.MachineIsBooked(booking.MachineId, booking.BookingDate, booking.TimeslotId))
                throw new InvalidOperationException("Maskinen er allerede booket i dette tidsrum.");

            _bookingRepo.CreateBooking(booking);
        }

        public void DeleteBooking(int bookingId)
        {
            _bookingRepo.DeleteBooking(bookingId);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepo.UpdateBooking(booking);
        }

      
        public List<Booking> GetAll()
        {
            return _bookingRepo.GetAll();
        }

        public List<Booking> GetUpcoming()
        {
           
            var all = _bookingRepo.GetAll();
            return all.Where(b => b.BookingDate >= DateTime.Today).ToList();
        }

        
        public bool MachineIsBooked(int machineId, DateTime bookingDate, int timeslotId)
        {
            return _bookingRepo.MachineIsBooked(machineId, bookingDate, timeslotId);
        }

        public bool TenantHasBooking(int tenantId, DateTime bookingDate, int timeslotId)
        {
            return _bookingRepo.TenantHasBooking(tenantId, bookingDate, timeslotId);
        }
    }
}
