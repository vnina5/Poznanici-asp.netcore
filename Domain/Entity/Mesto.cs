using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Mesto : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "PttBroj je obavezno polje")]
        [RegularExpression(@"\d{5}$", ErrorMessage = "Ptt broj mora da ima 5 cifara")]
        public string PttBroj { get; set; }

        [Required(ErrorMessage = "Naziv mesta je obavezno polje")]
        [RegularExpression("^[А-ШA-Z][а-шa-zА-ШA-Z]*( [а-шa-zА-ШA-Z]+)*$", ErrorMessage = "Naziv mesta mora da pocne velikim slovom i da sadrzi slova srpske cirilice ili latinice")]
        public string Naziv { get; set; }

        [Range(0, 2000000, ErrorMessage = "Broj stanovnika moze biti izmedju 0 i 2 000 000")]
        public int BrojStanovnika { get; set; }

        //public List<Osoba> Rodjeni { get; set; }
        //public List<Osoba> Zive { get; set; }
    }
}
