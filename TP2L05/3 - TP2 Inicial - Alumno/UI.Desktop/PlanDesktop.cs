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
    public partial class PlanDesktop : UI.Desktop.ApplicationForm
    {
     public PlanDesktop()
        {
            InitializeComponent();

            EspecialidadLogic ES = new EspecialidadLogic();
            this.cbIDEspecialidad.DataSource = ES.GetAll();
            this.cbIDEspecialidad.DisplayMember = "Descripcion";
            this.cbIDEspecialidad.ValueMember = "ID";
            //this.cbIDEspecialidad.SelectedIndex = -1;
        }
     public PlanDesktop(ModoForm modo): this()
        {
            Modo = modo;            
        }
     public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            this.MapearDeDatos();            
        }

     private Plan _planActual;
     public Plan PlanActual
        {
            get { return _planActual; }
            set { _planActual = value; }
        }
     public override void MapearDeDatos() 
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.cbIDEspecialidad.SelectedValue = this.PlanActual.Especialidad.ID;
            this.txtDescripcion.Text = this.PlanActual.Descripcion;

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
            
            /*if ( Modo == ModoForm.Alta ^ Modo == ModoForm.Modificacion)
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
                        }      */
            
        }
     public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    PlanActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = Plan.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    PlanActual = new Plan();
                    PlanActual.State = Plan.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = Plan.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    PlanActual.ID = Convert.ToInt32(this.txtID.Text);
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.Especialidad.ID = Convert.ToInt32(this.cbIDEspecialidad.SelectedValue);
            }
            
         
         
         /*if (Modo == ModoForm.Alta)
            {
                Plan p = new Plan();
                this.PlanActual = p;
                
                this.PlanActual.State = Entidad.States.New;
                this.PlanActual.Descripcion= this.txtDescripcion.Text;
                this.PlanActual.Especialidad.ID = Convert.ToInt32(this.cbIDEspecialidad.SelectedValue);                              
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.PlanActual.State = Entidad.States.Modified;

                    this.PlanActual.Descripcion= this.txtDescripcion.Text;
                    this.PlanActual.Especialidad.ID = Convert.ToInt32(this.cbIDEspecialidad.SelectedValue);    
                                      
                }
            }*/
        }
     public override void GuardarCambios() 
        {
            this.MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }
     public override bool Validar()
     {               
                    if ( (string.IsNullOrEmpty(this.txtDescripcion.Text)) )
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
     private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
         }
     private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
