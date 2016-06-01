using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class Login : UI.Desktop.ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                _UsuarioActual = user.GetUsuarioForLogin(txtUsuario.Text, txtContraseña.Text);
                if (_UsuarioActual.ID != 0)
                {
                    if (_UsuarioActual.Habilitado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtContraseña.Clear();
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
