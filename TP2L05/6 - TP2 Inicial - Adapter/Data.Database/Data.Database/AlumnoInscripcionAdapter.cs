using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Entidades;

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
                SqlDataReader drInscripciones = cmdAlumnos.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInsrcipcion ins = new AlumnoInsrcipcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Alumno.ID = (int)drInscripciones["id_alumno"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNac = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    alumnos.Add(ins);
                }
                drInscripciones.Close();
                return alumnos;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las inscripciones.", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

    }

        public List<AlumnoInsrcipcion> GetAll(int IDAlumno)
        {
            List<AlumnoInsrcipcion> inscripciones = new List<AlumnoInsrcipcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@id", sqlConn); //tabla personas o id_alumno
                cmdGetAll.Parameters.Add("@id_pers", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drInscripciones = cmdGetAll.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInsrcipcion ins = new AlumnoInsrcipcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNac = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    ins.Curso.Comision.Descripcion = (string)drInscripciones["desc_comision"];
                    ins.Curso.Materia.Descripcion = (string)drInscripciones["desc_materia"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las inscripciones.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }
                   

        public AlumnoInsrcipcion GetOne(int ID)
        {
            AlumnoInsrcipcion ins = new AlumnoInsrcipcion();

            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdAlumnos.ExecuteReader();

                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNac = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                }

                drInscripciones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;

        }

        public bool Existe(int id_alu, int id_cur)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select from alumnos_inscripciones where id_alumno=@id_alu and id_curso=@id_cur", sqlConn);
                cmdGetOne.Parameters.Add("@id_alu", SqlDbType.Int).Value = id_alu;
                cmdGetOne.Parameters.Add("@id_cur", SqlDbType.Int).Value = id_cur;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista esta Inscripcion", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existe;
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
                Exception ExcepcionManejada = new Exception("Error al eliminar inscipción", Ex);
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
                cmdSave.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = alumno.Alumno.ID;
                cmdSave.Parameters.Add("@IDCurso", SqlDbType.Int).Value = alumno.Curso.ID;
                cmdSave.Parameters.Add("@Condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@Nota", SqlDbType.Float).Value = alumno.Nota;
                
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripción", Ex);
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

                cmdSave.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = alumno.Alumno.ID;
                cmdSave.Parameters.Add("@IDCurso", SqlDbType.Int).Value = alumno.Curso.ID;
                cmdSave.Parameters.Add("@Condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@Nota", SqlDbType.Float).Value = alumno.Nota;
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una nueva inscripción", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    

    }
}
