using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comisión: Entidad
    {
        private int _AnioEspecialidad;
        private string _Descripcion;
        private Plan _Plan;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }
    }
}
