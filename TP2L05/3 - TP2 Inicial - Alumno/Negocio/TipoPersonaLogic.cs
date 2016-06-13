using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoPersonaLogic :NegocioLogic
    {
          private TipoPersonaAdapter _TipoPersonaData;
          public TipoPersonaAdapter TipoPersonaData  //falta
    {
        get { return _TipoPersonaData; }
        set { _TipoPersonaData = value; }
    }

        public TipoPersonaLogic()
        {
            TipoPersonaData = new TipoPersonaAdapter();
        }

    public Usuario GetOne(int ID)
    {
        return UsuarioData.GetOne(ID);
    }

    public List<Usuario> GetAll()
    {
        try
        {
            return UsuarioData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de usuarios", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Usuario usuario)
    {
        UsuarioData.Save(usuario);
    }

    public void Delete(int ID)
    {
        UsuarioData.Delete(ID);
    } 


        
    }
}
