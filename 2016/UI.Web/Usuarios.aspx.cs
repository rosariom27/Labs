using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                this.LoadGrid();
            }
        }

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic==null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"] ;}
            set { this.ViewState["FormMode"] = value ;}
        }

        private Usuario Entidad
        {
            get;
            set;

        }

        private int SelectedID
        {
            get
            {
                if(this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }


        protected void editarLinkButton_Click1(object sender, EventArgs e)
        {
            if(this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm((int)gridView.SelectedValue);
                //this.LoadForm(this.SelectedID);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entidad = this.Logic.GetOne(id);
            this.IDPersonaTextBox.Text = this.Entidad.Persona.ID.ToString();
            this.nombreUsuarioTextBox.Text = this.Entidad.NombreUsuario;
            this.habilitadoCheckBox.Checked = this.Entidad.Habilitado;
        }

        private void LoadEntidad(Usuario usuario)
        {
            usuario.Persona.ID = Convert.ToInt32(this.IDPersonaTextBox.Text);
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.Clave = this.claveTextBox.Text;
        }

        private void SaveEntidad (Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entidad = new Usuario();
                    this.LoadEntidad(this.Entidad);
                    this.SaveEntidad(this.Entidad);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntidad(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entidad = new Usuario();
                    this.Entidad.ID = (int)gridView.SelectedValue;
                    //this.Entidad.ID = this.SelectedID;
                    this.Entidad.State = Entidades.Entidad.States.Modified;
                    this.LoadEntidad(this.Entidad);
                    this.SaveEntidad(this.Entidad);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.IDPersonaTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            //this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            //this.repetirClaveLabel.Visible = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntidad(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.IDPersonaTextBox.Text = string.Empty;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveLabel.Text = string.Empty;

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}