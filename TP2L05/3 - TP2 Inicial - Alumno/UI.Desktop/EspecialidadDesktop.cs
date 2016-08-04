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
            EspecialidadLogic esp = new EspecialidadLogic();
            EspecialidadActual = esp.GetOne(ID);
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
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            

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
                Especialidad esp = new Especialidad();
                this.EspecialidadActual = esp;
                this.EspecialidadActual.State = Entidad.States.New;
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.EspecialidadActual.State = Entidad.States.Modified;
                    this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;                    
                }
            }
        }

        public virtual void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic es = new EspecialidadLogic();
            es.Save(EspecialidadActual);
        }
        public virtual bool Validar()
        {
            if ((string.IsNullOrEmpty(this.txtDescripcion.Text)))
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
