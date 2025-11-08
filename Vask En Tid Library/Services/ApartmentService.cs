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
        private readonly IApartmentRepo _apartmentRepo;

        public ApartmentService(IApartmentRepo apartmentRepo)
        {
            _apartmentRepo = apartmentRepo;
        }

        public List<Apartment> GetAll()
        {
            return _apartmentRepo.GetAll();
        }

        public Apartment GetById(int id)
        {
            return _apartmentRepo.GetById(id);
        }

        public void Create(Apartment apartment)
        {
            _apartmentRepo.CreateApartment(apartment);
        }
    }
}