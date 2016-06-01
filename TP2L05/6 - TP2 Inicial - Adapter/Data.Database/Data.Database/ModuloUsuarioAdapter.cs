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
    public class ModuloUsuarioAdapter: Adapter
    {
        public List<ModuloUsuario> GetAll(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetAll_ModulosUsuarios", sqlConn);
                cmdGetAll.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = drModulosUsuarios.IsDBNull(2) ? modusu.ID = 0 : (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = drModulosUsuarios.IsDBNull(7) ? modusu.IdUsuario = idUsuario : (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = drModulosUsuarios.IsDBNull(3) ? modusu.PermiteAlta = false : (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = drModulosUsuarios.IsDBNull(4) ? modusu.PermiteBaja = false : (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = drModulosUsuarios.IsDBNull(5) ? modusu.PermiteModificacion = false : (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = drModulosUsuarios.IsDBNull(6) ? modusu.PermiteConsulta = false : (bool)drModulosUsuarios["consulta"];
                    modusu.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    modusu.Modulo.Descripcion = (string)drModulosUsuarios["desc_modulo"];
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los permisos.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        public List<ModuloUsuario> GetPermisos(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetPermisos_ModulosUsuarios", sqlConn);
                cmdGetAll.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modusu.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    modusu.Modulo.Descripcion = (string)drModulosUsuarios["desc_modulo"];
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los permisos.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modusu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("GetOne_Modulos_Usuarios", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdGetOne.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modusu.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Modulo Usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modusu;
        }

        protected void Update(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("Update_ModulosUsuarios", sqlConn);
                
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modusu.ID;
                cmdUpdate.Parameters.Add("@idmodulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdUpdate.Parameters.Add("@idusuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdUpdate.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdUpdate.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("Insert_ModulosUsuarios", sqlConn);
                
                cmdInsert.Parameters.Add("@idmodulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdInsert.Parameters.Add("@idusuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdInsert.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdInsert.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                modusu.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una permiso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete_Modulos_Usuarios", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el permiso", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modusu)
        {
            if (modusu.State == Entidad.States.New)
            {
                this.Insert(modusu);
            }
            else if (modusu.State == Entidad.States.Modified)
            {
                this.Update(modusu);
            }
            modusu.State = Entidad.States.Unmodified;
        }
    }
}
