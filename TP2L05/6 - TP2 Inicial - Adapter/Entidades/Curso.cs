using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso : Entidad
    {
        public Curso()
        {
            this._Materia = new Materia();
            this._Comision = new Comision();
        }

        private Comision _Comision;
        public Comision Comision
        {
            get {
                return _Comision;
            }
            set
            {
                _Comision = value;
            }
        }

        private Materia _Materia;

        public Materia Materia
        {
            get
            {
                return _Materia;
            }
            set
            {
                _Materia = value;
            }
        }

        public string DescMateria
        {
            get { return _Materia.Descripcion; }
        }

        public string DescComision
        {
            get { return _Comision.Descripcion; }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _anioCalendario;
        public int AnioCalendario
        {
            get { return _anioCalendario; }
            set { _anioCalendario = value; }
        }

        private int _cupo;
        public int Cupo
        {
            get { return _cupo; }
            set { _cupo = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _idcomision;
        public int IDComision
        {
            get { return _idcomision; }
            set { _idcomision = value; }
        }

        private int _idmateria;
        public int IDMateria
        {
            get { return _idmateria; }
            set { _idmateria = value; }
        }

    }

}
