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

        public Comisión GetOne(int ID)
    {
        return ComisionData.GetOne(ID);
    }

        public List<Comisión> GetAll()
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

        public void Save(Comisión comision)
    {
        ComisionData.Save(comision);
    }

        public void Delete(int ID)
    {
        ComisionData.Delete(ID);
    } 

    }
}
