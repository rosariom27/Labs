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
    public partial class AlumnoInscripcionDesktop : UI.Desktop.ApplicationForm
    {
        public AlumnoInscripcionDesktop(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u; // FALTA TERMINAR PARA EL FINAL
        }

        private Usuario _UsuarioActual;
        
        public AlumnoInscripcionDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            AlumnoLogic alu = new AlumnoLogic();
            AlumnoActual = alu.GetOne(ID);
            this.MapearDeDatos();
        }

        private AlumnoInsrcipcion _alumnoActual;
        public AlumnoInsrcipcion AlumnoActual
        {
            get { return _alumnoActual; }
            set { _alumnoActual = value; }
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

            if (Modo == ModoForm.Alta ^ Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else
            {
                if (Modo == ModoForm.Baja)
                {
                    this.btnAceptar.Text = "Eliminar";
                }
                else
                {
                    this.btnAceptar.Text = "Aceptar";
                }
            }
        }        
        
        
        public virtual void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                AlumnoInsrcipcion alu = new AlumnoInsrcipcion();
                this.AlumnoActual = alu;

                this.AlumnoActual.State = Entidad.States.New;

            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.txtID.Text = this.AlumnoActual.ID.ToString();

                    this.AlumnoActual.State = Entidad.States.Modified;
                }

            }

            this.txtIDAlumno.Text = this.AlumnoActual.IDAlumno.ToString();
            this.txtIDCurso.Text = this.AlumnoActual.IDCurso.ToString();
            this.txtCondicion.Text = this.AlumnoActual.Condicion;
            this.txtNota.Text = this.AlumnoActual.Nota.ToString();
            
        
        }
        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            AlumnoLogic alu = new AlumnoLogic();
            alu.Save(AlumnoActual);
        }
        public virtual bool Validar()
        {
            if (this.AlumnoActual == null)
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar() == true)
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
