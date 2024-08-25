using Common.Exceptions;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Validators
{
    public class OsobaValidator
    {
        private OsobaDTO osoba;
        //private Osoba osoba;
        //public OsobaValidator(Osoba osoba) 
        //{
        //    this.osoba = osoba;
        //}

        public void ValidateNullOrEmpty(Osoba osoba)
        {
            if (osoba == null) throw new NotFoundException("Osoba nije pronadjena.");
        }

        public void ValidateNullOrEmpty(OsobaDTO osoba)
        {
            if (osoba == null) throw new NotFoundException("Niste uneli podatke o osobi.");
        }

        public void ValidateNullOrEmptyList(List<Osoba> osobaList)
        {
            if (osobaList == null) throw new NotFoundException("Lista osoba je prazna");
        }

        public void ValidateForSave(OsobaDTO osoba)
        {
            ValidateFormatIme(osoba.Ime, "Ime");
            ValidateFormatIme(osoba.Prezime, "Prezime");
            ValidateFormatJmbg(osoba.JMBG);
            ValidateFormatDatumRodjenja(osoba.DatumRodjenja);
            ValidateFormatVisina(osoba.Visina);
            ValidateMesto(osoba);
        }

        private void ValidateFormatIme(string name, string nameType)
        {
            if (string.IsNullOrEmpty(name)) throw new NotInitializedException(nameType + " je obavezno polje.");
            if (string.IsNullOrWhiteSpace(name)) throw new NotInitializedException(nameType + " je obavezno polje.");

            if (name.Length > 33) throw new NotInitializedException(nameType + " moze da ima najvise 33 karaktera.");

            Regex re = new Regex("^[А-ШA-Z][а-шa-zА-ШA-Z]*$");
            if (!re.IsMatch(name)) throw new NotInitializedException(nameType + " mora da pocne velikim slovom i da sadrzi slova srpske cirilice ili latinice");
        }

        private void ValidateFormatJmbg(string jmbg)
        {
            if (string.IsNullOrEmpty(jmbg)) throw new NotInitializedException("JMBG je obavezno polje.");
            if (string.IsNullOrWhiteSpace(jmbg)) throw new NotInitializedException("JMBG je obavezno polje.");

            if (jmbg.Length != 13) throw new NotInitializedException("JMBG mora da ima 13 cifara.");

            Regex re = new Regex(@"\d{13}$");
            if (!re.IsMatch(jmbg)) throw new NotInitializedException("JMBG mora da ima 13 cifara");
        }

        private void ValidateFormatDatumRodjenja(DateTime date) 
        {
            if (date < new DateTime(1920, 1, 1) || date > DateTime.Now) throw new NotInitializedException("Datum mora biti u rasponu od 1.1.1920. do danas.");
        }

        private void ValidateFormatVisina(int visina)
        {
            if (visina < 50 || visina > 250) throw new NotInitializedException("Visina mora biti u rasponu od 50 do 250cm");
        }

        private void ValidateMesto(OsobaDTO osoba)
        {
            //if (osoba.MestoRodjenja == null) throw new NotFoundException("Mesto rodjenja je obavezno polje.");
            if (osoba.MestoRodjenjaId == 0) throw new NotFoundException("Mesto rodjenja je obavezno polje.");
        }

    }
}
