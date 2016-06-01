namespace UI.Desktop
{
    partial class Alumnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alumnos));
            this.tcAlumnos = new System.Windows.Forms.ToolStripContainer();
            this.tsAlumnos = new System.Windows.Forms.ToolStrip();
            this.tlAlumnos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcAlumnos.ContentPanel.SuspendLayout();
            this.tcAlumnos.TopToolStripPanel.SuspendLayout();
            this.tcAlumnos.SuspendLayout();
            this.tsAlumnos.SuspendLayout();
            this.tlAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAlumnos
            // 
            // 
            // tcAlumnos.ContentPanel
            // 
            this.tcAlumnos.ContentPanel.Controls.Add(this.tlAlumnos);
            this.tcAlumnos.ContentPanel.Size = new System.Drawing.Size(605, 237);
            this.tcAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumnos.Location = new System.Drawing.Point(0, 0);
            this.tcAlumnos.Name = "tcAlumnos";
            this.tcAlumnos.Size = new System.Drawing.Size(605, 262);
            this.tcAlumnos.TabIndex = 0;
            this.tcAlumnos.Text = "toolStripContainer1";
            // 
            // tcAlumnos.TopToolStripPanel
            // 
            this.tcAlumnos.TopToolStripPanel.Controls.Add(this.tsAlumnos);
            // 
            // tsAlumnos
            // 
            this.tsAlumnos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAlumnos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsAlumnos.Location = new System.Drawing.Point(3, 0);
            this.tsAlumnos.Name = "tsAlumnos";
            this.tsAlumnos.Size = new System.Drawing.Size(112, 25);
            this.tsAlumnos.TabIndex = 0;
            // 
            // tlAlumnos
            // 
            this.tlAlumnos.ColumnCount = 2;
            this.tlAlumnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnos.Controls.Add(this.dgvAlumnos, 0, 0);
            this.tlAlumnos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlAlumnos.Controls.Add(this.btnSalir, 1, 1);
            this.tlAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnos.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnos.Name = "tlAlumnos";
            this.tlAlumnos.RowCount = 2;
            this.tlAlumnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnos.Size = new System.Drawing.Size(605, 237);
            this.tlAlumnos.TabIndex = 0;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlAlumnos.SetColumnSpan(this.dgvAlumnos, 2);
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(599, 202);
            this.dgvAlumnos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizar.Location = new System.Drawing.Point(446, 211);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(527, 211);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 262);
            this.Controls.Add(this.tcAlumnos);
            this.Name = "Alumnos";
            this.Text = "Alumnos";
            this.tcAlumnos.ContentPanel.ResumeLayout(false);
            this.tcAlumnos.TopToolStripPanel.ResumeLayout(false);
            this.tcAlumnos.TopToolStripPanel.PerformLayout();
            this.tcAlumnos.ResumeLayout(false);
            this.tcAlumnos.PerformLayout();
            this.tsAlumnos.ResumeLayout(false);
            this.tsAlumnos.PerformLayout();
            this.tlAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcAlumnos;
        private System.Windows.Forms.TableLayoutPanel tlAlumnos;
        private System.Windows.Forms.ToolStrip tsAlumnos;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}