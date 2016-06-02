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
    public partial class AlumnoInscripcionDesktop : UI.Desktop.ApplicationForm
    {
        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }

         public AlumnoInscripcionDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }

         public AlumnoInscripcionDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            AlumnoInscripcionActual = al.GetOne(ID);
            this.MapearDeDatos();

            
        }

         private AlumnoInscripcion _alumnoInscripcionActual;
         public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _alumnoInscripcionActual; }
            set { _alumnoInscripcionActual = value; }
        }
        
        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.AlumnoInscripcionActual.ID.ToString();
            this.txtIDAlumno.Text = this.AlumnoInscripcionActual.Persona.ID.ToString();
            this.txtIDCurso.Text = this.AlumnoInscripcionActual.Curso.ID.ToString();
            this.txtNota.Text = this.AlumnoInscripcionActual.Nota.ToString();
            this.txtCondicion.Text = this.AlumnoInscripcionActual.Condicion;
            
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
                AlumnoInscripcion al = new AlumnoInscripcion();
                this.AlumnoInscripcionActual = al;

                this.AlumnoInscripcionActual.State = Entidad.States.New;

                this.AlumnoInscripcionActual.Persona.ID = this.txtIDAlumno.Text;
                this.AlumnoInscripcionActual.Curso.ID = this.txtIDCurso.Text;
                this.AlumnoInscripcionActual.Nota = this.txtNota.Text;
                this.AlumnoInscripcionActual.Condicion = this.txtCondicion.Text;                               
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.AlumnoInscripcionActual.State = Entidad.States.Modified;

                    this.AlumnoInscripcionActual.Persona.ID = this.txtIDAlumno.Text;
                    this.AlumnoInscripcionActual.Curso.ID = this.txtIDCurso.Text;
                    this.AlumnoInscripcionActual.Nota = this.txtNota.Text;
                    this.AlumnoInscripcionActual.Condicion = this.txtCondicion.Text; 
                }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            AlumnoInscripcionLogic alu = new AlumnoInscripcionLogic();
            alu.Save(AlumnoInscripcionActual);
        }
        public virtual bool Validar()      
        {               
                if ( (string.IsNullOrEmpty(this.txtNota.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtCondicion.Text)) )
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
