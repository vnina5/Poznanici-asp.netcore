using Microsoft.Extensions.Primitives;
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
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int JMBG { get; set; }

        public DateOnly? DatumRodjenja { get; set; }

        public int? StarostUMesecima { 
            get { return IzracunajStarostUMesecima(); } 
            private set { IzracunajStarostUMesecima(); } 
        }

        public int? Visina { get; set; }


        public int MestoRodjenjaId { get; set; }
        [ForeignKey("MestoRodjenjaId")]
        public virtual Mesto MestoRodjenja { get; set; }


        public int PrebivalisteId { get; set; }
        [ForeignKey("PrebivalisteId")]
        public virtual Mesto Prebivaliste { get; set; }


        public Osoba(string ime, string prezime, int jmbg, int mestoRodjenjaId, int prebivalisteId, DateOnly? datumRodjenja = null, int? visina = null)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            DatumRodjenja = datumRodjenja;
            Visina = visina;
            MestoRodjenjaId = mestoRodjenjaId;
            PrebivalisteId = prebivalisteId;
        }


        private int? IzracunajStarostUMesecima()
        {
            int? starost = null;
            if (DatumRodjenja.HasValue)
            {
                DateOnly trenutniDatum = DateOnly.FromDateTime(DateTime.Now);
                DateOnly datumRodjenja = DatumRodjenja.Value;
                starost = (trenutniDatum.Year - datumRodjenja.Year) * 12 + (trenutniDatum.Month - datumRodjenja.Month);
                if (trenutniDatum.Day < datumRodjenja.Day) starost--;
                
            }
            return starost;
        }
    }
}
