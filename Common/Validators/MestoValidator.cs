using Common.Exceptions;
using Domain.Entity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Validators
{
    public class MestoValidator
    {
        public void ValidateNullOrEmpty(Mesto mesto)
        {
            if (mesto == null) throw new NotFoundException("Mesto nije pronadjeno.");
        }

        public void ValidateNullOrEmpty(MestoDTO mesto)
        {
            if (mesto == null) throw new NotFoundException("Niste uneli podatke o mestu.");
        }

        public void ValidateForSave(MestoDTO mesto)
        {
            ValidateFormatNaziv(mesto.Naziv);
            ValidateFormatPttBroj(mesto.PttBroj);
            ValidateFormatBrojStanovnika(mesto.BrojStanovnika);
        }

        private void ValidateFormatNaziv(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new NotInitializedException("Naziv mesta je obavezno polje.");
            if (string.IsNullOrWhiteSpace(name)) throw new NotInitializedException("Naziv mesta je obavezno polje.");

            Regex re = new Regex("^[А-ШA-Z][а-шa-zА-ШA-Z]*( [а-шa-zА-ШA-Z]+)*$");
            if (!re.IsMatch(name)) throw new NotInitializedException("Naziv mesta mora da pocne velikim slovom i da sadrzi slova srpske cirilice ili latinice");
        }

        private void ValidateFormatPttBroj(string ptt)
        {
            if (string.IsNullOrEmpty(ptt)) throw new NotInitializedException("PTT broj je obavezno polje.");
            if (string.IsNullOrWhiteSpace(ptt)) throw new NotInitializedException("PTT broj je obavezno polje.");

            if (ptt.Length != 5) throw new NotInitializedException("PTT brij mora da ima 5 karaktera.");

            Regex re = new Regex(@"\d{5}$");
            if (!re.IsMatch(ptt)) throw new NotInitializedException("PTT broj mora da ima 5 cifara");
        }

        private void ValidateFormatBrojStanovnika(int br)
        {
            if (br < 0 || br > 2000000) throw new NotInitializedException("Broj stanovnika moze biti izmedju 0 i 2 000 000");
        }

    }
}
