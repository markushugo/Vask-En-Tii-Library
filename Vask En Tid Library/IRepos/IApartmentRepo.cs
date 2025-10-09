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
    public interface IApartmentRepo
    {
        /// <summary>
        /// Creates the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void CreateApartment(Apartment apartment);
        /// <summary>
        /// Deletes the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void DeleteApartment(int apartmentId);
        /// <summary>
        /// Updates the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void UpdateApartment(Apartment apartment);
        /// <summary>
        /// Gets all apartments.
        /// </summary>
        public List<Apartment> GetAll();

        public Apartment GetById(int apartmentId);


    }
}
