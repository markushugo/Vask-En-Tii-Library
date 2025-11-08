using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// The first name
        /// </summary>
        public string _firstName;
        /// <summary>
        /// The last name
        /// </summary>
        public string _lastName;
        /// <summary>
        /// The tenant identifier
        /// </summary>
        public int _tenantID;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public int TenantID { get { return _tenantID; } set { _tenantID = value; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="tenantID">The tenant identifier.</param>
        /// 
        public int ApartmentId { get; set; }
        public Tenant(string firstName, string lastName, int tenantID, int apartmentId)
        {
            _firstName = firstName;
            _lastName = lastName;
            _tenantID = tenantID;
            ApartmentId = apartmentId;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        public Tenant()
        {
        }
    }
}
