﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Data.Database
{
    public class DocenteCursoAdapter: Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            
            try
            {
                this.OpenConnection();
                List<DocenteCurso> docentes = new List<DocenteCurso>();
                SqlCommand cmdGetAll = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDocentes = cmdGetAll.ExecuteReader();
                while (drDocentes.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    dc.Curso.ID = (int)drDocentes["id_curso"];
                    dc.Curso.AnioCalendario = (int)drDocentes["anio_calendario"];
                    dc.Curso.Cupo = (int)drDocentes["cupo"];
                    dc.Docente.ID = (int)drDocentes["id_persona"];
                    dc.Docente.Nombre = (string)drDocentes["nombre"];
                    dc.Docente.Apellido = (string)drDocentes["apellido"];
                    dc.Docente.Email = (string)drDocentes["email"];
                    dc.Docente.Direccion = (string)drDocentes["direccion"];
                    dc.Docente.Telefono = (string)drDocentes["telefono"];
                    dc.Docente.FechaNac = (DateTime)drDocentes["fecha_nac"];
                    dc.Docente.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            dc.Docente.TipoPersona = "No docente";
                            break;
                        case 2:
                            dc.Docente.TipoPersona = "Alumno";
                            break;
                        case 3:
                            dc.Docente.TipoPersona = "Docente";
                            break;
                    }
                    dc.Docente.Plan.ID = (int)drDocentes["id_plan"];
                    docentes.Add(dc);
                }
                drDocentes.Close();
                return docentes;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los docentes.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select from docentes_cursos where id_dictado=@id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentes = cmdGetOne.ExecuteReader();
                if (drDocentes.Read())
                {
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    dc.Curso.ID = (int)drDocentes["id_curso"];
                    dc.Docente.ID = (int)drDocentes["id_persona"];
                    dc.Docente.Nombre = (string)drDocentes["nombre"];
                    dc.Docente.Apellido = (string)drDocentes["apellido"];
                    dc.Docente.Email = (string)drDocentes["email"];
                    dc.Docente.Direccion = (string)drDocentes["direccion"];
                    dc.Docente.Telefono = (string)drDocentes["telefono"];
                    dc.Docente.FechaNac = (DateTime)drDocentes["fecha_nac"];
                    dc.Docente.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            dc.Docente.TipoPersona = "No docente";
                            break;
                        case 2:
                            dc.Docente.TipoPersona = "Alumno";
                            break;
                        case 3:
                            dc.Docente.TipoPersona = "Docente";
                            break;
                    }
                    dc.Docente.Plan.ID = (int)drDocentes["id_plan"];
                }

                drDocentes.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Docente.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        public bool Existe(int id_cur, int id_doc, string cargo)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select from docentes_cursos where id_curso=@id_cur and id_docente=@id_doc and cargo=@cargo", sqlConn);
                cmdGetOne.Parameters.Add("@id_cur", SqlDbType.Int).Value = id_cur;
                cmdGetOne.Parameters.Add("@id_doc", SqlDbType.Int).Value = id_doc;
                switch (cargo)
                {
                    case "Titular":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista este Docente asignado", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Docente.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo" +
                    "WHERE id_dictado=@ID", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdUpdate.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                switch (dc.Cargo)
                {
                    case "Titular":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into docentes_cursos (id_curso, id_docente, cargo) " +
                    "values( @id_curso, @id_docente, @cargo) " +
                    "select @@identity", sqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                switch (dc.Cargo)
                {
                    case "Titular":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                dc.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear un nuevo dictado.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == Entidad.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == Entidad.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == Entidad.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = Entidad.States.Unmodified;
        }
    }
}
