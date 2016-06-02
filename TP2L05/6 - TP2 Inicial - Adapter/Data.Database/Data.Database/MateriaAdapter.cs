﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {

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
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    mat.Plan.Descripcion = (string)drMaterias["desc_plan"];
                    mat.Plan.Especialidad.ID = (int)drMaterias["id_especialidad"];
                    mat.Plan.Especialidad.Descripcion = (string)drMaterias["desc_especialidad"];
                    materias.Add(mat);
   
                }
                return materias;
                drMaterias.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de las materias", Ex);
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
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    mat.Plan.Descripcion = (string)drMaterias["desc_plan"];
                    mat.Plan.Especialidad.ID = (int)drMaterias["id_especialidad"];
                    mat.Plan.Especialidad.Descripcion = (string)drMaterias["desc_especialidad"];
                }

                drMaterias.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return mat;

        }

        public bool Existe(int id_plan, string desc)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select from materias where id_plan=@id_plan and desc_materia=@desc", sqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdGetOne.Parameters.Add("@id_plan", SqlDbType.Int).Value = id_plan;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista esta Materia", e);
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

                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET id_materia=@id_materia, desc_materia=@desc_materia," +
                    "hs_semanales=@hs_semanales, hs_totales=@hs_totales, id_plan=@id_plan " +
                    "WHERE id_materia=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.VarChar, 50).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Bit).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = materia.IdPlan;

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

                SqlCommand cmdSave = new SqlCommand("insert into materias (id_materia, desc_materia, hs_semanales, hs_totales, id_plan) " +
                "values(@id_materia, @desc_materia, @hs_semanales, @hs_totales, @id_plan)" + " select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.VarChar, 50).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Bit).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.Plan.ID;
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

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetMateriasParaInscripcion = new SqlCommand("select from materias where id_plan=@IDPlan and id_ ", sqlConn);
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drMaterias = cmdGetMateriasParaInscripcion.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias disponibles para el alumno.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

    }
}