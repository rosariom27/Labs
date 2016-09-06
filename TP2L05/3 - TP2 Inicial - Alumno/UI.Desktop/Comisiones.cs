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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }
        public Comisiones(Usuario usr)
        {
            InitializeComponent();
            this._usuarioActual = usr;
        }

        private Usuario _usuarioActual;
        public Usuario UsusarioActual
        {
            get { return _usuarioActual; }
        }

        private Comisión _comisionActual;
        public Comisión ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }

        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                this.dgvComisiones.DataSource = cl.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de comisiones", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComision;
            formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.Comisión)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.Comisión)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(id, ApplicationForm.ModoForm.Baja);
            formComision.ShowDialog();
            this.Listar();

            /*
            int id = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            this.Notificar("Advertencia", "¿Desea eliminar este usuario?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //¿CÓMO ELIMINO
            UsuarioLogic usu = new UsuarioLogic();
            usu.Delete(id);
            this.Listar();*/
        }


    }

}
