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
    public partial class AlumnosInscripciones : Form  //ApplicationForm
    {
        public AlumnosInscripciones(Usuario u)
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;
        public void Listar()
        {
           try
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                this.dgvAlumnos.DataSource = ail.GetAll(_UsuarioActual.Persona.ID);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AlumnoInscripcionDesktop formAlumno = new AlumnoInscripcionDesktop(_UsuarioActual); 
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
