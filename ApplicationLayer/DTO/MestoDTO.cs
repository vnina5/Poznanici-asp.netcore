using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class MestoDTO
    {
        public int PttBroj { get; set; }
        public string Naziv { get; set; }
        public int? BrojStanovnika { get; set; }
    }
}
