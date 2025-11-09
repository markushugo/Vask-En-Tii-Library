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
        /// <param name="booking">The booking.</param>
        void CreateBooking(Booking booking);

        /// <summary>
        /// Deletes the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        void DeleteBooking(int bookingId);

        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        void UpdateBooking(Booking booking);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<Booking> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns></returns>
        Booking GetById(int bookingId);

        /// <summary>
        /// Gets the upcoming.
        /// </summary>
        /// <returns></returns>
        List<Booking> GetUpcoming();

        /// <summary>
        /// Tenants the has booking.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        bool TenantHasBooking(int tenantId, DateTime bookingDate, int timeslotId);

        /// <summary>
        /// Machines the is booked.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        bool MachineIsBooked(int machineId, DateTime bookingDate, int timeslotId);

        /// <summary>
        /// Gets the booked machine ids.
        /// </summary>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="timeslotId">The timeslot identifier.</param>
        /// <returns></returns>
        List<int> GetBookedMachineIds(DateTime bookingDate, int timeslotId);
    }
}