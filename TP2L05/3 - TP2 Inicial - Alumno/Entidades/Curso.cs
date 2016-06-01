using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso: Entidad
    {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;

        private Comisión _Comision;
        private Materia _Materia;

        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public Curso()
        {
        this._Comision = new Comisión();
        this._Materia = new Materia();
        }

        public int IDComision
        {
            get { return _Comision.ID; }
        }

        public string DescComision
        {
            get { return _Comision.Descripcion; }
        }

        public int IDMateria
        {
            get { return _Materia.ID; }
        }

        public string DescMateria
        {
            get { return _Materia.Descripcion; }
        }

        
    }
}
