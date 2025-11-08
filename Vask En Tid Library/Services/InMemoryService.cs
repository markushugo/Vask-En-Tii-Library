using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Services
{
    public class InMemoryService
    {
     
           
        public static List<TenantRegistration> Tenants { get; } = new();
    }

       
        public class TenantRegistration
        {
            public Tenant Tenant { get; set; }
            public Apartment Apartment { get; set; }
        }
    }

