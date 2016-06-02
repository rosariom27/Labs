using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class MateriaLogic: NegocioLogic 
    {
        
        private MateriaAdapter _MateriaData;
        public MateriaAdapter MateriaData
    {
        get { return _MateriaData; }
        set { _MateriaData = value; }
    }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int ID)
    {
        return MateriaData.GetOne(ID);
    }

        public List<Materia> GetAll()
    {
        try
        {
            return MateriaData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de materias", Ex);
            throw ExcepcionManejada;
        }
    }
    
        public void Save(Materia materia)
    {
        MateriaData.Save(materia);
    }

        public void Delete(int ID)
    {
        MateriaData.Delete(ID);
    } 

    }

}
