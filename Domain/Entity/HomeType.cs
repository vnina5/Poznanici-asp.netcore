using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class HomeType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public HomeType(string name)
        {
            Name = name;
        }
    }
}
