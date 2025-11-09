using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeslotService
    {
        /// <summary>
        /// The timeslot repo
        /// </summary>
        private readonly ITimeslotRepo _timeslotRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeslotService"/> class.
        /// </summary>
        /// <param name="timeslotRepo">The timeslot repo.</param>
        public TimeslotService(ITimeslotRepo timeslotRepo)
        {
            _timeslotRepo = timeslotRepo;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Timeslot> GetAll()
        {
            return _timeslotRepo.GetAll();
        }
    }
}