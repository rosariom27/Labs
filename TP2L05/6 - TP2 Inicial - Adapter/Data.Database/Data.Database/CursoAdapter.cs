using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Data.Database
{
   public class CursoAdapter:Adapter
    {
  
    public List<Curso> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Curso> cursos = new List<Curso>();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia.ID = (int)drCursos["id_materia"];
                    cur.Materia.Descripcion = (string)drCursos["desc_materia"];
                    cur.Materia.HsSemanales = (int)drCursos["hs_semanales"];
                    cur.Materia.HsTotales = (int)drCursos["hs_totales"];
                    cur.Materia.Plan.ID = (int)drCursos["id_plan"];
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Comision.Descripcion = (string)drCursos["desc_comision"];
                    cur.Comision.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Comision.Plan.ID = (int)drCursos["id_plan"];
                    cursos.Add(cur);

                }
                
                drCursos.Close();
                return cursos;
            }

            catch ( Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
                       
        }

    public Curso GetOne(int ID)
        {
            Curso cur = new Curso();

            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia.ID = (int)drCursos["id_materia"];
                    cur.Materia.Descripcion = (string)drCursos["desc_materia"];
                    cur.Materia.HsSemanales = (int)drCursos["hs_semanales"];
                    cur.Materia.HsTotales = (int)drCursos["hs_totales"];
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Comision.Descripcion = (string)drCursos["desc_comision"];
                    cur.Comision.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Comision.Plan.ID = (int)drCursos["id_plan"];
                    cur.Comision.Plan.Descripcion = (string)drCursos["desc_plan"];
                    cur.Comision.Plan.Especialidad.ID = (int)drCursos["id_especialidad"];
                    cur.Comision.Plan.Especialidad.Descripcion = (string)drCursos["desc_especialidad"];

                }

                drCursos.Close();
                
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return cur; 
            
        }

    public bool Existe(int id_mat, int id_com, int anio)
    {
        bool existe;
        try
        {
            this.OpenConnection();
            SqlCommand cmdGetOne = new SqlCommand("select from cursos where id_materia=@id_mat and id_comision=@id_com and anio_calendario=@anio", sqlConn);
            cmdGetOne.Parameters.Add("@id_mat", SqlDbType.Int).Value = id_mat;
            cmdGetOne.Parameters.Add("@id_com", SqlDbType.Int).Value = id_com;
            cmdGetOne.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
        }
        catch (Exception e)
        {
            Exception ExcepcionManejada = new Exception("Error al validar que no exista este Curso", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            
        }

    public void Save(Curso curso)
        {
            if (curso.State == Entidad.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == Entidad.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == Entidad.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = Entidad.States.Unmodified;            
        }
    
    public void Update(Curso curso )
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE curso SET id_curso=@id_curso, id_materia=@id_materia," + 
                    "id_comision=@id_comision, anio_calendario=@anio_calendario, cupo=@cupo " + 
                    "WHERE id_curso=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50 ).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.Comision.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.Materia.ID;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    public void Insert(Curso curso)
          {
                  
            try
            {

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos (id_curso, id_materia, id_comision, anio_calendario, cupo) " +
                " values(@id_curso, @id_materia, @id_comision, @anio_calendario, @cupo)", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50 ).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.Comision.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.Materia.ID;
            	//curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }

        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
            throw ExcepcionManejada;
        }

        finally
        {
            this.CloseConnection();
        }
    }

    public List<Curso> GetCursosDocente(int IDDocente)
    {
        List<Curso> cursosDocente = new List<Curso>();
        try
        {
            this.OpenConnection();
            SqlCommand cmdCursosDocente = new SqlCommand("select from docente_cursos where id_docente=@IDDocente", sqlConn);
            cmdCursosDocente.Parameters.Add("@id", SqlDbType.Int).Value = IDDocente;
            SqlDataReader drCursosDocente = cmdCursosDocente.ExecuteReader();

            while (drCursosDocente.Read())
            {
                Curso cur = new Curso();
                cur.ID = (int)drCursosDocente["id_curso"];
                cur.AnioCalendario = (int)drCursosDocente["anio_calendario"];
                cur.Cupo = (int)drCursosDocente["cupo"];
                cur.Materia.ID = (int)drCursosDocente["id_materia"];
                cur.Materia.Descripcion = (string)drCursosDocente["desc_materia"];
                cur.Materia.HsSemanales = (int)drCursosDocente["hs_semanales"];
                cur.Materia.HsTotales = (int)drCursosDocente["hs_totales"];
                cur.Materia.Plan.ID = (int)drCursosDocente["id_plan"];
                cur.Comision.ID = (int)drCursosDocente["id_comision"];
                cur.Comision.Descripcion = (string)drCursosDocente["desc_comision"];
                cur.Comision.AnioEspecialidad = (int)drCursosDocente["anio_especialidad"];
                cur.Comision.Plan.ID = (int)drCursosDocente["id_plan"];
                cursosDocente.Add(cur);
            }
        }
        catch (Exception e)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar los cursos del docente.", e);
            throw ExcepcionManejada;
        }
        finally
        {
            this.CloseConnection();
        }
        return cursosDocente;
    }
    }
    
}

