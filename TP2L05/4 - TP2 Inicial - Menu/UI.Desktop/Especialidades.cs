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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            try
            {
                EspecialidadesLogic es = new EspecialidadesLogic();
                this.dgvEspecialidades.DataSource = es.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
           
        }

        private void Especialidades_Load(object sender, EventArgs e)
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

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
  
        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            EspecialidadDesktop frmEspecialidad;
            frmEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            frmEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            int id = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            int id = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Baja);
            formEspecialidad.ShowDialog();
            this.Listar();
        }
    }
}
