using System.ComponentModel.DataAnnotations;

namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantRegisterViewModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required(ErrorMessage = "Fornavn er påkrævet")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required(ErrorMessage = "Efternavn er påkrævet")]
        public string LastName { get; set; }

        // Lejlighedsnummer i formatet 0.A, 1.B osv.
        /// <summary>
        /// Gets or sets the apartment code.
        /// </summary>
        /// <value>
        /// The apartment code.
        /// </value>
        [Required(ErrorMessage = "Lejlighedsnummer er påkrævet")]
        [RegularExpression(@"^[0-9]+\.([A-Za-z])$", ErrorMessage = "Lejlighedsnummer skal være i formatet 0.A, 1.B, 2.C")]
        public string ApartmentCode { get; set; }
    }
}