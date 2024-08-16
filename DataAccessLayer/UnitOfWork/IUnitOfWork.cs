﻿using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IOsobaRepository OsobaRepository { get; set; }
        public IMestoRepository MestoRepository { get; set; }

        public void SaveChanges();
    }
}
