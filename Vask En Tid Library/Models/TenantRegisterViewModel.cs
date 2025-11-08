using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public class TenantRegisterViewModel
    {
        [Required(ErrorMessage = "Fornavn er påkrævet")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternavn er påkrævet")]
        public string LastName { get; set; }

        // Lejlighedsnummer i formatet 0.A, 1.B osv.
        [Required(ErrorMessage = "Lejlighedsnummer er påkrævet")]
        [RegularExpression(@"^[0-9]+\.([A-Za-z])$", ErrorMessage = "Lejlighedsnummer skal være i formatet 0.A, 1.B, 2.C")]
        public string ApartmentCode { get; set; }
    }
}
