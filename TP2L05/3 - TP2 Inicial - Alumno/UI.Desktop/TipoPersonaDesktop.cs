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
    public partial class TipoPersonaDesktop : UI.Desktop.ApplicationForm
    {
        public TipoPersonaDesktop()
        {
            InitializeComponent();
        }

         public TipoPersonaDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }

         public TipoPersonaDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            TipoPersonaLogic tp = new TipoPersonaLogic();
            TipoPersonaActual = tp.GetOne(ID);
            this.MapearDeDatos();            
        }

         private TipoPersona _tipoPersonaActual;
         public TipoPersona TipoPersonaActual
        {
            get { return _tipoPersonaActual; }
            set { _tipoPersonaActual = value; }
        }
                
        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.TipoPersonaActual.ID.ToString();
            this.txtDescripcion.Text = this.TipoPersonaActual.Descripcion;
                        
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
                TipoPersona tp = new TipoPersona();
                this.TipoPersonaActual = tp;
                
                this.TipoPersonaActual.State = Entidad.States.New;
                
                this.TipoPersonaActual.Descripcion = this.txtDescripcion.Text;                
                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.TipoPersonaActual.State = Entidad.States.Modified;

                    this.TipoPersonaActual.Descripcion = this.txtDescripcion.Text;
                 }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            TipoPersonaLogic tp = new TipoPersonaLogic();
            tp.Save(TipoPersonaActual);
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
