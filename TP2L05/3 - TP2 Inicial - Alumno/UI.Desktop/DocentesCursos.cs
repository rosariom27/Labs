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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos()
        {
            InitializeComponent();
        }
        public DocentesCursos(Usuario usr)
        {
            InitializeComponent();
            this._usuarioActual = usr;
        }

        private Usuario _usuarioActual;
        public Usuario UsusarioActual
        {
            get { return _usuarioActual; }
        }

        private DocenteCurso _docenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _docenteCursoActual; }
            set { _docenteCursoActual = value; }
        }

        public void Listar()
        {
            try
            {
                DocenteCursoLogic dc = new DocenteCursoLogic();
                this.dgvDocentesCursos.DataSource = dc.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de dictados", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(id, ApplicationForm.ModoForm.Baja);
            formDocenteCurso.ShowDialog();
            this.Listar();

            /*
            int id = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            this.Notificar("Advertencia", "¿Desea eliminar este usuario?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //¿CÓMO ELIMINO
            UsuarioLogic usu = new UsuarioLogic();
            usu.Delete(id);
            this.Listar();*/
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.Usuario)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formDocenteCurso.ShowDialog();
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop formDocenteCurso;
            formDocenteCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocenteCurso.ShowDialog();
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
