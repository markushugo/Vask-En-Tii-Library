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
    public class Timeslot
    {
        public int TimeslotId { get; set; }
        public string SlotName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public override string ToString()
        {
            return $"{SlotName} ({StartTime:hh\\:mm}-{EndTime:hh\\:mm})";
        }




    }
}


       



