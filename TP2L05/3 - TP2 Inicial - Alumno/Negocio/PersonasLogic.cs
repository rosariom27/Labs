using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class PersonasLogic: NegocioLogic
    {
        private PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData
    {
        get { return _PersonaData; }
        set { _PersonaData = value; }
    }

        public PersonasLogic()
        {
            PersonaData = new PersonaAdapter();
        }

    public Persona GetOne(int ID)
    {
        return PersonaData.GetOne(ID);
    }

    public List<Persona> GetAll()
    {
        try
        {
            return PersonaData.GetAll();
        }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar listas de personas", Ex);
            throw ExcepcionManejada;
        }
    }

    
    public void Save(Persona persona)
    {
        PersonaData.Save(persona);
    }

    public void Delete(int ID)
    {
        PersonaData.Delete(ID);
    } 
    }
}
