using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IOsobaService : IService<OsobaDTO>
    {
        public int GetMaxVisina();
        public int GetSrednjaStarost();

        public List<OsobaDTO> GetAllPunoletni();
        public List<OsobaDTO> GetAllSmederevci();


    }
}
