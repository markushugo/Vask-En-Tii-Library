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

    // hvis du også vil have enum i koden til maskintyper (selvom DB bruger MachineId)
    public enum MachineTypeEnum
    {
        Washer = 1,
        Dryer = 2,
        Roller = 3
    }

    public class Booking
    {
        // PK i DB
        public int BookingId { get; set; }

        // FK → Tenant
        public int TenantId { get; set; }

        // FK → Machine (den konkrete maskine, ikke bare “Washer”)
        public int MachineId { get; set; }

        // datoen der bookes
        public DateTime BookingDate { get; set; }

        // FK → Timeslot (den vi lavede i SQL)
        public int TimeslotId { get; set; }

        // om den er aflyst
        public bool IsCancelled { get; set; }

        // 👇 Hjælpeproperty: gør det nemmere i C#
        // så du kan skrive booking.Timeslot == TimeslotEnum.EightToTen
        public TimeslotEnum Timeslot
        {
            get => (TimeslotEnum)TimeslotId;
            set => TimeslotId = (int)value;
        }

        // valgfri: hvis du i UI vil vise typen (Washer/Dryer/Roller),
        // men det er ikke noget vi gemmer på Booking-tabellen mere
        public MachineTypeEnum? MachineType { get; set; }

        public Booking() { }
    }
}

    

