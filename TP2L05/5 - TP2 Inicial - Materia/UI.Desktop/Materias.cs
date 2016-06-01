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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            try
            {
                MateriaLogic mat = new MateriaLogic();
                this.dgvMateria.DataSource = mat.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de materias", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            MateriaDesktop formMateria;
            formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            int id = ((Entidades.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            int id = ((Entidades.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(id, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            this.Listar();
        }



    }
}
