using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class ComisionLogic: NegocioLogic
    {
        private ComisionAdapter _ComisionData;
        public ComisionAdapter ComisionData
    {
        get { return _ComisionData; }
        set { _ComisionData = value; }
    }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

    public Comision GetOne(int ID)
    {
        return ComisionData.GetOne(ID);
    }

    public bool Existe(int id_plan, string desc)
    {
        return ComisionData.Existe(id_plan, desc);
    }

    public List<Comision> GetAll()
    {
        try
        {
            return ComisionData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de comisiones", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Comision comision)
    {
        ComisionData.Save(comision);
    }

    public void Delete(int ID)
    {
        ComisionData.Delete(ID);
    }

    public List<Comision> GetComisionesDisponibles(int IDMateria)
    {
        List<Comision> comisiones = new List<Comision>();
        CursoLogic curlog = new CursoLogic();
        foreach (Curso c in curlog.GetAll())
        {
            if (c.Materia.ID == IDMateria && c.Cupo > 0)
            {
                comisiones.Add(c.Comision);
            }
        }
        return comisiones;
    }

    }
}
