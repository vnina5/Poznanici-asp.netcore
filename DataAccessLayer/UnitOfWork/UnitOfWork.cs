﻿using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using Domain.Context;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        public IPersonRepository PersonRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public IHomeTypeRepository HomeTypeRepository { get; set; }

        public UnitOfWork(MyContext context)
        {
            _context = context;
            this.PersonRepository = new PersonRepository(context);
            this.CityRepository = new CityRepository(context);
            this.AddressRepository = new AddressRepository(context);
            this.HomeTypeRepository = new HomeTypeRepository(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

//ne treba
