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
        /// The machine name
        /// </summary>
        public string _machineName;

        /// <summary>
        /// Gets or sets the machine identifier.
        /// </summary>
        /// <value>
        /// The machine identifier.
        /// </value>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets the type of the machine.
        /// </summary>
        /// <value>
        /// The type of the machine.
        /// </value>
        public string MachineType { get; set; }   // "Washer" | "Dryer" | "Roller"
        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        public string MachineName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public enum NumberOfMachines
        {
            /// <summary>
            /// The washine machine
            /// </summary>
            WashineMachine = 3,
            /// <summary>
            /// The dryer
            /// </summary>
            Dryer = 2,
            /// <summary>
            /// The rolling machine
            /// </summary>
            RollingMachine = 1
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <param name="machineType">Type of the machine.</param>
        /// <param name="isAvailable">if set to <c>true</c> [is available].</param>
        /// <param name="machineName">Name of the machine.</param>
        public Unit(int machineId, string machineType, bool isAvailable, string machineName)
        {
            _machineId = machineId;
            _machineType = machineType;
            _isAvailable = isAvailable;
            _machineName = machineName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit" /> class.
        /// </summary>
        public Unit()
        {
        }
    }
}