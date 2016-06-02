using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class CursoLogic: NegocioLogic
    {
        private CursoAdapter _CursoData;
        public CursoAdapter CursoData
    {
        get { return _CursoData; }
        set { _CursoData = value; }
    }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

    public Curso GetOne(int ID)
    {
        return CursoData.GetOne(ID);
    }

    public List<Curso> GetAll()
    {
        try
        {
            return CursoData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de cursos", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Curso curso)
    {
        CursoData.Save(curso);
    }

    public void Delete(int ID)
    {
        CursoData.Delete(ID);
    } 

    }

}
