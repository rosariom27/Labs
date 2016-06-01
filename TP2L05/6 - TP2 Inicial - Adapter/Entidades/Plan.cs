using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan : Entidad
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _DescEspecialidad;
        public string DescEspecialidad
        {
            get { return this.Especialidad.Descripcion; }
        }

        private Especialidad _Especialidad;

        public Especialidad Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }
    }
}
