using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia : Entidad
    {

        private Plan _Plan;

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }
        
        public Materia()
        {
            this._Plan = new Plan();
        }
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _hsSemanales;
        public int HsSemanales
        {
            get {return _hsSemanales ;}
            set {_hsSemanales = value ;}
        }

        private int _hsTotales;
        public int HsTotales
        {
            get { return _hsTotales ;}
            set { _hsTotales = value;}
        }

        
        private int _idPlan;
        public int IdPlan
        {
            get {return _idPlan ;}
            set {_idPlan = value;}
        }

        public string DescPlan
        {
            get { return this.Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return this.Plan.Especialidad.Descripcion; }
        }

    }
}
