using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{

    public class TenantService
    {
        private readonly ITenantRepo _tenantRepo;

   
        public TenantService(ITenantRepo tenantRepo)
        {
            _tenantRepo = tenantRepo;
        }


        public List<Tenant> GetAllTenants()
        {
            return _tenantRepo.GetAll();
        }

        public Tenant GetById(int tenantId)
        {
            return _tenantRepo.GetById(tenantId);
        }

 
        public void RegisterTenant(Tenant tenant)
        {
            var all = _tenantRepo.GetAll();

            var exists = all.FirstOrDefault(t => t.ApartmentId == tenant.ApartmentId);
            if (exists != null)
            {
                throw new InvalidOperationException("Denne lejlighed er allerede registreret af en beboer.");
            }

            _tenantRepo.CreateTenant(tenant);
        }

        public void UpdateTenant(Tenant tenant)
        {
            _tenantRepo.UpdateTenant(tenant);
        }

        public void DeleteTenant(int tenantId)
        {
            _tenantRepo.DeleteTenant(tenantId);
        }
    }
}
