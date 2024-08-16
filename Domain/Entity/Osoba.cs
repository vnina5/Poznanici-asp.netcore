using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Osoba : IEntity
    {
        [Key]
        public long Id { get; set; }


        [Required(ErrorMessage = "Ime je obavezno polje")]
        [StringLength(33, ErrorMessage = "Ime moze da ima najvise 33 slova")]
        [RegularExpression("^[А-ШA-Z][а-шa-zА-ШA-Z]*$", ErrorMessage = "Ime mora da pocne velikim slovom i da sadrzi slova srpske cirilice ili latinice")]
        public string Ime { get; set; }


        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [StringLength(33, ErrorMessage = "Prezime moze da ima najvise 33 slova")]
        [RegularExpression("^[А-ШA-Z][а-шa-zА-ШA-Z]*$", ErrorMessage = "Prezime mora da pocne velikim slovom i da sadrzi slova srpske cirilice ili latinice")]
        public string Prezime { get; set; }


        [Required(ErrorMessage = "JMBG je obavezno polje")]
        [RegularExpression(@"\d{13}$", ErrorMessage = "JMBG mora da ima 13 cifara")]
        public string JMBG { get; set; }


        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1920-01-01", "2023-12-31")]
        public DateTime DatumRodjenja { get; set; }


        public int StarostUMesecima { 
            get { return IzracunajStarostUMesecima(DatumRodjenja, DateTime.Now); } 
            set { IzracunajStarostUMesecima(DatumRodjenja, DateTime.Now); } 
        }


        [Range(50, 250, ErrorMessage = "Visina mora biti u rasponu od 50 do 250cm")]
        public int Visina { get; set; }


        [Required]
        public long MestoRodjenjaId { get; set; }
        [Required]
        [ForeignKey("MestoRodjenjaId")]
        public virtual Mesto MestoRodjenja { get; set; }


        public long PrebivalisteId { get; set; }
        [ForeignKey("PrebivalisteId")]
        public virtual Mesto Prebivaliste { get; set; }



        private int IzracunajStarostUMesecima(DateTime datumRodjenja, DateTime trenutniDatum)
        {
            int starost = (trenutniDatum.Year - datumRodjenja.Year) * 12 + (trenutniDatum.Month - datumRodjenja.Month);
            if (trenutniDatum.Day < datumRodjenja.Day) starost--;
            return starost;
        }
    }
}
