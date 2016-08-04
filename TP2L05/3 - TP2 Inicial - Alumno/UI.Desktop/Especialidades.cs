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
        public Especialidades() //solo para pruebas
        {
            InitializeComponent();
        }
        public Especialidades(Usuario usr)
        {
            InitializeComponent();
            this._usuarioActual = usr;
        }

        private Usuario _usuarioActual;
        public Usuario UsusarioActual
        {
            get { return _usuarioActual; }
        }

        private Especialidad _especialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }

        public void Listar()
        {
            try
            {
                EspecialidadLogic ul = new EspecialidadLogic();
                this.dgvEspecialidades.DataSource = ul.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de especialidades", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }
      
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidad;
            formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
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
            /*this.Notificar("Advertencia", "¿Desea eliminar esta especialidad?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //¿CÓMO ELIMINO?
            EspecialidadLogic esp = new EspecialidadLogic();
            esp.Save(EspecialidadActual);
            this.Listar();*/
            if (this.dgvEspecialidades.SelectedRows.Count != 0)
            {
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop UD = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                UD.Text = "Eliminar especialidad";
                UD.ShowDialog();
                this.Listar();
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
