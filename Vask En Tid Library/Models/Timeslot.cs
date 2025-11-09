namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Timeslot
    {
        /// <summary>
        /// Gets or sets the timeslot identifier.
        /// </summary>
        /// <value>
        /// The timeslot identifier.
        /// </value>
        public int TimeslotId { get; set; }
        /// <summary>
        /// Gets or sets the name of the slot.
        /// </summary>
        /// <value>
        /// The name of the slot.
        /// </value>
        public string SlotName { get; set; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{SlotName} ({StartTime:hh\\:mm}-{EndTime:hh\\:mm})";
        }
    }
}