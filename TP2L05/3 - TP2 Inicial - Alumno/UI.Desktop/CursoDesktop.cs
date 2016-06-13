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
    public partial class CursoDesktop : UI.Desktop.ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo): this()
        {
            Modo = modo;
            
        }

        public CursoDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            CursoLogic cur = new CursoLogic();
            CursoActual = cur.GetOne(ID);
            this.MapearDeDatos();            
        }

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }        

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtIDMateria.Text = this.CursoActual.Materia.ID.ToString();
            this.txtIDComision.Text = this.CursoActual.Comision.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            
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
                Curso cur = new Curso();
                this.CursoActual = cur;

                this.CursoActual.State = Entidad.States.New;

                this.CursoActual.Materia.ID = int.Parse(this.txtIDMateria.Text);
                this.CursoActual.Comision.ID = int.Parse(this.txtIDComision.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.CursoActual.State = Entidad.States.Modified;

                    this.CursoActual.Materia.ID = int.Parse(this.txtIDMateria.Text);
                    this.CursoActual.Comision.ID = int.Parse(this.txtIDComision.Text);
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                }
            }
        }

        public virtual void GuardarCambios() 
        {
            this.MapearADatos();
            CursoLogic cur = new CursoLogic();
            cur.Save(CursoActual);
        }

        public virtual bool Validar()
        {               
                if ( (string.IsNullOrEmpty(this.txtAnioCalendario.Text)) )
                {
                    this.Notificar("Advertencia","No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );                    
                    return false;
                }
                if ( (string.IsNullOrEmpty(this.txtCupo.Text)) )
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
