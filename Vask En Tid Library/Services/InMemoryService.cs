using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryService
    {
        /// <summary>
        /// Gets the tenants.
        /// </summary>
        /// <value>
        /// The tenants.
        /// </value>
        public static List<TenantRegistration> Tenants { get; } = new();
    }

    /// <summary>
    /// 
    /// </summary>
    public class TenantRegistration
    {
        /// <summary>
        /// Gets or sets the tenant.
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        public Tenant Tenant { get; set; }
        /// <summary>
        /// Gets or sets the apartment.
        /// </summary>
        /// <value>
        /// The apartment.
        /// </value>
        public Apartment Apartment { get; set; }
    }
}