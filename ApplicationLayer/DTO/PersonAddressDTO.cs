using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class PersonAddressDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JMBG { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? AgeInMonths { get; set; }
        public int? Height { get; set; }

        public int CityOfBirthId { get; set; }

        public int AddressId { get; set; }
        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public int? AddressFloor { get; set; }
        public int AddressCityId { get; set; }

        public int HomeTypeId { get; set; }
        public string HomeTypeName { get; set; }
    }
}
