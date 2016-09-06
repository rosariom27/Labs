using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion : Entidad
    {
        private int _IDAlumno;
        private Curso _Curso;
        private Persona _Alumno;
        private string _Condicion;
        private float _Nota;
        
        public AlumnoInscripcion()
        {
            this.Persona = new Persona();
            this._Curso = new Curso();
        }
                 
        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }

        public int IDCurso
        {
            get { return _Curso.ID; }
        }

        /*public string DescCurso
        {
            get { return _Curso.Descripcion; }
        }*/
  
        public Persona Persona
        {
            get { return _Alumno;}
            set { _Alumno = value; }
        }

        public int IDAlumno
        {
            get { return _Alumno.ID; }
        }
        
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        
        public float Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        public string Apellido
        {
            get { return Persona.Apellido; }
        }

        public string Nombre
        {
            get { return Persona.Nombre; }
        }

        /*public string DescComision
        {
            get { return _Curso.DescComision; }
        }

        public string DescMateria
        {
            get { return _Curso.DescMateria; }
        }*/

        public int AnioCurso
        {
            get { return _Curso.AnioCalendario; }
        }

    }

}
