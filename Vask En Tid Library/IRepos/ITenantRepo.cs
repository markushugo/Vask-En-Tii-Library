using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.IRepos
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITenantRepo
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<Tenant> GetAll();

        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void CreateTenant(Tenant tenant);

        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        public void DeleteTenant(int tenantId);

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void UpdateTenant(Tenant tenant);

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetById(int tenantId);
    }
}