using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : UI.Desktop.ApplicationForm
    {

        public UsuarioDesktop()
        {
            InitializeComponent();

            this.cbTipoPersona.Items.Add("Docente");
            this.cbTipoPersona.Items.Add("Administrativo");
            this.cbTipoPersona.Items.Add("Alumno");
        }

        public UsuarioDesktop(ModoForm modo)
            : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo)
            : this()
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
            this.txtClave.Text = this.UsuarioActual.Clave;
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
                Usuario u = new Usuario();
                this.UsuarioActual = u;

                this.UsuarioActual.State = Entidad.States.New;

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;


            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.UsuarioActual.State = Entidad.States.Modified;

                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Clave = this.txtClave.Text;
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
            if ((string.IsNullOrEmpty(this.txtUsuario.Text)))
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtClave.Text)))
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtConfirmarClave.Text)))
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtClave.Text == this.txtConfirmarClave.Text)
            {
                if ((this.txtClave.TextLength) >= 8)
                {
                    this.Notificar("Advertencia", "La clave excede los ocho caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                this.Notificar("Advertencia", "No coinciden las claves", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

            }
            return true;
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

       private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.mskIDPersona.Text);
            PersonasLogic PL = new PersonasLogic();
            Persona p;
            p = PL.GetOne(id);
            DialogResult DR;

            if (p.ID == id)
            {
                DR = (MessageBox.Show("ID encontrado", "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.None));
                this.txtUsuario.ReadOnly = false;
                this.txtClave.ReadOnly = false;
                this.txtConfirmarClave.ReadOnly = false;
                this.chkHabilitado.Enabled = true;
                this.btnAceptar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                DR = (MessageBox.Show("ID no existe, por favor vuelva a ingresarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                this.txtUsuario.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.ReadOnly = true;
                this.chkHabilitado.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnAceptar_Click_2(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }

}


