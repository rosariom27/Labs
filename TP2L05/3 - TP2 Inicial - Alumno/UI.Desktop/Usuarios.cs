using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios() //para pruebas
        {
            InitializeComponent();
        }
        public Usuarios(Usuario usr)
        {
            InitializeComponent();
            this._usuarioActual = usr;
        }

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public void Listar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                this.dgvUsuarios.DataSource = ul.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de usuarios", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
         }
        
        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario;
            formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop UD = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                UD.Text = "Eliminar usuario";
                UD.ShowDialog();
                this.Listar();
            }
            
            
            /*int id = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            this.Listar();*/
            
            /*
            int id = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            this.Notificar("Advertencia", "¿Desea eliminar este usuario?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //¿CÓMO ELIMINO
            UsuarioLogic usu = new UsuarioLogic();
            usu.Delete(id);
            this.Listar();*/
           
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
    }
}
