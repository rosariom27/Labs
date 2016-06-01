using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision: Entidad
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _AnioEspecialidad;
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private Plan _Plan;
        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public string DescPlan
        {
            get { return this.Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return this.Plan.Especialidad.Descripcion; }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
    }
}
