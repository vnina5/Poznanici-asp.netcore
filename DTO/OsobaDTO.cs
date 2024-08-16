using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OsobaDTO : IDTO
    {
        //public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int Starost { get; set;  }
        public int Visina { get; set; }

        public long MestoRodjenjaId { get; set; }
        //public MestoDTO MestoRodjenjaDTO { get; set; }

        public long PrebivalisteId { get; set; }
        //public MestoDTO PrebivalisteDTO { get; set; }
    }
}
