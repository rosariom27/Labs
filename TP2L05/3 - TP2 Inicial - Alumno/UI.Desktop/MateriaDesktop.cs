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
                
        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.Plan.ID.ToString();
                        
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
                Materia mat = new Materia();
                this.MateriaActual = mat;

                this.MateriaActual.State = Entidad.States.New;

                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                this.MateriaActual.Plan.ID = int.Parse(this.txtIDPlan.Text);
                                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.MateriaActual.State = Entidad.States.Modified;

                    this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                    this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                    this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                    this.MateriaActual.Plan.ID = int.Parse(this.txtIDPlan.Text);
                }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            MateriaLogic mat = new MateriaLogic();
            mat.Save(MateriaActual);
        }

        public virtual bool Validar()      
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
            if (Modo == ModoForm.Baja)
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
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
