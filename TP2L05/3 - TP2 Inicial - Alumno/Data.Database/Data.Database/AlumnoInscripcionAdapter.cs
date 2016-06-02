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
        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                this.OpenConnection();
                List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();
                    alu.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    alu.Persona.ID = (int)drAlumnosInscripciones["id_alumno"];
                    alu.Curso.ID = (int)drAlumnosInscripciones["id_curso"];
                    alu.Nota = (int)drAlumnosInscripciones["nota"];
                    alu.Condicion = (string)drAlumnosInscripciones["condicion"];
                   

                    alumnos.Add(alu);

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

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alu = new AlumnoInscripcion();

            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                if (drAlumnosInscripciones.Read())
                {
                    alu.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    alu.Persona.ID = (int)drAlumnosInscripciones["id_alumno"];
                    alu.Curso.ID = (int)drAlumnosInscripciones["id_curso"];
                    alu.Nota = (int)drAlumnosInscripciones["nota"];
                    alu.Condicion = (string)drAlumnosInscripciones["condicion"];
              
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


            return alu;

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
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

        public void Save(AlumnoInscripcion alumno)
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

        public void Update(AlumnoInscripcion alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@id_alumno, id_curso=@id_curso," +
                    "condicion=@condicion, nota=@nota " +
                    "WHERE id_inscripcion=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.VarChar, 50).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Bit).Value = alumno.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
     
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

        protected void Insert(AlumnoInscripcion alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                "values(@id_alumno, @id_curso, @condicion, @nota)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.VarChar, 50).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Bit).Value = alumno.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
     
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
