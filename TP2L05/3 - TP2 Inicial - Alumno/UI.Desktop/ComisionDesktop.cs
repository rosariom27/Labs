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
    public partial class ComisionDesktop : UI.Desktop.ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();

            PlanLogic pl = new PlanLogic();
            this.cbIDPlan.DataSource = pl.GetAll();
            this.cbIDPlan.DisplayMember = "Descripcion";
            this.cbIDPlan.ValueMember = "ID";
        }        
        public ComisionDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }
        public ComisionDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            ComisionLogic com = new ComisionLogic();
            ComisionActual = com.GetOne(ID);
            this.MapearDeDatos();   
        }
     
        private Comisión _comisionActual;
        public Comisión ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.cbIDPlan.SelectedValue = this.ComisionActual.Plan.ID;
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();

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
            /*this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;   
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cbIDPlan.Text = this.ComisionActual.Plan.ID.ToString();
            
            
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
                 ComisionActual.State = Comisión.States.Deleted;
                 break;
             case ModoForm.Consulta:
                 ComisionActual.State = Comisión.States.Unmodified;
                 break;
             case ModoForm.Alta:
                 ComisionActual = new Comisión();
                 ComisionActual.State = Comisión.States.New;
                 break;
             case ModoForm.Modificacion:
                 ComisionActual.State = Comisión.States.Modified;
                 break;
         }
         if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
         {
             if (Modo == ModoForm.Modificacion)
                 ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
             ComisionActual.Descripcion = this.txtDescripcion.Text;
             ComisionActual.Plan.ID = Convert.ToInt32(this.cbIDPlan.SelectedValue);
             ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
         }
         /*if (Modo == ModoForm.Alta)
         {
             Comisión com = new Comisión();
             this.ComisionActual = com;

             this.ComisionActual.State = Entidad.States.New;

             this.ComisionActual.Descripcion = this.txtDescripcion.Text;
             this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
             this.ComisionActual.Plan.ID = Convert.ToInt32(this.cbIDPlan.SelectedValue);

         }
         else
         {
             if (Modo == ModoForm.Modificacion)
             {
                 this.ComisionActual.State = Entidad.States.Modified;

                 this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                 this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                 this.ComisionActual.Plan.ID = Convert.ToInt32(this.cbIDPlan.SelectedValue);

             }
         }*/
     }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }
        public override bool Validar()
     {
         if ((string.IsNullOrEmpty(this.txtDescripcion.Text)) || (string.IsNullOrEmpty(this.txtAnioEspecialidad.Text)))
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
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
        private void btnCancelar_Click(object sender, EventArgs e)
     {
         this.Close();
     }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
        }
   
    }

}
