using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.IRepos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitRepo
    {
        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        void CreateUnit(Unit unit);

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        void UpdateUnit(Unit unit);

        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        void DeleteUnit(int machineId);

        /// <summary>
        /// Gets all units.
        /// </summary>
        /// <returns></returns>
        List<Unit> GetAllUnits();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="machineId">The machine identifier.</param>
        /// <returns></returns>
        Unit GetById(int machineId);
    }
}