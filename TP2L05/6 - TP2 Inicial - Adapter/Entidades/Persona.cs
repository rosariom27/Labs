using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona: Entidad
    {

        private Plan _Plan;        
        public Persona()
        {
            this.Plan = new Plan();
        }
        
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private DateTime _fechaNac;
        public DateTime FechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        private int _legajo;
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        private string _tipoPersona;
        public string TipoPersona
        {
            get { return _tipoPersona; }
            set { _tipoPersona = value; }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

     
        public string DescPlan
        {
            get { return _Plan.Descripcion; }
        }

                public string DescEspecialidad
        {
            get { return _Plan.DescEspecialidad; }
        }

    }
}
