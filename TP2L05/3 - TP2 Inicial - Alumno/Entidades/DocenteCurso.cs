using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso: Entidad
    {
        private int _Cargo;
        private Curso _Curso;
        private Personas _Docente;

        public DocenteCurso()
        {
            this._Curso = new Curso();
            this._Docente = new Personas();
        }

        public Curso Curso
        {
            get { return _Curso; }
            set {_Curso = value; }
        }

        public Personas Persona
        {
            get {return _Docente;}
            set {_Docente = value;}
        }

        public int IDCurso
        {
            get {return _Curso.ID;}
        }

        public string DescCurso
        {
            get {return _Curso.Descripcion;}
        }

        public int IDPersona
        {
            get {return _Docente.ID;}
        }

        public string NombrePersona
        {
            get {return _Docente.Nombre;}
        }

        public string ApellidoPersona
        {
            get {return _Docente.Apellido;}
        }

        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
    }
}
