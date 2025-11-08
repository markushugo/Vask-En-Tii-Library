using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public enum TimeslotEnum
    {
        EightToTen = 1,
        TenToTwelve = 2,
        TwelveToTwo = 3,
        TwoToFour = 4,
        FourToSix = 5,
        SixToEight = 6
    }


    public enum MachineTypeEnum
    {
        Washer = 1,
        Dryer = 2,
        Roller = 3
    }

    public class Booking
    {

        public int BookingId { get; set; }

        public int TenantId { get; set; }
        public int MachineId { get; set; }
        public DateTime BookingDate { get; set; }
        public int TimeslotId { get; set; }
        public bool IsCancelled { get; set; }


        public Tenant? Tenant { get; set; }
        public Apartment? Apartment { get; set; }
        public Timeslot? Timeslot { get; set; }
        public Unit? Machine { get; set; }

        public List<Unit> Units { get; set; } = new List<Unit>();

        public TimeslotEnum TimeslotEnum
        {
            get => (TimeslotEnum)TimeslotId;
            set => TimeslotId = (int)value;
        }


        public MachineTypeEnum? MachineType { get; set; }

        public string MachineName =>
        MachineId switch
    {
        1 or 2 or 3 => "Washer",
        4 or 5 => "Dryer",
        6 => "Roller",
        _ => "Ukendt"
    };
        public Booking()
        {
        }
    }
}

    

