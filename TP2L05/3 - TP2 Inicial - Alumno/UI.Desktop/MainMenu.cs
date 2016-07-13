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
    public partial class MainMenu : Form
    {
        public MainMenu(Usuario usr)
        {
            InitializeComponent();
            this._usuarioActual = usr;
        }

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
            }
            this.Visible = false;
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this._usuarioActual = login.UsuarioActual;
                //this.permisos();
                this.Visible = true;
                //this.tsbsUsuarios.Text = this._usuarioActual.NombreUsuario;
            }
            else
            {
                this.Close();
            }
        }
        
        /*private void mnuRegistrarAlumno_Click(object sender, EventArgs e)
        {
            RegistrarAlumnoDesktop rad = new RegistrarAlumnoDesktop();
            rad.MdiParent = this;
            rad.Show();

        }*/

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //completar
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios(this.UsuarioActual);
            u.ShowDialog();
        }

        private void mnuComisiones_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones(this.UsuarioActual);
            c.MdiParent = this;
            c.Show();
        }

        private void mnuAluInsc_Click(object sender, EventArgs e)
        {
            AlumnosInscripciones ai = new AlumnosInscripciones();
            ai.MdiParent = this;
            ai.Show();
        }

        private void mnuCursos_Click(object sender, EventArgs e)
        {
            Cursos c = new Cursos(this.UsuarioActual);
            c.MdiParent = this;
            c.Show();
        }

        private void mnuDocenteCursos_Click(object sender, EventArgs e)
        {
            DocentesCursos dc = new DocentesCursos(this.UsuarioActual);
            dc.ShowDialog();
        }

        private void mnuEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades(this.UsuarioActual);
            esp.MdiParent = this;
            esp.Show();
        }

        private void mnuMaterias_Click(object sender, EventArgs e)
        {
            Materias m = new Materias(this.UsuarioActual);
            m.MdiParent = this;
            m.Show();
        }

        private void mnuPersonas_Click(object sender, EventArgs e)
        {
            Personas p = new Personas(this.UsuarioActual);
            p.MdiParent = this;
            p.Show();
        }

        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            Planes p = new Planes(this.UsuarioActual);
            p.MdiParent = this;
            p.Show();
        }

        /*private void mnuUsuarios_Click_1(object sender, EventArgs e) //no está hecho realmente
        {
            Usuarios u = new Usuarios(this.UsuarioActual);
            u.MdiParent = this;
            u.Show();
        }*/

    }
}
