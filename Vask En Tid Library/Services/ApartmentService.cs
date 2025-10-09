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
    public class ApartmentService
    {
        /// <summary>
        /// The apartment repo
        /// </summary>
        private readonly IApartmentRepo _apartmentRepo;
        /// <summary>
        /// The apartment
        /// </summary>
        private Apartment _apartment;

        /// <summary>
        /// Creates the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void CreateApartment(Apartment apartment)
        {
            _apartmentRepo.CreateApartment(apartment);
        }
        /// <summary>
        /// Deletes the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void DeleteApartment(int apartmentId)
        {
            _apartmentRepo.DeleteApartment(apartmentId);
        }
        /// <summary>
        /// Updates the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void UpdateApartment(Apartment apartment)
        {
            _apartmentRepo.UpdateApartment(apartment);

        }
        /// <summary>
        /// Gets all apartments.
        /// </summary>
        public void GetAll()
        {
            _apartmentRepo.GetAll();
        }

        public void GetById(int apartmentId)
        {
            _apartmentRepo.GetAll();
        }
    }
}
