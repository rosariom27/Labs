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
    public partial class MateriaDesktop : UI.Desktop.ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();

            PlanLogic pl = new PlanLogic();
            this.cbIDPlan.DataSource = pl.GetAll();
            this.cbIDPlan.DisplayMember = "Descripcion";
            this.cbIDPlan.ValueMember = "ID";
        }
        public MateriaDesktop(ModoForm modo): this()
        {
            Modo = modo;            
        }
        public MateriaDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            MateriaLogic mat = new MateriaLogic();
            MateriaActual = mat.GetOne(ID);
            this.MapearDeDatos();            
        }

        private Materia _materiaActual;
        public Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }                
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.cbIDPlan.SelectedValue = this.MateriaActual.Plan.ID;
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();

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
            /*this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cbIDPlan.Text = this.MateriaActual.Plan.ID.ToString();
                        
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
                    MateriaActual.State = Materia.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = Materia.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    MateriaActual = new Materia();
                    MateriaActual.State = Materia.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = Materia.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    MateriaActual.ID = Convert.ToInt32(this.txtID.Text);
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.Plan.ID = Convert.ToInt32(this.cbIDPlan.SelectedValue);
                MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
            }
            
            /*if (Modo == ModoForm.Alta)
            {
                Materia mat = new Materia();
                this.MateriaActual = mat;

                this.MateriaActual.State = Entidad.States.New;

                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                this.MateriaActual.Plan.ID = int.Parse(this.cbIDPlan.Text);
                                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.MateriaActual.State = Entidad.States.Modified;

                    this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                    this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                    this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                    this.MateriaActual.Plan.ID = int.Parse(this.cbIDPlan.Text);
                }
            }*/
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            MateriaLogic mat = new MateriaLogic();
            mat.Save(MateriaActual);
        }

        public override bool Validar()      
        {               
                    if ( (string.IsNullOrEmpty(this.txtDescripcion.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtHSSemanales.Text)) )
                {
                    this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtHSTotales.Text)) )
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
            /*if (Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }

            else
            {
                if (this.Validar() == true)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
