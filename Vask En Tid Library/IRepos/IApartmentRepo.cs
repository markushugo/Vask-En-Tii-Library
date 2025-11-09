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
        /// <param name="apartment">The apartment.</param>
        public void CreateApartment(Apartment apartment);

        /// <summary>
        /// Deletes the apartment.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        public void DeleteApartment(int apartmentId);

        /// <summary>
        /// Updates the apartment.
        /// </summary>
        /// <param name="apartment">The apartment.</param>
        public void UpdateApartment(Apartment apartment);

        /// <summary>
        /// Gets all apartments.
        /// </summary>
        /// <returns></returns>
        public List<Apartment> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        /// <returns></returns>
        public Apartment GetById(int apartmentId);
    }
}