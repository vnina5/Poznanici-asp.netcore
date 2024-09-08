using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int PostCode { get; set; }

        public string Name { get; set; }

        public int? NumberOfCitizens { get; set; }


        public City() { }

        public City(int postCode, string name, int? numberOfCitizens = null)
        {
            PostCode = postCode;
            Name = name;
            NumberOfCitizens = numberOfCitizens;
        }
    }
}
