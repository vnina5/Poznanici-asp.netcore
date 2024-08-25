using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PoznaniciContext context;
        public IOsobaRepository OsobaRepository { get; set; }
        public IMestoRepository MestoRepository { get; set; }

        public UnitOfWork(PoznaniciContext context)
        {
            this.context = context;
            this.OsobaRepository = new OsobaRepository(context);
            this.MestoRepository = new MestoRepository(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

//ne treba
