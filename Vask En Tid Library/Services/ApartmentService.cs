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
        /// Initializes a new instance of the <see cref="ApartmentService"/> class.
        /// </summary>
        /// <param name="apartmentRepo">The apartment repo.</param>
        public ApartmentService(IApartmentRepo apartmentRepo)
        {
            _apartmentRepo = apartmentRepo;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Apartment> GetAll()
        {
            return _apartmentRepo.GetAll();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Apartment GetById(int id)
        {
            return _apartmentRepo.GetById(id);
        }

        /// <summary>
        /// Creates the specified apartment.
        /// </summary>
        /// <param name="apartment">The apartment.</param>
        public void Create(Apartment apartment)
        {
            _apartmentRepo.CreateApartment(apartment);
        }
    }
}