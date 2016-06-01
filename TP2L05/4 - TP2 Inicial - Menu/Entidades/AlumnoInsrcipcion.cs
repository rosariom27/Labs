using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInsrcipcion : Entidad
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _IDAlumno;
        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private float _Nota;
        public float Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
