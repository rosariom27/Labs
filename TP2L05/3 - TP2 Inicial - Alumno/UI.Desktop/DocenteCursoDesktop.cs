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
    public partial class DocenteCursoDesktop : UI.Desktop.ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }

        public DocenteCursoDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            DocenteCursoLogic dc = new DocenteCursoLogic();
            DocenteCursoActual = dc.GetOne(ID);
            this.MapearDeDatos();

            
        }

        private DocenteCurso _docenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _docenteCursoActual; }
            set { _docenteCursoActual = value; }
        }
        
        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.txtIDDocente.Text = this.DocenteCursoActual.Persona.ID.ToString();
            this.txtIDCurso.Text = this.DocenteCursoActual.Curso.ID.ToString();
            this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            
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
                DocenteCurso dc = new DocenteCurso();
                this.DocenteCursoActual = dc;

                this.DocenteCursoActual.State = Entidad.States.New;

                this.DocenteCursoActual.Persona.ID = this.txtIDCurso.Text;
                this.DocenteCursoActual.Curso.ID = this.txtIDCurso.Text;
                this.DocenteCursoActual.Cargo = this.txtCargo.Text;                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.DocenteCursoActual.State = Entidad.States.Modified;

                    this.DocenteCursoActual.Persona.ID = this.txtIDCurso.Text;
                    this.DocenteCursoActual.Curso.ID = this.txtIDCurso.Text;
                    this.DocenteCursoActual.Cargo = this.txtCargo.Text; 
                }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            DocenteCursoLogic dc = new DocenteCursoLogic();
            dc.Save(DocenteCursoActual);
        }
        public virtual bool Validar()
        {               
                if ( (string.IsNullOrEmpty(this.txtCargo.Text)) )
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
