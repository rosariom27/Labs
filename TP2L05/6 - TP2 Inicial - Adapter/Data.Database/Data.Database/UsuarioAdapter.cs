using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        /*     #region DatosEnMemoria
             // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
             // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
             private static List<Usuario> _Usuarios;

             private static List<Usuario> Usuarios
             {
                 get
                 {
                     if (_Usuarios == null)
                     {
                         _Usuarios = new List<Usuario>();
                         Usuario usr;
                         usr = new Usuario();
                         usr.ID = 1;
                         usr.State = Entidad.States.Unmodified;
                         usr.Nombre = "Casimiro";
                         usr.Apellido = "Cegado";
                         usr.NombreUsuario = "casicegado";
                         usr.Clave = "miro";
                         usr.Email = "casimirocegado@gmail.com";
                         usr.Habilitado = true;
                         _Usuarios.Add(usr);

                         usr = new Usuario();
                         usr.ID = 2;
                         usr.State = Entidad.States.Unmodified;
                         usr.Nombre = "Armando Esteban";
                         usr.Apellido = "Quito";
                         usr.NombreUsuario = "aequito";
                         usr.Clave = "carpintero";
                         usr.Email = "armandoquito@gmail.com";
                         usr.Habilitado = true;
                         _Usuarios.Add(usr);

                         usr = new Usuario();
                         usr.ID = 3;
                         usr.State = Entidad.States.Unmodified;
                         usr.Nombre = "Alan";
                         usr.Apellido = "Brado";
                         usr.NombreUsuario = "alanbrado";
                         usr.Clave = "abrete sesamo";
                         usr.Email = "alanbrado@gmail.com";
                         usr.Habilitado = true;
                         _Usuarios.Add(usr);

                     }
                     return _Usuarios;
                 }
             }
             #endregion   */

        public List<Usuario> GetAll()
        {

            try
            {

                this.OpenConnection();
                List<Usuario> usuarios = new List<Usuario>();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usr.Persona.Plan.ID = (int)drUsuarios["id_plan"];
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
                    usr.Persona.Direccion = (string)drUsuarios["direccion"];
                    usr.Persona.Telefono = (string)drUsuarios["telefono"];
                    usr.Persona.FechaNac = (DateTime)drUsuarios["fecha_nac"];
                    usr.Persona.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.Persona.TipoPersona = "No docente";
                            break;
                        case 2:
                            usr.Persona.TipoPersona = "Alumno";
                            break;
                        case 3:
                            usr.Persona.TipoPersona = "Docente";
                            break;
                    }
                    usuarios.Add(usr);
                }
                return usuarios;
                drUsuarios.Close();
                this.CloseConnection();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }

        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {

                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usr.Persona.Plan.ID = (int)drUsuarios["id_plan"];
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
                    usr.Persona.Direccion = (string)drUsuarios["direccion"];
                    usr.Persona.Telefono = (string)drUsuarios["telefono"];
                    usr.Persona.FechaNac = (DateTime)drUsuarios["fecha_nac"];
                    usr.Persona.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.Persona.TipoPersona = "No docente";
                            break;
                        case 2:
                            usr.Persona.TipoPersona = "Alumno";
                            break;
                        case 3:
                            usr.Persona.TipoPersona = "Docente";
                            break;
                    }
                }

                drUsuarios.Close();
                

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return usr;

        }

        public bool Existe(string nom_usu)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("Existe_Usuarios", sqlConn);
                cmdGetOne.Parameters.Add("@usuario", SqlDbType.VarChar).Value = nom_usu;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista este Usuario", e);
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
                ModuloUsuarioAdapter muadapter = new ModuloUsuarioAdapter();
                foreach (ModuloUsuario mu in muadapter.GetPermisos(ID))
                    muadapter.Delete(mu.ID);
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete_Usuarios", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == Entidad.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == Entidad.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == Entidad.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = Entidad.States.Unmodified;
        }

        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave," +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "WHERE id_usuario=@id", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdSave.ExecuteNonQuery();

                ModuloUsuarioAdapter muadapter = new ModuloUsuarioAdapter();
                foreach (ModuloUsuario mu in usuario.ModulosUsuarios)
                {
                    mu.State = Entidad.States.Modified;
                    muadapter.Save(mu);
                }
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email)" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                usuario.ID = Convert.ToInt32(cmdSave.ExecuteScalar());

                ModuloUsuarioAdapter muadapter = new ModuloUsuarioAdapter();
                foreach (ModuloUsuario mu in usuario.ModulosUsuarios)
                {
                    mu.State = Entidad.States.New;
                    mu.IdUsuario = usuario.ID;
                    muadapter.Save(mu);
                }
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        public Usuario GetUsuarioForLogin(string user, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand GetUsuarioForLogin = new SqlCommand("Login_Usuarios", sqlConn);
                GetUsuarioForLogin.CommandType = CommandType.StoredProcedure;
                GetUsuarioForLogin.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                GetUsuarioForLogin.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drUsuarios = GetUsuarioForLogin.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usr.Persona.Plan.ID = (int)drUsuarios["id_plan"];
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
                    usr.Persona.Direccion = (string)drUsuarios["direccion"];
                    usr.Persona.Telefono = (string)drUsuarios["telefono"];
                    usr.Persona.FechaNac = (DateTime)drUsuarios["fecha_nac"];
                    usr.Persona.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.Persona.TipoPersona = "No docente";
                            break;
                        case 2:
                            usr.Persona.TipoPersona = "Alumno";
                            break;
                        case 3:
                            usr.Persona.TipoPersona = "Docente";
                            break;
                    }
                }

                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

    }
}