using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan: Entidad
    {
        private Especialidad _Especialidad;
        private string _Descripcion;
        private int _IDEspecialidad;
       
        public Especialidad Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }
        
        public Plan()
        {
        this.Especialidad = new Especialidad();
        } 

        public string DescEspecialidad
        {
            get { return _Especialidad.Descripcion; }
        }

        

       
    }
}
