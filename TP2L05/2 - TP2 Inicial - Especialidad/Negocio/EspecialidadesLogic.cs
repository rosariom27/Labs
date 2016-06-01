using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
   public class EspecialidadesLogic: NegocioLogic
    {
       private EspecialidadesAdapter _EspecialidadData;
        public EspecialidadesAdapter EspecialidadData
        {
            get {return _EspecialidadData ;}
            set { _EspecialidadData = value;}
        }
         public EspecialidadesLogic()
        {
            EspecialidadData = new EspecialidadesAdapter(); 
        }

         public Especialidad GetOne(int id_especialidad)
    {
        return EspecialidadData.GetOne(id_especialidad);
    }

    public List<Especialidad> GetAll()
    {
        //lab 5 punto 17 primer item
        
        try
        {
            EspecialidadData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
            throw ExcepcionManejada;
        }

        return EspecialidadData.GetAll();     
    }

    public void Save(Especialidad especialidad)
    {
        EspecialidadData.Save(especialidad);
    }

    public void Delete(int id_especialidad)
    {
        EspecialidadData.Delete(id_especialidad);
    } 
    }
}
