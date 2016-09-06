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
    public partial class CursoDesktop : UI.Desktop.ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();

            MateriaLogic ml = new MateriaLogic();
            this.cbIDMateria.DataSource = ml.GetAll();
            this.cbIDMateria.DisplayMember = "Descripcion";
            this.cbIDMateria.ValueMember = "ID";

            ComisionLogic cl = new ComisionLogic();
            this.cbIDComision.DataSource = cl.GetAll();
            this.cbIDComision.DisplayMember = " Descripcion";
            this.cbIDComision.ValueMember = "ID";
        }
        public CursoDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }
        public CursoDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            CursoLogic cur = new CursoLogic();
            CursoActual = cur.GetOne(ID);
            this.MapearDeDatos();            
        }

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }        
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.cbIDMateria.SelectedValue = this.CursoActual.Materia.ID;
            this.cbIDComision.SelectedValue = this.CursoActual.Comision.ID;

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
            /*this.txtID.Text = this.CursoActual.ID.ToString();
            this.cbIDMateria.Text = this.CursoActual.Materia.ID.ToString();
            this.cbIDComision.Text = this.CursoActual.Comision.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            
            if ( Modo == ModoForm.Alta ^ Modo == ModoForm.Modificacion)
            { 
                this.btnAceptar.Text = "Guardar";
            }
                else   { if(Modo == ModoForm.Baja)
                                        {
                                            this.btnAceptar.Text = "Eliminar";
                                        }
                                        else {  
                                                this.btnAceptar.Text = "Aceptar"; 
                                             }
                        }*/  
            
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    CursoActual.State = Curso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = Curso.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.State = Curso.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = Curso.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    CursoActual.ID = Convert.ToInt32(this.txtID.Text);
                CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                CursoActual.Materia.ID = Convert.ToInt32(this.cbIDMateria.SelectedValue);
                CursoActual.Comision.ID = Convert.ToInt32(this.cbIDComision.SelectedValue);
            }
            /*if (Modo == ModoForm.Alta)
            {
                Curso cur = new Curso();
                this.CursoActual = cur;

                this.CursoActual.State = Entidad.States.New;

                this.CursoActual.Materia.ID = int.Parse(this.cbIDMateria.Text);
                this.CursoActual.Comision.ID = int.Parse(this.cbIDComision.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.CursoActual.State = Entidad.States.Modified;

                    this.CursoActual.Materia.ID = int.Parse(this.cbIDMateria.Text);
                    this.CursoActual.Comision.ID = int.Parse(this.cbIDComision.Text);
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                }
            }*/
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            CursoLogic cur = new CursoLogic();
            cur.Save(CursoActual);
        }
        public override bool Validar()
        {               
                if ( (string.IsNullOrEmpty(this.txtAnioCalendario.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtCupo.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }             
                return true;
        }
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

    }

}
