using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MestoDTO : IDTO
    {
        //public long Id { get; set; }
        public string PttBroj { get; set; }
        public string Naziv { get; set; }
        public int BrojStanovnika { get; set; }
    }
}
