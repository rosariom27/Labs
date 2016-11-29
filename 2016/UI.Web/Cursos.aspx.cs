using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace UI.Web
{
    public partial class Cursos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.GridView.Columns[5].Visible = true;
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
                gridActionsPanel.Visible = true;
            }
        }

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        private CursoLogic _logic;

        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new CursoLogic();
                return _logic;
            }
        }

        private Curso _Entidad;
        private Curso Entidad
        {
            get
            {
                if (_Entidad != null)
                    return _Entidad;
                else
                    return null;
            }
            set { _Entidad = value; }
        }


        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
            this.lbDocente.Visible = enable;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                    return (int)this.ViewState["SelectedID"];
                else
                    return 0;
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

        private void LoadGrid()
        {
                this.GridView.DataSource = Logic.GetAll();
                this.GridView.DataBind();
        }

        private void LoadDdlEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Especialidad--";
            init.Value = "-1";
            this.ddlEspecialidades.Items.Add(init);
            this.ddlEspecialidades.SelectedValue = "-1";
        }

        private void LoadDdlPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in pl.GetAll())
            {
                if (p.Especialidad.ID == Convert.ToInt32(this.ddlEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            this.ddlPlanes.DataSource = planes;
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataValueField = "ID";
            this.ddlPlanes.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            this.ddlPlanes.Items.Add(init);
            this.ddlPlanes.SelectedValue = "-1";
        }

        private void LoadDdlMaterias()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = new List<Materia>();
            foreach (Materia m in ml.GetAll())
            {
                if (m.Plan.ID == Convert.ToInt32(this.ddlPlanes.SelectedValue))
                    materias.Add(m);
            }
            this.ddlMaterias.DataSource = materias;
            this.ddlMaterias.DataTextField = "Descripcion";
            this.ddlMaterias.DataValueField = "ID";
            this.ddlMaterias.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Materia--";
            init.Value = "-1";
            this.ddlMaterias.Items.Add(init);
            this.ddlMaterias.SelectedValue = "-1";
        }

        private void LoadDdlComisiones()
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comisión> comisiones = new List<Comisión>();
            foreach (Comisión c in cl.GetAll())
            {
                if (c.Plan.ID == Convert.ToInt32(this.ddlPlanes.SelectedValue))
                    comisiones.Add(c);
            }
            this.ddlComisiones.DataSource = comisiones;
            this.ddlComisiones.DataTextField = "Descripcion";
            this.ddlComisiones.DataValueField = "ID";
            this.ddlComisiones.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Comisión--";
            init.Value = "-1";
            this.ddlComisiones.Items.Add(init);
            this.ddlComisiones.SelectedValue = "-1";
        }

        private void EnableForm(bool enable)
        {
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
            this.lblPlan.Visible = enable;
            this.ddlPlanes.Visible = enable;
            this.lblMateria.Visible = enable;
            this.ddlMaterias.Visible = enable;
            this.lblComision.Visible = enable;
            this.ddlComisiones.Visible = enable;
            this.lblAnioCalendario.Visible = enable;
            this.txtAnioCalendario.Visible = enable;
            this.lblCupo.Visible = enable;
            this.txtCupo.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
            this.ddlPlanes.Items.Clear();
            this.ddlComisiones.Items.Clear();
            this.ddlMaterias.Items.Clear();
            this.GridView.SelectedIndex = -1;
        }

        private void EliminarEntidad(int id)
        {
            this.Logic.Delete(id);

        }

        private void LoadForm(int id)
        {
         
                this.Entidad = this.Logic.GetOne(id);
                this.ddlEspecialidades.SelectedValue = this.Entidad.Comision.Plan.Especialidad.ID.ToString();
                this.LoadDdlPlanes();
                this.ddlPlanes.SelectedValue = this.Entidad.Comision.Plan.ID.ToString();
                this.LoadDdlMaterias();
                this.ddlMaterias.SelectedValue = this.Entidad.Materia.ID.ToString();
                this.LoadDdlComisiones();
                this.ddlComisiones.SelectedValue = this.Entidad.Comision.ID.ToString();
                this.txtAnioCalendario.Text = this.Entidad.AnioCalendario.ToString();
                this.txtCupo.Text = this.Entidad.Cupo.ToString();
            
            
        }

        private void LoadEntidad(Curso curso)
        {
            curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            curso.Comision.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);
            curso.Comision.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
            curso.Comision.ID = Convert.ToInt32(this.ddlComisiones.SelectedValue);
            curso.Materia.ID = Convert.ToInt32(this.ddlMaterias.SelectedValue);
        }

        private void SaveEntidad(Curso curso)
        {
                this.Logic.Save(curso);
           
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
            this.ShowButtons(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.LoadDdlEspecialidades();
                this.formPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.FormMode = FormModes.Modificacion;  
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadDdlEspecialidades();
            this.GridView.Columns[5].Visible = false;
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);    
        }

        protected void lbDocente_Click(object sender, EventArgs e)
        {
            Session["ID_Curso"] = this.SelectedID;
            Page.Response.Redirect("~/DocentesCursos.aspx");
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entidad = this.Logic.GetOne(this.SelectedID);
                        this.Entidad.State = Entidades.Entidad.States.Modified;  
                        this.LoadEntidad(this.Entidad);
                        this.SaveEntidad(this.Entidad);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entidad = new Curso();
                    this.LoadEntidad(this.Entidad);
                    this.SaveEntidad(Entidad);
                    this.SaveEntidad(Entidad);
                    this.LoadGrid();
                    this.ClearSession();
                    break;
                   
            }
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }
        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlPlanes();
            this.formPanel.Visible = true;
            this.GridView.Columns[5].Visible = false;
            this.gridActionsPanel.Visible = false;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlMaterias();
            this.LoadDdlComisiones();
            this.formPanel.Visible = true;
            this.GridView.Columns[5].Visible = false;
            this.gridActionsPanel.Visible = false;
        }        






    }
}