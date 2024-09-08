using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Home : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }

        public int HomeTypeId { get; set; }
        [ForeignKey("HomeTypeId")]
        public HomeType HomeType { get; set; }

        public Home() { }

        public Home(int personId, int cityId, string street, int number, int homeTypeId, int? floor = null) 
        {
            PersonId = personId;
            CityId = cityId;
            Street = street;
            Number = number;
            HomeTypeId = homeTypeId;
            Floor = floor;
        }
    }
}
