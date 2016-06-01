using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Data.Database
{
    public class ComisionAdapter: Adapter
    {
        public List<Comision> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Comision> comisiones = new List<Comision>();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision comi = new Comision();
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.Plan.ID = (int)drComisiones["id_plan"];
                    comi.Plan.Descripcion = (string)drComisiones["desc_plan"];
                    comi.Plan.Especialidad.ID = (int)drComisiones["id_especialidad"];
                    comi.Plan.Especialidad.Descripcion = (string)drComisiones["desc_especialidad"];
                    comisiones.Add(comi);

                }
                return comisiones;
                drComisiones.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las comisiones", Ex);
                throw ExcepcionManejada;
            }

        }

        public Comision GetOne(int ID)
        {
            Comision comi = new Comision();

            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.Plan.ID = (int)drComisiones["id_plan"];
                    comi.Plan.Descripcion = (string)drComisiones["desc_plan"];
                    comi.Plan.Especialidad.ID = (int)drComisiones["id_especialidad"];
                    comi.Plan.Especialidad.Descripcion = (string)drComisiones["desc_especialidad"];
                   
                }

                drComisiones.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comisión", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return comi;

        }

        public bool Existe(int id_plan, string desc)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select from comisiones where id_plan=@id_plan and desc_comision=@desc", sqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdGetOne.Parameters.Add("@id_plan", SqlDbType.Int).Value = id_plan;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista esta Comision", e);
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

        public void Save(Comision comision)
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

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad," +
                    "id_plan=@id_plan " +
                    "WHERE id_comision=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.Plan.ID;
           
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

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision, anio_especialidad, id_plan) " +
                "values(@desc_comision, @anio_especialidad, @id_plan)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.Plan.ID;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    }
}
