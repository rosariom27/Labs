using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class AlumnoInscripcionLogic: NegocioLogic
    {
        private AlumnoInscripcionAdapter _AlumnoData;
        public AlumnoInscripcionAdapter AlumnoData
    {
        get { return _AlumnoData; }
        set { _AlumnoData = value; }
    }

        public AlumnoInscripcionLogic()
        {
            AlumnoData = new AlumnoInscripcionAdapter();
        }

    public AlumnoInsrcipcion GetOne(int ID)
    {
        return AlumnoData.GetOne(ID);
    }

    public bool Existe(int id_alu, int id_cur)
    {
        return _AlumnoData.Existe(id_alu, id_cur);
    }
    public List<AlumnoInsrcipcion> GetAll()
    {
        try
        {
            return AlumnoData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos inscripciones", Ex);
            throw ExcepcionManejada;
        }

          
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
