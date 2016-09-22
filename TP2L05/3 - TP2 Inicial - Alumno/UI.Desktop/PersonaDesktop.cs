﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class PersonaDesktop : UI.Desktop.ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();

            PlanLogic PL = new PlanLogic();
            this.cbIDPlan.DataSource = PL.GetAll();
            this.cbIDPlan.DisplayMember = "Descripcion";
            this.cbIDPlan.ValueMember = "ID";
                   
            
            this.cbTipoPersona.Items.Add("Docente");
            this.cbTipoPersona.Items.Add("Administrativo");
            this.cbTipoPersona.Items.Add("Alumno");
        }

        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }

        public PersonaDesktop(ModoForm modo): this()
        {
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo): this()
        {
            this.Modo = modo;
            PersonasLogic PL = new PersonasLogic();
            PersonaActual = PL.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.mtbLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.mtbTelefono.Text = this.PersonaActual.Telefono;
            this.cbTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
            this.cbIDPlan.Text = this.PersonaActual.Plan.ID.ToString();
            this.mtbFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }          
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    PersonaActual.State = Persona.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = Persona.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    PersonaActual = new Persona();
                    PersonaActual.State = Persona.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = Persona.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    PersonaActual.ID = Convert.ToInt32(this.txtID.Text);
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Legajo = Convert.ToInt32(mtbLegajo.Text);
                this.PersonaActual.Plan.ID = Convert.ToInt32(this.cbIDPlan.SelectedValue);
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Telefono = this.mtbTelefono.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.TipoPersona = Convert.ToInt32(this.cbTipoPersona.SelectedValue);
                this.PersonaActual.FechaNacimiento = Convert.ToDateTime(this.mtbFechaNacimiento.Text);
            }           
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonasLogic PL = new PersonasLogic();
            PL.Save(PersonaActual);
        }

        public override bool Validar()
        {
            if ((string.IsNullOrEmpty(this.txtNombre.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtApellido.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtEmail.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.txtDireccion.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.cbIDPlan.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.cbTipoPersona.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.mtbFechaNacimiento.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.mtbTelefono.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if ((string.IsNullOrEmpty(this.mtbLegajo.Text)))
            {
                this.Notificar("No se completaron todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public new void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(titulo, mensaje, botones, icono);
        }

        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        private void mtbFechaNacimiento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                ttFechaNacimiento.ToolTipTitle = "Dato invalido";
                ttFechaNacimiento.Show("Ingrese la fecha en formato un formato valido (DD/MM/AAAA)", mtbFechaNacimiento);
            }

        }
        private void mtbFechaNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            ttFechaNacimiento.Hide(mtbFechaNacimiento);
        }

        private void mtbTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ttTelefono.ToolTipTitle = "Tipo de dato no valido";
            ttTelefono.Show("El campo admite solo digitos de longitud máxima 6", mtbTelefono);
        }

        private void mtbLegajo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ttLegajo.ToolTipTitle = "Tipo de dato no valido";
            ttLegajo.Show("El campo admite solo digitos de longitud máxima 6", mtbLegajo);
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
            DialogResult DR = (MessageBox.Show("Seguro que desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (DR == DialogResult.Yes) this.Close();
        }
    }

}
