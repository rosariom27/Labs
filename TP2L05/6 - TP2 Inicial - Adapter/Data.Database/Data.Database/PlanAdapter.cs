using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Plan> planes = new List<Plan>();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan p = new Plan();
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drPlanes["id_especialidad"];
                    esp.Descripcion = (string)drPlanes["desc_especialidad"];
                    p.Especialidad = esp;
                    planes.Add(p);
                }
                return planes;
                drPlanes.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los planes", Ex);
                throw ExcepcionManejada;
            }

        }

        public Plan GetOne(int ID)
        {
            Plan p = new Plan();

            try
            {

                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    p.Especialidad.ID = (int)drPlanes["id_especialidad"];
                    p.Especialidad.Descripcion = (string)drPlanes["desc_especialidad"];           
                }

                drPlanes.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return p;

        }

        public bool Existe(string desc, int esp)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("Existe_Planes", sqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdGetOne.Parameters.Add("@id_esp", SqlDbType.Int).Value = esp;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista este plan", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete from planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Plan plan)
        {
            if (plan.State == Entidad.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == Entidad.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == Entidad.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = Entidad.States.Unmodified;
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad " +
                    "WHERE id_plan=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.Especialidad.ID;
               
                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan, id_especialidad) " +
                "values(@desc_plan, @id_especialidad) " + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.Especialidad.ID;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear un nuevo plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    }
}
