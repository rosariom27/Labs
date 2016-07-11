using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class TipoPersonas : Form
    {
        public TipoPersonas()
        {
            InitializeComponent();
        }

        private TipoPersona _tipoPersonaActual;
        public TipoPersona TipoPersonaActual
        {
            get { return _tipoPersonaActual; }
            set { _tipoPersonaActual = value; }
        }

        public void Listar()
        {
            try
            {
                TipoPersonaLogic tp = new TipoPersonaLogic();
                this.dgvTipoPersonas.DataSource = tp.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar listas de tipo de personas", Ex);
                MessageBox.Show("Error", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ExcepcionManejada;
            }
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void TipoPersonas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            TipoPersonaDesktop formTipoPersona;
            formTipoPersona = new TipoPersonaDesktop(ApplicationForm.ModoForm.Alta);
            formTipoPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.TipoPersona)this.dgvTipoPersonas.SelectedRows[0].DataBoundItem).ID;
            TipoPersonaDesktop formTipoPersona = new TipoPersonaDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formTipoPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Entidades.TipoPersona)this.dgvTipoPersonas.SelectedRows[0].DataBoundItem).ID;
            TipoPersonaDesktop formTipoPersona = new TipoPersonaDesktop(id, ApplicationForm.ModoForm.Baja);
            formTipoPersona.ShowDialog();
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
    }

}
