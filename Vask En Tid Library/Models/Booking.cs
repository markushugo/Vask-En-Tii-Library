namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum TimeslotEnum
    {
        /// <summary>
        /// The eight to ten
        /// </summary>
        EightToTen = 1,
        /// <summary>
        /// The ten to twelve
        /// </summary>
        TenToTwelve = 2,
        /// <summary>
        /// The twelve to two
        /// </summary>
        TwelveToTwo = 3,
        /// <summary>
        /// The two to four
        /// </summary>
        TwoToFour = 4,
        /// <summary>
        /// The four to six
        /// </summary>
        FourToSix = 5,
        /// <summary>
        /// The six to eight
        /// </summary>
        SixToEight = 6
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MachineTypeEnum
    {
        /// <summary>
        /// The washer
        /// </summary>
        Washer = 1,
        /// <summary>
        /// The dryer
        /// </summary>
        Dryer = 2,
        /// <summary>
        /// The roller
        /// </summary>
        Roller = 3
    }

    /// <summary>
    /// 
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>
        /// The booking identifier.
        /// </value>
        public int BookingId { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public int TenantId { get; set; }
        /// <summary>
        /// Gets or sets the machine identifier.
        /// </summary>
        /// <value>
        /// The machine identifier.
        /// </value>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        public DateTime BookingDate { get; set; }
        /// <summary>
        /// Gets or sets the timeslot identifier.
        /// </summary>
        /// <value>
        /// The timeslot identifier.
        /// </value>
        public int TimeslotId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets the tenant.
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        public Tenant? Tenant { get; set; }
        /// <summary>
        /// Gets or sets the apartment.
        /// </summary>
        /// <value>
        /// The apartment.
        /// </value>
        public Apartment? Apartment { get; set; }
        /// <summary>
        /// Gets or sets the timeslot.
        /// </summary>
        /// <value>
        /// The timeslot.
        /// </value>
        public Timeslot? Timeslot { get; set; }
        /// <summary>
        /// Gets or sets the machine.
        /// </summary>
        /// <value>
        /// The machine.
        /// </value>
        public Unit? Machine { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public List<Unit> Units { get; set; } = new List<Unit>();

        /// <summary>
        /// Gets or sets the timeslot enum.
        /// </summary>
        /// <value>
        /// The timeslot enum.
        /// </value>
        public TimeslotEnum TimeslotEnum
        {
            get => (TimeslotEnum)TimeslotId;
            set => TimeslotId = (int)value;
        }

        /// <summary>
        /// Gets or sets the type of the machine.
        /// </summary>
        /// <value>
        /// The type of the machine.
        /// </value>
        public MachineTypeEnum? MachineType { get; set; }

        /// <summary>
        /// Gets the name of the machine.
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        public string MachineName =>
        MachineId switch
        {
            1 or 2 or 3 => "Washer",
            4 or 5 => "Dryer",
            6 => "Roller",
            _ => "Ukendt"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking()
        {
        }
    }
}