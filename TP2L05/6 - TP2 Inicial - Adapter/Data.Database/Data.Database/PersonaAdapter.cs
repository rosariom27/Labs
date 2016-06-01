using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter: Adapter
    {
        public List<Persona> GetAll(int tipo)
        {

            try
            {

                this.OpenConnection();
                List<Persona> personas = new List<Persona>();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn); //lleva consulta?
                cmdPersonas.Connection = sqlConn;

                if (tipo != 0)
                {
                    cmdPersonas.CommandText = "GetAllPorTipo_Personas";
                    cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                }
                else
                {
                    cmdPersonas.CommandText = "GetAll_Personas";
                }
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            per.TipoPersona = "No docente";
                            break;
                        case 2:
                            per.TipoPersona = "Alumno";
                            break;
                        case 3:
                            per.TipoPersona = "Docente";
                            break;
                    }
                    per.Plan.ID = (int)drPersonas["id_plan"];
                    per.Plan.Descripcion = (string)drPersonas["desc_plan"];
                    per.Plan.Especialidad.ID = (int)drPersonas["id_especialidad"];
                    per.Plan.Especialidad.Descripcion = (string)drPersonas["desc_especialidad"];
                    personas.Add(per);

                }
                return personas;
                drPersonas.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de personas", Ex);
                throw ExcepcionManejada;
            }

        }

        public List<Persona> GetDocentesPorPlan(int id_plan)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetDocentesPorPlan", sqlConn);
                cmdGetAll.Parameters.Add("@id", SqlDbType.Int).Value = id_plan;
                SqlDataReader drPersonas = cmdGetAll.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona pers = new Persona();
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    pers.TipoPersona = "Docente";
                    pers.Plan.ID = (int)drPersonas["id_plan"];
                    pers.Plan.Descripcion = (string)drPersonas["desc_plan"];
                    pers.Plan.Especialidad.ID = (int)drPersonas["id_especialidad"];
                    pers.Plan.Especialidad.Descripcion = (string)drPersonas["desc_especialidad"];
                    personas.Add(pers);
                }
                drPersonas.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Docentes del Plan.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {

                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            per.TipoPersona = "No docente";
                            break;
                        case 2:
                            per.TipoPersona = "Alumno";
                            break;
                        case 3:
                            per.TipoPersona = "Docente";
                            break;
                    }
                    per.Plan.ID = (int)drPersonas["id_plan"];
                    per.Plan.Descripcion = (string)drPersonas["desc_plan"];
                    per.Plan.Especialidad.ID = (int)drPersonas["id_especialidad"];
                    per.Plan.Especialidad.Descripcion = (string)drPersonas["desc_especialidad"];
                }

                drPersonas.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return per;

        }

        public bool Existe(int leg)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("Existe_Personas", sqlConn);
                cmdGetOne.Parameters.Add("@legajo", SqlDbType.Int).Value = leg;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista esta Persona", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existe;
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Persona persona)
        {
            if (persona.State == Entidad.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == Entidad.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == Entidad.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = Entidad.States.Unmodified;
        }
        
        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido" +
                    "direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac" + "legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan "
                    + "WHERE id_persona=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 3;
                        break;
                }

                cmdSave.Parameters.Add("@idplan", SqlDbType.Int).Value = persona.Plan.ID;
                cmdSave.ExecuteNonQuery();


            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                "values(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdSave.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdSave.Parameters.Add("@idplan", SqlDbType.Int).Value = persona.Plan.ID;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    }
}
