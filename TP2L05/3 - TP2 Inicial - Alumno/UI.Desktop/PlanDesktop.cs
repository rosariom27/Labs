using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Text.RegularExpressions;

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

     public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.cbIDEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            
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
                        }      
            
        }
     public virtual void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                Plan p = new Plan();
                this.PlanActual = p;
                
                this.PlanActual.State = Entidad.States.New;
                this.PlanActual.Descripcion= this.txtDescripcion.Text;
                              
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.PlanActual.State = Entidad.States.Modified;

                    this.PlanActual.Descripcion= this.txtDescripcion.Text;
                    
                }
            }
        }

     public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }
     public virtual bool Validar()
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
            //TERMINAR CON EL IF
        }
     private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
