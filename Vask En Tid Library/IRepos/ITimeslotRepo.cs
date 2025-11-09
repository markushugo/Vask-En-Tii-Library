using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.IRepos
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITimeslotRepo
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<Timeslot> GetAll();
    }
}