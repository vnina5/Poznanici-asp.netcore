using DataAccessLayer.Interfaces;
using Domain.Context;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class MestoRepository : IMestoRepository
    {
        private readonly PoznaniciContext context;

        public MestoRepository(PoznaniciContext context)
        {
            this.context = context;
        }

        public void Add(Mesto entity)
        {
            context.Mesto.Add(entity);
        }

        public void Delete(Mesto entity) 
        {
            context.Mesto.Remove(entity);
        }

        public Mesto Get(long id)
        {
            return context.Mesto.Find(id);
        }

        public List<Mesto> GetAll()
        {
            return context.Mesto.ToList();
        }

        public void Update(Mesto entity)
        {
            context.Mesto.Update(entity);
        }
    }
}
