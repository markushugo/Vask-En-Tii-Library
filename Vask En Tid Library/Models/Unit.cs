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
        /// <summary>
        /// The machine identifier
        /// </summary>
        public int _machineId;
        /// <summary>
        /// The machine type
        /// </summary>
        public string _machineType;
        /// <summary>
        /// The is available
        /// </summary>
        public bool _isAvailable;


        /// <summary>
        /// Gets or sets the machine identifier.
        /// </summary>
        /// <value>
        /// The machine identifier.
        /// </value>
        public int MachineId { get { return _machineId; } set { _machineId = value; } }
        /// <summary>
        /// Gets or sets the type of the machine.
        /// </summary>
        /// <value>
        /// The type of the machine.
        /// </value>
        public string MachineType { get { return _machineType; } set { _machineType = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get { return _isAvailable; } set { _isAvailable = value; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="isAvailable">if set to <c>true</c> [is available].</param>
        /// <value>

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
