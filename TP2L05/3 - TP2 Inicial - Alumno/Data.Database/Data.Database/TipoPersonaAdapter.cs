using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class TipoPersonaAdapter: Adapter
    {
        public List<TipoPersona> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<TipoPersona> tipopersonas = new List<TipoPersona>();
                SqlCommand cmdTipoPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drTipoPersonas = cmdTipoPersonas.ExecuteReader();

                while (drTipoPersonas.Read())
                {
                    TipoPersona tp = new TipoPersona();
                    tp.ID = (int)drTipoPersonas["tipo_persona"];
                    
                    tipopersonas.Add(tp);

                }
                return tipopersonas;
                drTipoPersonas.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de tipos de personas", Ex);
                throw ExcepcionManejada;
            }

        }

        public TipoPersona GetOne(int ID)
        {
            TipoPersona tp = new TipoPersona();

            try
            {

                this.OpenConnection();

                SqlCommand cmdTipoPersonas = new SqlCommand("select * from personas where tipo_persona=@id", sqlConn);
                cmdTipoPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drTipoPersonas = cmdTipoPersonas.ExecuteReader();

                if (drTipoPersonas.Read())
                {
                    tp.ID = (int)drTipoPersonas["tipo_persona"];

                }

                drTipoPersonas.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de tipos de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return tp;

        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from personas where tipo_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el tipo de persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(TipoPersona tipopersona)
        {
            if (tipopersona.State == Entidad.States.New)
            {
                this.Insert(tipopersona);
            }
            else if (tipopersona.State == Entidad.States.Deleted)
            {
                this.Delete(tipopersona.ID);
            }
            else if (tipopersona.State == Entidad.States.Modified)
            {
                this.Update(tipopersona);
            }
            tipopersona.State = Entidad.States.Unmodified;
        }

        public void Update(TipoPersona tipopersona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET tipo_persona=@tipo_persona" +
                    "WHERE tipo_persona=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = tipopersona.ID;
                
                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del tipo de persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(TipoPersona tipopersona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into personas (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = tipopersona.NombreUsuario;
                
                tipopersona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }
}
