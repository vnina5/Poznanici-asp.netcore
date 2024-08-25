namespace ApplicationLayer.DTO
{
    public class PersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JMBG { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? AgeInMonths { get; set;  }
        public int? Height { get; set; }

        public int CityOfBirthId { get; set; }

        public int AddressId { get; set; }
    }
}
