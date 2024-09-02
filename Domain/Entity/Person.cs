using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Person : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long JMBG { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? AgeInMonths { 
            get { return CalculateAgeInMonths(); } 
            private set { CalculateAgeInMonths(); } 
        }

        public int? Height { get; set; }


        public int CityOfBirthId { get; set; }
        [ForeignKey("CityOfBirthId")]
        public virtual City CityOfBirth { get; set; }


        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }


        public Person() { }

        public Person(string firstName, string lastName, long jmbg, DateTime? dateOfBirth, int? height, int cityOfBirthId, int addressId)
        {
            FirstName = firstName;
            LastName = lastName;
            JMBG = jmbg;
            DateOfBirth = dateOfBirth;
            Height = height;
            CityOfBirthId = cityOfBirthId;
            AddressId = addressId;
        }


        private int? CalculateAgeInMonths()
        {
            int? ageInMonths = null;
            if (DateOfBirth.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                DateTime dateOfBirth = DateOfBirth.Value;
                ageInMonths = (currentDate.Year - dateOfBirth.Year) * 12 + (currentDate.Month - dateOfBirth.Month);
                if (currentDate.Day < dateOfBirth.Day) ageInMonths--;
                
            }
            return ageInMonths;
        }
    }
}
