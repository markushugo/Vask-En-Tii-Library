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
    public class Unit
    {

        public int _machineId;
     
        public string _machineType;
    
        public bool _isAvailable;




       
            public int MachineId { get; set; }
            public string MachineType { get; set; }   // "Washer" | "Dryer" | "Roller"
            public bool IsAvailable { get; set; }
       

        public enum NumberOfMachines 
        { 
            WashineMachine = 3,
            Dryer = 2,
            RollingMachine = 1

        }
        public Unit(int machineId, string machineType, bool isAvailable)
        {
            _machineId = machineId;
            _machineType = machineType;
            _isAvailable = isAvailable;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        public Unit()
        {
        }
    }
}
