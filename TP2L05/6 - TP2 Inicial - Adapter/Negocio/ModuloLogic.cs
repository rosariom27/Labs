﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class ModuloLogic: NegocioLogic
    {
        private ModuloAdapter _ModuloData;

        public ModuloLogic()
        {
            _ModuloData = new ModuloAdapter();
        }

        public ModuloAdapter ModuloData
        {
            get { return _ModuloData; }
        }

        public Modulo GetOne(string d)
        {
            return ModuloData.GetOne(d);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }
    }
}
