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
        /// Initializes a new instance of the <see cref="TenantService"/> class.
        /// </summary>
        /// <param name="tenantRepo">The tenant repo.</param>
        public TenantService(ITenantRepo tenantRepo)
        {
            _tenantRepo = tenantRepo;
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns></returns>
        public List<Tenant> GetAllTenants()
        {
            return _tenantRepo.GetAll();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetById(int tenantId)
        {
            return _tenantRepo.GetById(tenantId);
        }

        /// <summary>
        /// Registers the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <exception cref="System.InvalidOperationException">Denne lejlighed er allerede registreret af en beboer.</exception>
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

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void UpdateTenant(Tenant tenant)
        {
            _tenantRepo.UpdateTenant(tenant);
        }

        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void DeleteTenant(int tenantId)
        {
            _tenantRepo.DeleteTenant(tenantId);
        }
    }
}