using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : UI.Desktop.ApplicationForm
    {
                
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }

        public UsuarioDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            this.MapearDeDatos();

            
        }

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
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
            
            if ( Modo == ModoForm.Alta ^ Modo == ModoForm.Modificacion)
            { 
                this.btnAceptar.Text = "Guardar";
            }
                else   { if(Modo == ModoForm.Baja)
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

            if (Modo == ModoForm.Alta)
            {
                Usuario u = new Usuario();
                this.UsuarioActual = u;
                
                this.UsuarioActual.State = Entidad.States.New;
                
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;

                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.UsuarioActual.State = Entidad.States.Modified;

                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Email= this.txtEmail.Text;
                    this.UsuarioActual.Clave = this.txtClave.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioLogic usu = new UsuarioLogic();
            usu.Save(UsuarioActual);
        }
        public virtual bool Validar()
        {
                if ( (string.IsNullOrEmpty(this.txtNombre.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtApellido.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtEmail.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtUsuario.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtClave.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtConfirmarClave.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (this.txtClave.Text == this.txtConfirmarClave.Text)
                 {
                     if ((this.txtClave.TextLength) <= 8)
                     {

                        string expresion;
                        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        if (Regex.IsMatch(this.txtEmail.Text, expresion))
                        {
                             return true;
                        }
                        else 
                        {
                                 this.Notificar("Advertencia","El email no es válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                  }
                   
                 else 
                     {
                         this.Notificar("Advertencia","La clave excede los ocho caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }      
                 }
                 else
                 {
                     this.Notificar("Advertencia","No coinciden las claves", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            
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

        
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar()==true)
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
