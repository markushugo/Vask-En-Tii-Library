using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    public class UnitService
    {
        private readonly IUnitRepo _unitRepo;

        public UnitService(IUnitRepo unitRepo)
        {
            _unitRepo = unitRepo;
        }

        public List<Unit> GetAll()
        {
            return _unitRepo.GetAllUnits();
        }

        public void AddUnit(Unit unit)
        {
            _unitRepo.CreateUnit(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            _unitRepo.UpdateUnit(unit);
        }

        public void DeleteUnit(int id)
        {
            _unitRepo.DeleteUnit(id);
        }
    }
}
