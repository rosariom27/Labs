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
    public partial class EspecialidadDesktop : UI.Desktop.ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm Modo): this()
        {

        }

        public EspecialidadDesktop(int ID, ModoForm Modo): this()
        {
          this.MapearDeDatos();
        }

        private Especialidad _especialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }

        }

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDesc.Text = this.EspecialidadActual.Descripcion;
       
            if (modo == ModoForm.Alta ^ modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else
            {
                if (modo == ModoForm.Baja)
                {
                    this.btnAceptar.Text = "Eliminar";
                }
                else
                {
                    this.btnAceptar.Text = "Aceptar"; //De consulta?
                }
            }
            
                   
        }
        public virtual void MapearADatos() 
        {
            if (modo == ModoForm.Alta)
            {
                Especialidad eact = new Especialidad();
                this.EspecialidadActual = eact;

                this.EspecialidadActual.State = Entidad.States.New;

            }
            else
            {
                if (modo == ModoForm.Modificacion)
                {
                    this.txtID.Text = this.EspecialidadActual.ID.ToString();

                    this.EspecialidadActual.State = Entidad.States.Modified;
                }

            }

            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDesc.Text = this.EspecialidadActual.Descripcion;

        }
        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            EspecialidadesLogic eslog= new EspecialidadesLogic();
            eslog.Save(EspecialidadActual);
        }
        public virtual bool Validar()
        {
           if ( this.EspecialidadActual == null )
             {
                 this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
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
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
