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
                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();
                while (drAlumnos.Read())
                {
                    AlumnoInsrcipcion alu = new AlumnoInsrcipcion();
                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.IDAlumno = (int)drAlumnos["id_alumno"];
                    alu.IDCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (float)drAlumnos["nota"];
          
                    alumnos.Add(alu);

                }

                return alumnos;
                drAlumnos.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos inscripciones", Ex);
                throw ExcepcionManejada;
            }

        }

        public AlumnoInsrcipcion GetOne(int ID)
        {
            AlumnoInsrcipcion alu = new AlumnoInsrcipcion();

            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                if (drAlumnos.Read())
                {
                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.IDAlumno = (int)drAlumnos["id_alumno"];
                    alu.IDCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (float)drAlumnos["nota"];
                }

                drAlumnos.Close();
            
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return alu;

        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_alumno=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno inscipción", Ex);
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

        protected void Update(AlumnoInsrcipcion alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@IDAlumno, id_curso=@IDCurso," +
                    "condicion=@Condicion, nota=@Nota " +
                    "WHERE id_inscripcion=@ID", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@ID", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@IDCurso", SqlDbType.Int).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@Condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@Nota", SqlDbType.Float).Value = alumno.Nota;
                
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del alumno inscripción", Ex);
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
                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                    "values( @IDAlumno, @IDCurso, @Condicion, @Nota) " +
                    "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@ID", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@IDCurso", SqlDbType.Int).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@Condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@Nota", SqlDbType.Float).Value = alumno.Nota;
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el alumno inscripción", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    

    }
}
