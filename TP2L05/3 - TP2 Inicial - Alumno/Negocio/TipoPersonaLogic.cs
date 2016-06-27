using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;
namespace Negocio
{
    public class TipoPersonaLogic :NegocioLogic
    {
          
        private TipoPersonaAdapter _TipoPersonaData;
        public TipoPersonaAdapter TipoPersonaData
    {
        get { return _TipoPersonaData; }
        set { _TipoPersonaData = value; }
    }

        public TipoPersonaLogic()
        {
            TipoPersonaData = new TipoPersonaAdapter();
        }

    public TipoPersona GetOne(int ID)
    {
        return TipoPersonaData.GetOne(ID);
    }

    public List<TipoPersona> GetAll()
    {
        try
        {
            return TipoPersonaData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de tipos de personas", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(TipoPersona tipoPersona)
    {
        TipoPersonaData.Save(tipoPersona);
    }

    public void Delete(int ID)
    {
        TipoPersonaData.Delete(ID);
    } 

        
    }
}
