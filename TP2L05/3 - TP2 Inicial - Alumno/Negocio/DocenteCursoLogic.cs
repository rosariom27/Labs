using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class DocenteCursoLogic: NegocioLogic
    {
        private DocenteCursoAdapter _docenteCursoData;
        public DocenteCursoAdapter DocenteCursoData
    {
        get { return _docenteCursoData; }
        set { _docenteCursoData = value; }
    }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

    public DocenteCurso GetOne(int ID)
    {
        return DocenteCursoData.GetOne(ID);
    }

    public List<DocenteCurso> GetAll()
    {
        try
        {
            return DocenteCursoData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de dictados", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(DocenteCurso dc)
    {
        DocenteCursoData.Save(dc);
    }

    public void Delete(int ID)
    {
        DocenteCursoData.Delete(ID);
    } 

    }

}
