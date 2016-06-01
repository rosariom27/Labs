using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter: Adapter
    {
        public List<Comisión> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Comisión> comisiones = new List<Comisión>();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones", sqlConn);

                SqlDataReader drComisiones = cmdComision.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comisión com = new Comisión();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.Plan.ID = (int)drComisiones["id_plan"];
                   
                    comisiones.Add(com);

                }
                return comisiones;
                drComisiones.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de comisiones", Ex);
                throw ExcepcionManejada;
            }

        }

        public Comisión GetOne(int ID)
        {
            Comisión com = new Comisión();

            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.Plan.ID = (int)drComisiones["id_plan"];
                    
                }

                drComisiones.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de comisiones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return com;

        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Comisión comision)
        {
            if (comision.State == Entidad.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == Entidad.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == Entidad.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = Entidad.States.Unmodified;
        }

        public void Update(Comisión comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad," +
                    "id_plan=@id_plan" +
                    "WHERE id_comision=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Bit).Value = comision.Plan.ID;
               
                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comisión comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision, anio_especialidad, id_plan) " +
                "values(@desc_comision, @anio_especialidad, @id_plan)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Bit).Value = comision.Plan.ID;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }
}
