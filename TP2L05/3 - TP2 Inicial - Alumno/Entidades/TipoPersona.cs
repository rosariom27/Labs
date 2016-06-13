using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoPersona: Entidad
    {
        private int _ID;
        private string _descripcion;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
