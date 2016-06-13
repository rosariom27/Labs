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
    public partial class ComisionDesktop : UI.Desktop.ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
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

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;   
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIDPlan.Text = this.ComisionActual.Plan.ID.ToString();
            
            
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
             Comisión com = new Comisión();
             this.ComisionActual = com;

             this.ComisionActual.State = Entidad.States.New;

             this.ComisionActual.Descripcion = this.txtDescripcion.Text;
             this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);

         }
         else
         {
             if (Modo == ModoForm.Modificacion)
             {
                 this.ComisionActual.State = Entidad.States.Modified;

                 this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                 this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);

             }
         }
     }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

        public virtual bool Validar()
     {               
                    if ( (string.IsNullOrEmpty(this.txtDescripcion.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                    return false;
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
         //TERMINAR CON EL IF
     }

        private void btnCancelar_Click(object sender, EventArgs e)
     {
         this.Close();
     }
   
    }

}
