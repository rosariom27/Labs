using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {

        public List<AlumnoInsrcipcion> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<AlumnoInsrcipcion> alumnos = new List<AlumnoInsrcipcion>();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from ///", sqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInsrcipcion aluins = new AlumnoInsrcipcion();
                    aluins.ID = (int)drAlumnosInscripciones["///"];
                    aluins.IDAlumno = (int)drAlumnosInscripciones["///"];
                    aluins.IDCurso = (int)drAlumnosInscripciones["///"];
                    aluins.Nota = (float)drAlumnosInscripciones["///"];
                    aluins.Condicion = (string)drAlumnosInscripciones["///"];
                   

                    alumnos.Add(aluins);

                }
                return alumnos;
                drAlumnosInscripciones.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
                throw ExcepcionManejada;
            }

        }

        public AlumnoInsrcipcion GetOne(int ID)
        {
            AlumnoInsrcipcion aluins = new AlumnoInsrcipcion();

            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos where id_usuario=@id", sqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                if (drAlumnosInscripciones.Read())
                {
                    aluins.ID = (int)drAlumnosInscripciones["////"];
                    aluins.IDAlumno = (int)drAlumnosInscripciones["///"];
                    aluins.IDCurso = (int)drAlumnosInscripciones["///"];
                    aluins.Nota = (float)drAlumnosInscripciones["///"];
                    aluins.Condicion = (string)drAlumnosInscripciones["///"];
              
                }

                drAlumnosInscripciones.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return aluins;

        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from alumnos where ////=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(AlumnoInsrcipcion alumno)
        {
            if (alumno.State == Entidad.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == Entidad.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == Entidad.States.Modified)
            {
                this.Update(alumno);
            }
            alumno.State = Entidad.States.Unmodified;
        }

        public void Update(AlumnoInsrcipcion alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave," +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "WHERE id_usuario=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = alumno.Nota;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Condicion;
     
                cmdSave.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInsrcipcion alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into alumnos (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = alumno.Nota;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Condicion;
     
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }





    }
}
