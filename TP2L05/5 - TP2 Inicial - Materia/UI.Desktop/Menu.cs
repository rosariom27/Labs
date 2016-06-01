using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario;
            formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad;
            formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            Materias formMateria;
            formMateria = new Materias();
            formMateria.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
