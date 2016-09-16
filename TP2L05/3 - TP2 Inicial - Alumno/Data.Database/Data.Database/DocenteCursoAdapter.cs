using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter: Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            try
            {
                this.OpenConnection();
                List<DocenteCurso> docursos = new List<DocenteCurso>();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos", sqlConn);

                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                while (drDocentesCursos.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocentesCursos["id_dictado"];
                    dc.Curso.ID = (int)drDocentesCursos["id_curso"];
                    dc.Persona.ID = (int)drDocentesCursos["id_docente"];

                    docursos.Add(dc);
                }
                return docursos;
                drDocentesCursos.Close();
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de dictado", Ex);
                throw ExcepcionManejada;
            }
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDocentesCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();

                if (drDocentesCursos.Read())
                {
                    dc.ID = (int)drDocentesCursos["id_dictado"];
                    dc.Curso.ID = (int)drDocentesCursos["id_curso"];
                    dc.Persona.ID = (int)drDocentesCursos["id_docente"];
                }

                drDocentesCursos.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de dictados", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return dc;

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == Entidad.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == Entidad.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == Entidad.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = Entidad.States.Unmodified;
        }

        public void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente," +
                "WHERE id_dictado=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = dc.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = dc.Persona.ID;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", Ex);
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

                SqlCommand cmdSave = new SqlCommand(" insert into docentes_cursos (id_curso, id_docente) " +
                " values(@id_curso, @id_docente) " + " select @@identity ", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Persona.ID;
                
                dc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear dictado", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }

}
