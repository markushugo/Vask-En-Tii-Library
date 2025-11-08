using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Apartment
    {

        /// <summary>
        /// The apartment identifier
        /// </summary>
        public int _apartmentId;
        /// <summary>
        /// The number
        /// </summary>
        public int _number;
        /// <summary>
        /// The apartment adrees
        /// </summary>
        public string _apartmentCode;


        /// <summary>
        /// Gets or sets the apartment identifier.
        /// </summary>
        /// <value>
        /// The apartment identifier.
        /// </value>
        public int ApartmentId { get { return _apartmentId; } set { _apartmentId = value; } }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get { return _number; } set { _number = value; } }
        /// <summary>
        /// Gets or sets the apartment adrees.
        /// </summary>
        /// <value>
        /// The apartment adrees.
        /// </value>
     
        public string ApartmentCode { get { return _apartmentCode; } set { _apartmentCode = value; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="Apartment"/> class.
        /// </summary>
        /// <param name="apartmentId">The apartment identifier.</param>
        /// <param name="number">The number.</param>
        /// <param name="apartmentAdrees">The apartment adrees.</param>
        public Apartment(int apartmentId, int number, string apartmentCode)
        {
            _apartmentId = apartmentId;
            _number = number;
            _apartmentCode = apartmentCode;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Apartment"/> class.
        /// </summary>
        public Apartment()
        {
        }
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{_apartmentId},{_number},{_apartmentCode}";
        }
    }
}
