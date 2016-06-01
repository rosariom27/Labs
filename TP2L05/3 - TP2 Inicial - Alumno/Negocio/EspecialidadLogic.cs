using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class EspecialidadLogic: NegocioLogic
    {

         private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
    {
        get { return _EspecialidadData; }
        set { _EspecialidadData = value; }
    }

    public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

    public Especialidad GetOne(int ID)
    {
        return EspecialidadData.GetOne(ID);
    }

    public List<Especialidad> GetAll()
    {
        try
        {
            return EspecialidadData.GetAll();
        } 

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Especialidad especialidad)
    {
        EspecialidadData.Save(especialidad);
    }

    public void Delete(int ID)
    {
        EspecialidadData.Delete(ID);
    } 

    }
}
