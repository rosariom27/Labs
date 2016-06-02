using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class AlumnoInscripcionLogic : NegocioLogic
    {
         private AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public AlumnoInscripcionAdapter AlumnoInscripcionData
    {
        get { return _AlumnoInscripcionData; }
        set { _AlumnoInscripcionData = value; }
    }

        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }

    public AlumnoInscripcion GetOne(int ID)
    {
        return AlumnoInscripcionData.GetOne(ID);
    }

    public List<AlumnoInscripcion> GetAll()
    {
        try
        {
            return AlumnoInscripcionData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(AlumnoInscripcion alumnoInscripcion)
    {
        AlumnoInscripcionData.Save(alumnoInscripcion);
    }

    public void Delete(int ID)
    {
        AlumnoInscripcionData.Delete(ID);
    } 

    }

}
