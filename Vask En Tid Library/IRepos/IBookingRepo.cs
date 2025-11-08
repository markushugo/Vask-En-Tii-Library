using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;


namespace Vask_En_Tid_Library.IRepos
{
   
       public interface IBookingRepo
        {
            // CRUD
            void CreateBooking(Booking booking);
            void DeleteBooking(int bookingId);
            void UpdateBooking(Booking booking);
            List<Booking> GetAll();
            Booking GetById(int bookingId);
            List<Booking> GetUpcoming();

            // Regler/checks
            bool TenantHasBooking(int tenantId, DateTime bookingDate, int timeslotId);
            bool MachineIsBooked(int machineId, DateTime bookingDate, int timeslotId);
        }
    }

