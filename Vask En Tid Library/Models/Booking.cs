using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// The booking identifier
        /// </summary>
        public int _bookingId;
        /// <summary>
        /// The booking time
        /// </summary>
        public DateTime _bookingTime;
        /// <summary>
        /// The tenant identifier
        /// </summary>
        public int _tenantId;
        /// <summary>
        /// The machine identifier
        /// </summary>
        public int _machineId;
        /// <summary>
        /// The booking date
        /// </summary>
        public DateTime _bookingDate;
        /// <summary>
        /// The is booked
        /// </summary>
        public bool _isBooked;

        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>
        /// The booking identifier.
        /// </value>
        public int BookingId { get { return _bookingId; } set { _bookingId = value; } }
        /// <summary>
        /// Gets or sets the booking time.
        /// </summary>
        /// <value>
        /// The booking time.
        /// </value>
        public DateTime BookingTime { get { return _bookingTime; } set { _bookingTime = value; } }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public int TenantId { get { return _tenantId; } set { _tenantId = value; } }
        /// <summary>
        /// Gets or sets the machine identifier.
        /// </summary>
        /// <value>
        /// The machine identifier.
        /// </value>
        public int MachineId { get { return _machineId; } set { _machineId = value; } }
        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        public DateTime BookingDate { get { return _bookingDate; } set { _bookingDate = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is booked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is booked; otherwise, <c>false</c>.
        /// </value>
        public bool IsBooked { get { return _isBooked; } set { _isBooked = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="bookingTime">The booking time.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="machineId">The machine identifier.</param>
        /// <param name="bookingDate">The booking date.</param>
        /// <param name="isBooked">if set to <c>true</c> [is booked].</param>
        public Booking(int bookingId, DateTime bookingTime, int tenantId, int machineId, DateTime bookingDate, bool isBooked)
        {
            _bookingId = bookingId;
            _bookingTime = bookingTime;
            _tenantId = tenantId;
            _machineId = machineId;
            _bookingDate = bookingDate;
            _isBooked = isBooked;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking()
        {
        }

    }
}
