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

       private AlumnoInscripcion _alumnoInscripcionActual;
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _alumnoInscripcionActual; }
            set { _alumnoInscripcionActual = value; }
        }

        public void Listar()
        {
            try
            {
                AlumnoInscripcionLogic alu = new AlumnoInscripcionLogic();
                this.dgvAlumnosInscripciones.DataSource = alu.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de alumnos", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void AlumnosInscripciones_Load(object sender, EventArgs e)
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
            AlumnoInscripcionDesktop formAlumnoInscripcion;
            formAlumnoInscripcion = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.Usuario)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(id, ApplicationForm.ModoForm.Baja);
            formAlumnoInscripcion.ShowDialog();
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
