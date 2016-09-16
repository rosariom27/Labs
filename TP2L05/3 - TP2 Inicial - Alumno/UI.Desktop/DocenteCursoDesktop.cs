using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : UI.Desktop.ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();

            CursoLogic cl = new CursoLogic();
            this.cbIDCurso.DataSource = cl.GetAll();
            this.cbIDCurso.DisplayMember = "Descripcion";
            this.cbIDCurso.ValueMember = "ID";
        }

        public DocenteCursoDesktop(ModoForm modo): this()
        {
            Modo = modo;            
        }

        public DocenteCursoDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            DocenteCursoLogic dc = new DocenteCursoLogic();
            DocenteCursoActual = dc.GetOne(ID);
            this.MapearDeDatos();            
        }

        private DocenteCurso _docenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _docenteCursoActual; }
            set { _docenteCursoActual = value; }
        }        
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.mskIDDocente.Text = this.DocenteCursoActual.Persona.ID.ToString();
            this.cbIDCurso.Text = this.DocenteCursoActual.Curso.ID.ToString();

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }     
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    DocenteCursoActual.State = DocenteCurso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    DocenteCursoActual.State = DocenteCurso.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.State = DocenteCurso.States.New;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.State = DocenteCurso.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    DocenteCursoActual.ID = Convert.ToInt32(this.txtID.Text);
                this.DocenteCursoActual.Persona.ID = int.Parse(this.mskIDDocente.Text);
                this.DocenteCursoActual.Curso.ID = int.Parse(this.cbIDCurso.Text);
            }
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            DocenteCursoLogic dc = new DocenteCursoLogic();
            dc.Save(DocenteCursoActual);
        }
        /* public override bool Validar()
         {               
                 if ( (string.IsNullOrEmpty(this.mskIDDocente.Text)) )
                 {
                     this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                     return false;
                 }
                 return true; 
         }*/

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.mskIDDocente.Text);
            PersonasLogic PL = new PersonasLogic();
            Persona p;
            p = PL.GetOne(id);

            DialogResult DR;

            if (p.ID == id)
            {
                DR = (MessageBox.Show("ID encontrado", "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.None));

                this.cbIDCurso.Enabled = true;
                this.btnAceptar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                DR = (MessageBox.Show("ID no existe, por favor vuelva a ingresarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));

                this.cbIDCurso.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }
    }

}
