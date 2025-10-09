using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantService
    {

        /// <summary>
        /// The tenant repo
        /// </summary>
        private readonly ITenantRepo _tenantRepo;
        /// <summary>
        /// The tenant
        /// </summary>
        private Tenant _tenant;

        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void CreateTenant(Tenant tenant)
        {
            _tenantRepo.CreateTenant(tenant);
        }
        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void DeleteTenant(int tenantId)
        {
            _tenantRepo.DeleteTenant(tenantId);
        }
        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void UpdateTenant(Tenant tenant)
        {
            _tenantRepo.UpdateTenant(tenant);

        }
        /// <summary>
        /// Gets all tenants.
        /// </summary>
        public void GetAll()
        {
            _tenantRepo.GetAll();
        }
    }
}
