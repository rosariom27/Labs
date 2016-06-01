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
            this.txtDesc.Text = this.MateriaActual.Descripcion;
            this.txtHsSem.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHsTot.Text = this.MateriaActual.HsTotales.ToString();
           // this.txtID_Plan.Text = this.MateriaActual.IdPlan.ToString();
            
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

                this.MateriaActual.Descripcion = this.txtDesc.Text;
                this.MateriaActual.HsSemanales = Convert.ToInt32(this.txtHsSem.Text);
                this.MateriaActual.HsTotales = Convert.ToInt32(this.txtHsTot.Text);
                //this.MateriaActual.IdPlan = Convert.ToInt32(this.txtID_Plan.Text);

                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.MateriaActual.State = Entidad.States.Modified;

                    this.MateriaActual.Descripcion = this.txtDesc.Text;
                    this.MateriaActual.HsSemanales = Convert.ToInt32(this.txtHsSem.Text);
                    this.MateriaActual.HsTotales = Convert.ToInt32(this.txtHsTot.Text);
                   // this.MateriaActual.IdPlan = Convert.ToInt32(this.txtID_Plan.Text);
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
            if ((string.IsNullOrEmpty(this.txtDesc.Text)))
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtHsSem.Text)))
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtHsTot.Text)))
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
