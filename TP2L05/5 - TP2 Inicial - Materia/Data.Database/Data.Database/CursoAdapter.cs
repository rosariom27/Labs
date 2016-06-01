using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

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
                 // cur.Descripcion = (string)drCursos["BD"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];

                    cursos.Add(cur);

                }
                
                drCursos.Close();
                return cursos;
            }

            catch ( Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
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
                 // cur.Descripcion = (string)drCursos["BD"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];

                }

                drCursos.Close();
                
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return cur; 
            
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

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50 ).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
            //  cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.IDMateria;

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
            
            SqlCommand cmdSave = new SqlCommand("insert into cursos (id_curso, id_materia, id_comision, anio_calendario, cupo) " +
                " values(@id_curso, @id_materia, @id_comision, @anio_calendario, @cupo)", sqlConn); 

            this.OpenConnection();

                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.VarChar, 50 ).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
            //  cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = curso.IDMateria;
            	curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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
    }
    
}

