using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;


namespace Vask_En_Tid_Library.IRepos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitRepo
    {
        /// <summary>
        /// Gets all units.
        /// </summary>
        public void GetAllUnits(int unitId);
        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unitId">The unit identifier.</param>
        public void CreateUnit(int unitId);
        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="unitId">The unit identifier.</param>
        public void DeleteUnit(int unitId);
        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unitId">The unit identifier.</param>
        public void UpdateUnit(int unitId);
    }
}
