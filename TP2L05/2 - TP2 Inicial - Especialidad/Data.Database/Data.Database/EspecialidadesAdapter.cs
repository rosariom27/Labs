using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class EspecialidadesAdapter : Adapter
    {

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {

                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad es = new Especialidad();
                    es.ID = (int)drEspecialidades["id_especialidad"];
                    es.Descripcion = (string)drEspecialidades["desc_especialidad"];


                    especialidades.Add(es);

                }

                drEspecialidades.Close();
                this.CloseConnection();
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


            return especialidades;
            // new List<Especialidad>(Especialidades);

        }

        public Especialidad GetOne(int ID)
        {
            Especialidad es = new Especialidad();

            try
            {

                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    es.ID = (int)drEspecialidades["id_especialidad"];
                    es.Descripcion = (string)drEspecialidades["desc_especialidad"];

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


            return es;

        }

        //return Especialidades.Find(delegate(Especialidad es) { return es.ID == ID; });
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

              //Especialidades.Remove(this.GetOne(ID));
        }
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == Entidad.States.New)
            {
                this.Delete(especialidad.ID);
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
    
        

         protected void Update(Especialidad especialidad)
         {
             try
             {
                 this.OpenConnection();
                 SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad" +
                     "WHERE id_especialidad = @ID", sqlConn);

                 cmdSave.Parameters.Add("@ID", SqlDbType.Int).Value = especialidad.ID;
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
                 SqlCommand cmdSave = new SqlCommand("insert into especialidad (id_especialidad, desc_especialidad)" +
                     "values( @ID, @Descripcion)" +
                     "select @@identity", sqlConn);

                 cmdSave.Parameters.Add("@ID", SqlDbType.Int).Value = especialidad.ID;
                 cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                 especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
             }

             catch (Exception Ex)
             {
                 Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                 throw ExcepcionManejada;
             }

             finally
             {
                 this.CloseConnection();
             }
        

        }

            }
}
