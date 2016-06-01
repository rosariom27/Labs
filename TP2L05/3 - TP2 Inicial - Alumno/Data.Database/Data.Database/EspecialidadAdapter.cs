using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter 
    {


        public List<Especialidad> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Especialidad> especialidades = new List<Especialidad>();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(esp);

                }
                return especialidades;
                drEspecialidades.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
                throw ExcepcionManejada;
            }

        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();

            try
            {

                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad=@id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                 
                }

                drEspecialidades.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return esp; 

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from especialidades where id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == Entidad.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == Entidad.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == Entidad.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = Entidad.States.Unmodified;
        }

        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc_especialidad" +
                    "WHERE id_especialidad=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                

                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into especialidades (desc_especialidad) " +
                "values(@desc_especialidad)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
               
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }



    }
}
