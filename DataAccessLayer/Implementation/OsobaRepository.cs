using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class OsobaRepository : IOsobaRepository
    {
        private readonly PoznaniciContext context;

        public OsobaRepository(PoznaniciContext context)
        {
            this.context = context;
        }

        public void Add(Osoba entity)
        {
            context.Osoba.Add(entity);
        }

        public void Delete(Osoba entity)
        {
            context.Osoba.Remove(entity);
        }

        public Osoba Get(long id)
        {
            return context.Osoba.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).SingleOrDefault(o => o.Id == id);
            //return context.Osoba.Find(id);
        }

        public List<Osoba> GetAll()
        {
            return context.Osoba.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).ToList();
            //return context.Osoba.ToList();
        }

        public void Update(Osoba entity)
        {
            //proveriti da li postoji taj entity
            context.Osoba.Update(entity);
        }


        public int GetMaxVisina()
        {
            return context.Database.SqlQuery<int>($"SELECT dbo.fnMaxVisina()").AsEnumerable().FirstOrDefault();
        }

        public int GetSrednjaStarost()
        {
            return context.Database.SqlQuery<int>($"SELECT dbo.fnSrednjaStarost()").AsEnumerable().FirstOrDefault();
        }


        public List<Osoba> GetAllPunoletni()
        {
            //return context.Osobas.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).ToList();
            var query = "SELECT * FROM dbo.punoletniView";
            return context.PunoletniView.FromSqlRaw(query).ToList();
        }

        public List<Osoba> GetAllSmederevci()
        {
            //return context.Osobas.Include(o => o.MestoRodjenja).Include(o => o.Prebivaliste).ToList();
            return context.PunoletniView.ToList();
        }

    }
}
