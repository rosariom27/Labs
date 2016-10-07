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
              //  SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                  
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre"]; // ["nombre_usuario"]
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];

                    
                 
                    usuarios.Add(usr);
                }
                return usuarios;
                drUsuarios.Close();
                this.CloseConnection();
            }

          catch (Exception Ex)
          {
              Exception ExcepcionManejada = new Exception("Error al recuperar listas de usuarios", Ex);
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
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }

                drUsuarios.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return usr;

        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                
                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
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
                this.Insert(usuario);  //La Persona llega en null si creamos en Usuario la relacion a la entidad de persona
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

        public void Update(Usuario usuario) //ver seteo
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave," +
                    "habilitado=@habilitado, id_persona=@id_persona " +
                    " WHERE id_usuario=@id ", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
               
             
                cmdSave.ExecuteNonQuery();

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
                
                SqlCommand cmdSave = new SqlCommand("insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona ) " +
                "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona )" + "select @@identity", sqlConn);

                cmdSave.CommandType = CommandType.Text;

                
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;

                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Persona.Email;
             
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                
                
                
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

        public Usuario GetUsuarioForLogin(string us, string pass)
        {
            Usuario u = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios WHERE clave=@clave and nombre_usuario=@nombre ", sqlConn);
                cmdUsuario.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = pass;
                cmdUsuario.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = us;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();

                while (drUsuarios.Read())
                {
                    u.ID = (int)drUsuarios["id_usuario"];
                    u.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    u.Clave = (string)drUsuarios["clave"];
                    u.Habilitado = (bool)drUsuarios["habilitado"];
                    u.IDPersona = (int)drUsuarios["id_persona"];
                }
                
                drUsuarios.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error de ingreso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return u;
        }

    }
}