using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class AlumnoLogic: NegocioLogic
    {
        private AlumnoAdapter _AlumnoData;
        public AlumnoAdapter AlumnoData
    {
        get { return _AlumnoData; }
        set { _AlumnoData = value; }
    }

        public AlumnoLogic()
        {
            AlumnoData = new AlumnoAdapter();
        }

    public AlumnoInsrcipcion GetOne(int ID)
    {
        return AlumnoData.GetOne(ID);
    }

    public List<AlumnoInsrcipcion> GetAll()
    {
        //lab 5 punto 17 primer item
        
        try
        {
            AlumnoData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
            throw ExcepcionManejada;
        }

        return AlumnoData.GetAll();     
    }

    public void Save(AlumnoInsrcipcion alumno)
    {
        AlumnoData.Save(alumno);
    }

    public void Delete(int ID)
    {
        AlumnoData.Delete(ID);
    } 

    }
    
}
