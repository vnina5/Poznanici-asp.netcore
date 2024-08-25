using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class OsobaDTO
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int JMBG { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
        public int? Starost { get; set;  }
        public int? Visina { get; set; }

        public int MestoRodjenjaId { get; set; }

        public int PrebivalisteId { get; set; }
    }
}
