using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;

namespace UI.Consola
{
    public class Usuarios
    {

        private UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }


        public void Menu()
        {
            int op;
            Console.WriteLine("--------- Menú -------- ");
            Console.WriteLine("1) Listado General");
            Console.WriteLine("2) Consulta");
            Console.WriteLine("3) Agregar");
            Console.WriteLine("4) Modificar");
            Console.WriteLine("5)Eliminar");
            Console.WriteLine("6)Salir");
            Console.WriteLine("Elija una opción:");

            op = Console.Read();
            switch (op)
            {
                case '1': ListadoGeneral();
                    break;
                case '2': Consultar();
                    break;
                case '3': Agregar();
                    break;
                case '4': Modificar();
                    break;
                case '5': Eliminar();
                    break;
            }

        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {O}", usr.ID);
            Console.WriteLine("\t\tNombre: {O}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {O}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {O}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {O}", usr.Clave);
            Console.WriteLine("\t\tEmail: {O}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {O}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar:");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre:");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido:");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario:");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave:");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese EMail:");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de Usuario (1-Sí/Otro-No):");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = Entidad.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese Nombre:");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido:");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario:");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave:");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese EMail:");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitación de Usuario (1-Sí/Otro-No):");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = Entidad.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {O}", usuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar:");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

    }

}

 


