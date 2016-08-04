using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia: Entidad
    {
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private int _IDPlan;
        private Plan _Plan;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }
        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }

        public Materia()
        {
            this._Plan = new Plan();
        }

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public int IDPlan
        {
            get { return _Plan.ID; }
        }

        public string DescPlan
        {
            get { return _Plan.Descripcion; }
        }
    }
}
