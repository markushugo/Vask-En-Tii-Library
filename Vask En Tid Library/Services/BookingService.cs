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
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="bookingRepo">The booking repo.</param>
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <exception cref="System.InvalidOperationException">
        /// Du har allerede en booking i dette tidsrum.
        /// or
        /// Maskinen er allerede booket i dette tidsrum.
        /// </exception>
        public void CreateBooking(Booking booking)
        {
            if (_bookingRepo.TenantHasBooking(booking.TenantId, booking.BookingDate, booking.TimeslotId))
                throw new InvalidOperationException("Du har allerede en booking i dette tidsrum.");

            if (_bookingRepo.MachineIsBooked(booking.MachineId, booking.BookingDate, booking.TimeslotId))
                throw new InvalidOperationException("Maskinen er allerede booket i dette tidsrum.");

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
        /// <param name="booking">The booking.</param>
        public void UpdateBooking(Booking booking)
        {
            _bookingRepo.UpdateBooking(booking);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetAll()
        {
            return _bookingRepo.GetAll();
        }

        /// <summary>
        /// Gets the upcoming.
        /// </summary>
        /// <returns></returns>
        public List<Booking> GetUpcoming()
        {
            var all = _bookingRepo.GetAll();
            return all.Where(b => b.BookingDate >= DateTime.Today).ToList();
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
            return _bookingRepo.MachineIsBooked(machineId, bookingDate, timeslotId);
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
            return _bookingRepo.TenantHasBooking(tenantId, bookingDate, timeslotId);
        }

        /// <summary>
        /// Gets the booked machine ids.
        /// </summary>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        public List<int> GetBookedMachineIds(DateTime bookingDate, int timeslotId)
        {
            return _bookingRepo.GetBookedMachineIds(bookingDate, timeslotId);
        }
    }
}