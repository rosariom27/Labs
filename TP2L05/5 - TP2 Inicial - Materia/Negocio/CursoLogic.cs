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
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de cusros", Ex);
            throw ExcepcionManejada;
        }
    }

     public bool Existe(int id_mat, int id_com, int anio)
     {
         return _CursoData.Existe(id_mat, id_com, anio);
     }

     public void Save(Curso curso)
    {
        CursoData.Save(curso);
    }

     public void Delete(int ID)
    {
        CursoData.Delete(ID);
    }

     public List<Curso> GetCursosDocente(int IDDocente)
     {
         return CursoData.GetCursosDocente(IDDocente);
     }

    }
}
