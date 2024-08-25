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

        public int JMBG { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public int? AgeInMonths { 
            get { return CalculateAgeInMonths(); } 
            private set { CalculateAgeInMonths(); } 
        }

        public int? Height { get; set; }


        public int CityOfBirthId { get; set; }
        [ForeignKey("CityOfBirthId")]
        public virtual City CityOfBirth { get; set; }


        public int AddresId { get; set; }
        [ForeignKey("AddresId")]
        public virtual City? Addres { get; set; }


        public Person(string firstName, string lastName, int jmbg, int cityOfBirthId, int addresId, DateOnly? dateOfBirth = null, int? height = null)
        {
            FirstName = firstName;
            LastName = lastName;
            JMBG = jmbg;
            DateOfBirth = dateOfBirth;
            Height = height;
            CityOfBirthId = cityOfBirthId;
            AddresId = addresId;
        }


        private int? CalculateAgeInMonths()
        {
            int? ageInMonths = null;
            if (DateOfBirth.HasValue)
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                DateOnly dateOfBirth = DateOfBirth.Value;
                ageInMonths = (currentDate.Year - dateOfBirth.Year) * 12 + (currentDate.Month - dateOfBirth.Month);
                if (currentDate.Day < dateOfBirth.Day) ageInMonths--;
                
            }
            return ageInMonths;
        }
    }
}
