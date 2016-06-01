using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInsrcipcion : Entidad
    {
        private Persona _Alumno;
        private Curso _Curso;
        
        public AlumnoInsrcipcion()
        {
            this._Alumno = new Persona();
            this._Curso = new Curso();
        }
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

        private int _Nota;
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        public Persona Alumno
        {
            get { return _Alumno; }
            set { _Alumno = value; }
        }

        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }

        public string DescComision
        {
            get { return Curso.Comision.Descripcion; }
        }

        public int AnioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public string DescMateria
        {
            get { return Curso.Materia.Descripcion; }
        }

        public string Apellido
        {
            get { return this.Alumno.Apellido; }
        }

        public string Nombre
        {
            get { return this.Alumno.Nombre; }
        }
    }
}
