using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.IRepos;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    public class TimeslotService
    {
      
            private readonly ITimeslotRepo _timeslotRepo;

            public TimeslotService(ITimeslotRepo timeslotRepo)
            {
                _timeslotRepo = timeslotRepo;
            }

            
            public List<Timeslot> GetAll()
            {
                return _timeslotRepo.GetAll();
            }

            
        }
    }

