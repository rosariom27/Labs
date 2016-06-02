using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class PlanLogic: NegocioLogic
    {
        private PlanAdapter _PlanData;
        public PlanAdapter PlanData
    {
        get { return _PlanData; }
        set { _PlanData = value; }
    }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

    public Plan GetOne(int ID)
    {
        return PlanData.GetOne(ID);
    }

    public List<Plan> GetAll()
    {
        try
        {
            return PlanData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de planes", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Plan plan)
    {
        PlanData.Save(plan);
    }

    public void Delete(int ID)
    {
        PlanData.Delete(ID);
    } 




    }
}
