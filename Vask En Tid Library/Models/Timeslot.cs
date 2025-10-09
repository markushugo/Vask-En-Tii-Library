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
        /// <summary>
        /// The identifier
        /// </summary>
        public int _id;
        public enum _timeslotEnum;

        public int Id { get { return _id; } set { _id = value; } }
        public enum TimeslotEnum { EightToTen = 1, TenToTwelve, TwelveToTwo, TwoToFour, FourToSix, SixToEight }

        public Timeslot(int id)
        {
            _id = id;

        }

        public Timeslot()
        {
        }




    }
}


       



