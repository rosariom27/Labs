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
    public partial class AlumnosInscripciones : Form
    {
        public AlumnosInscripciones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            try
            {
                AlumnoLogic alu = new AlumnoLogic();
                this.dgvAlumnos.DataSource = alu.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
                throw ExcepcionManejada;
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        private void Alumnos_Load(object sender, EventArgs e)
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
            AlumnoInscripcionDesktop formAlumno = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.AlumnoInsrcipcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionDesktop formAlumno = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.AlumnoInsrcipcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionDesktop formAlumno = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
            formAlumno.ShowDialog();
            this.Listar();
        }


       

    }
}
