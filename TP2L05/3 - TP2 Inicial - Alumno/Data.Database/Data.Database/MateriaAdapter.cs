using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    { //REVISAR CONTRA BD
        public List<Materia> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Materia> materias = new List<Materia>();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["////"];
                    mat.HSTotales = (int)drMaterias["////"];
                    mat.IDPlan = (string)drMaterias["////"];
                    

                    materias.Add(mat);

                }
                return materias;
                drMaterias.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de materias", Ex);
                throw ExcepcionManejada;
            }

        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {

                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["////"];
                    mat.HSTotales = (int)drMaterias["////"];
                    mat.IDPlan = (string)drMaterias["////"];

                }

                drMaterias.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return mat;

        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Materia materia)
        {
            if (materia.State == Entidad.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == Entidad.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == Entidad.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = Entidad.States.Unmodified;
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET nombre_usuario=@nombre_usuario, clave=@clave," +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "WHERE id_usuario=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_maeteria", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@HSSemanales", SqlDbType.Int, 50).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@HSTotales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@IDPlan", SqlDbType.Int, 50).Value = materia.Plan.ID;
 
                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into materias (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@HSSemanales", SqlDbType.VarChar, 50).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@HSTotales", SqlDbType.Bit).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@IDPlan", SqlDbType.VarChar, 50).Value = materia.Plan.ID;
           
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }








    }
}
