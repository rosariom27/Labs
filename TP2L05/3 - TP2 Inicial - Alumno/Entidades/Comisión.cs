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
        private int _IDPlan;

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
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
        public string DescPlan
        {
            get { return Plan.Descripcion; }
        }

        public Comisión()
        {
            this.Plan = new Plan();
        }
    }
}
