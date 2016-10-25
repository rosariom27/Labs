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
                this.LoadForm(this.SelectedID);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entidad = this.Logic.GetOne(id);
            this.nombreUsuarioTextBox.Text = this.Entidad.NombreUsuario;
            this.habilitadoCheckBox.Checked = this.Entidad.Habilitado;
        }

        private void LoadEntidad(Usuario usuario)
        {
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
            this.Entidad = new Usuario();
            this.Entidad.ID = this.SelectedID;
            this.Entidad.State = Entidades.Entidad.States.Modified;
            this.LoadEntidad(this.Entidad);
            this.SaveEntidad(this.Entidad);
            this.LoadGrid();

            this.formPanel.Visible = false;
        }


    }
}