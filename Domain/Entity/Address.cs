using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int HomeTypeId { get; set; }
        [ForeignKey("HomeTypeId")]
        public HomeType HomeType { get; set; }

        public Address() { }

        public Address(string street,int number, int cityId, int homeTypeId, int? floor = null) 
        {
            Street = street;
            Number = number;
            CityId = cityId;
            HomeTypeId = homeTypeId;
            Floor = floor;
        }
    }
}
