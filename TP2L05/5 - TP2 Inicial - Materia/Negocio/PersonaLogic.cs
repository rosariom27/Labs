using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class PersonaLogic: NegocioLogic
    {
         private PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData
    {
        get { return _PersonaData; }
        set { _PersonaData = value; }
    }

        public PersonaLogic()
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

    public bool Existe(int leg)
    {
        return _PersonaData.Existe(leg);
    }

    public void Save(Persona persona)
    {
        PersonaData.Save(persona);
    }

    public void Delete(int ID)
    {
        PersonaData.Delete(ID);
    }

    public List<Persona> GetNoDocentes()
    {
        return PersonaData.GetAll(1);
    }

    public List<Persona> GetAlumnos()
    {
        return PersonaData.GetAll(2);
    }

    public List<Persona> GetDocentes()
    {
        return PersonaData.GetAll(3);
    }

    public List<Persona> GetDocentesPorPlan(int id_plan)
    {
        return PersonaData.GetDocentesPorPlan(id_plan);
    }
    }
}
