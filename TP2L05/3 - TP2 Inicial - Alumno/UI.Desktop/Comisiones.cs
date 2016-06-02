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

        private void btnActualizar_Click_1(object sender, EventArgs e)//SIN EVENTO
        {
            this.Listar(); 
        }

        private void btnSalir_Click_1(object sender, EventArgs e)//SIN EVENTO
        {
            this.Close(); 
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)//SIN EVENTO
        {
            ComisionDesktop formComision;
            formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }  

        private void tsbEditar_Click_1(object sender, EventArgs e) //SIN EVENTO
        {
            int id = ((Entidades.Plan)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e) //SIN EVENTO
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

        private void Planes_Load(object sender, EventArgs e) //SIN EVENTO
        {
            this.Listar();
        }


    }
}
