using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ZipCode { get; set; }

        public string Name { get; set; }

        public int? NumberOfCitizens { get; set; }


        public City() { }

        public City(int zipCode, string name, int? numberOfCitizens = null)
        {
            ZipCode = zipCode;
            Name = name;
            NumberOfCitizens = numberOfCitizens;
        }
    }
}
