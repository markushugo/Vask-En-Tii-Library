using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitService
    {
        /// <summary>
        /// The unit repo
        /// </summary>
        private readonly IUnitRepo _unitRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitService"/> class.
        /// </summary>
        /// <param name="unitRepo">The unit repo.</param>
        public UnitService(IUnitRepo unitRepo)
        {
            _unitRepo = unitRepo;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetAll()
        {
            return _unitRepo.GetAllUnits();
        }

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void AddUnit(Unit unit)
        {
            _unitRepo.CreateUnit(unit);
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(Unit unit)
        {
            _unitRepo.UpdateUnit(unit);
        }

        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUnit(int id)
        {
            _unitRepo.DeleteUnit(id);
        }
    }
}