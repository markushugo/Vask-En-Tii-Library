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
        void CreateUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int machineId);
        List<Unit> GetAllUnits();
        Unit GetById(int machineId);
    }
}
