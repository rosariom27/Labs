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

        public EspecialidadDesktop(ModoForm modo): this()
        {
            Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            EspecialidadesLogic el = new EspecialidadesLogic();
            EspecialidadActual = el.GetOne(ID);
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
       
            if (Modo == ModoForm.Alta ^ Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else
            {
                if (Modo == ModoForm.Baja)
                {
                    this.btnAceptar.Text = "Eliminar";
                }
                else
                {
                    this.btnAceptar.Text = "Aceptar";
                }
            }
            
                   
        }
        public virtual void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad eact = new Especialidad();
                this.EspecialidadActual = eact;

                this.EspecialidadActual.State = Entidad.States.New;

                this.EspecialidadActual.Descripcion = this.txtDesc.Text;
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.EspecialidadActual.State = Entidad.States.Modified;
                  
                    this.EspecialidadActual.Descripcion = this.txtDesc.Text;
                    
                }

            }
        
        }
        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            EspecialidadesLogic eslog= new EspecialidadesLogic();
            eslog.Save(EspecialidadActual);
        }
        public virtual bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDesc.Text))
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
            this.Close();
        }

    }
}
