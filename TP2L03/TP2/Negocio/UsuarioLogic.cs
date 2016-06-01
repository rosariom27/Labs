using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class UsuarioLogic: NegocioLogic
    {

        private UsuarioAdapter _UsuarioData;
    public UsuarioAdapter UsuarioData
    {
        get { return _UsuarioData; }
        set { _UsuarioData = value; }
    }

    public Usuario GetOne(int ID)
    {
        return UsuarioData.GetOne(ID);
    }

    public List<Usuario> GetAll()
    { 
        return UsuarioData.GetAll();     
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
