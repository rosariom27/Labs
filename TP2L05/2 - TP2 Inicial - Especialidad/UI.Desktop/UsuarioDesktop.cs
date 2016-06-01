using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : UI.Desktop.ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            
            if ( modo == ModoForm.Alta ^ modo == ModoForm.Modificacion)
            { 
                this.btnAceptar.Text = "Guardar";
            }
                else   { if(modo == ModoForm.Baja)
                                        {
                                            this.btnAceptar.Text = "Eliminar";
                                        }
                                        else {  
                                                this.btnAceptar.Text = "Aceptar"; 
                                             }
                        }
            
            
        }
        public virtual void MapearADatos()
        {
            
            if (modo == ModoForm.Alta)
            {
                Usuario u = new Usuario();
                this.UsuarioActual = u;
                              
                this.UsuarioActual.State = Entidad.States.New;
                   
            }
            else
            {
                if (modo == ModoForm.Modificacion)
                {
                    this.txtID.Text = this.UsuarioActual.ID.ToString();
                    
                    this.UsuarioActual.State = Entidad.States.Modified;
                }

            }

            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

        }

        
        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioLogic usu = new UsuarioLogic();
            usu.Save(UsuarioActual);
        }
        public virtual bool Validar()
        {
             if ( this.UsuarioActual == null )
             {
                 this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                
                 return false;
             }
             else
             {
                 if (this.txtClave == this.txtConfirmarClave)
                 {
                     if ((this.txtClave.TextLength) <= 8)
                     {
                       string expresion;
                         expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        // if (Regex.IsMatch (this.txtEmail, expresion)) 
                         {
                             return true;
                         }
                         else
                         {
                                 this.Notificar("Advertencia","El email no es válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                                 
                         }
                     }
                     else
                     {
                         this.Notificar("Advertencia","La clave excede los ocho caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                         
                     }
             else
             {
               this.Notificar("Advertencia","No coinciden las claves", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            
             }
              }
                     }  
            return false;
        } 
          
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_Click(object sender, EventArgs e)
        {

        }

        private Usuario _usuarioActual;
        public Usuario UsuarioActual 
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        
        public UsuarioDesktop(ModoForm Modo): this()
        {

        }

        public UsuarioDesktop(int ID, ModoForm Modo): this()
        {
          this.MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar()==true)
            {
                this.GuardarCambios();
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
