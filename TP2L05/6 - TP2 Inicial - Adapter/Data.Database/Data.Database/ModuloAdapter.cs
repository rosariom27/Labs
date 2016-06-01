﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Data.Database
{
    public class ModuloAdapter: Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetAll_Modulos", sqlConn);
                SqlDataReader drModulos = cmdGetAll.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulos["id_modulo"];
                    mod.Descripcion = (string)drModulos["desc_modulo"];
                    mod.Ejecuta = (string)drModulos["ejecuta"];

                    modulos.Add(mod);
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los Modulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }

        public Modulo GetOne(string desc)
        {
            Modulo modulo = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("GetOne_Modulos", sqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                SqlDataReader drModulos = cmdGetOne.ExecuteReader();

                while (drModulos.Read())
                {
                    modulo.ID = (int)drModulos["id_modulo"];
                    modulo.Descripcion = (string)drModulos["desc_modulo"];
                    //modulo.Ejecuta = (string)drModulos["ejecuta"];
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los Modulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }
    }
}
