namespace UI.Desktop
{
    partial class PersonaDesktop
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbIDPlan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTipoPersona = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.mtbFechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.mtbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.mtbLegajo = new System.Windows.Forms.MaskedTextBox();
            this.ttFechaNacimiento = new System.Windows.Forms.ToolTip(this.components);
            this.ttTelefono = new System.Windows.Forms.ToolTip(this.components);
            this.ttLegajo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "ID Plan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Dirección";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Teléfono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Legajo";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(142, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(121, 20);
            this.txtID.TabIndex = 35;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(142, 65);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 36;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(142, 95);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 37;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(410, 5);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(121, 20);
            this.txtDireccion.TabIndex = 38;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(410, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 39;
            // 
            // cbIDPlan
            // 
            this.cbIDPlan.DisplayMember = "desc_plan";
            this.cbIDPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDPlan.FormattingEnabled = true;
            this.cbIDPlan.Location = new System.Drawing.Point(142, 35);
            this.cbIDPlan.Name = "cbIDPlan";
            this.cbIDPlan.Size = new System.Drawing.Size(121, 21);
            this.cbIDPlan.TabIndex = 40;
            this.cbIDPlan.Tag = "IDPlan";
            this.cbIDPlan.ValueMember = "id_plan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Fecha de Nacimiento";
            // 
            // cbTipoPersona
            // 
            this.cbTipoPersona.DisplayMember = "_descripcion";
            this.cbTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPersona.FormattingEnabled = true;
            this.cbTipoPersona.Location = new System.Drawing.Point(410, 125);
            this.cbTipoPersona.Name = "cbTipoPersona";
            this.cbTipoPersona.Size = new System.Drawing.Size(121, 21);
            this.cbTipoPersona.TabIndex = 41;
            this.cbTipoPersona.ValueMember = "_ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Tipo Persona";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(276, 155);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 33;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(410, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // mtbFechaNacimiento
            // 
            this.mtbFechaNacimiento.Location = new System.Drawing.Point(142, 125);
            this.mtbFechaNacimiento.Mask = "00/00/0000";
            this.mtbFechaNacimiento.Name = "mtbFechaNacimiento";
            this.mtbFechaNacimiento.Size = new System.Drawing.Size(121, 20);
            this.mtbFechaNacimiento.TabIndex = 44;
            this.mtbFechaNacimiento.ValidatingType = typeof(System.DateTime);
            this.mtbFechaNacimiento.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mtbFechaNacimiento_TypeValidationCompleted);
            this.mtbFechaNacimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbFechaNacimiento_KeyDown);
            // 
            // mtbTelefono
            // 
            this.mtbTelefono.Location = new System.Drawing.Point(410, 35);
            this.mtbTelefono.Mask = "000-0000";
            this.mtbTelefono.Name = "mtbTelefono";
            this.mtbTelefono.Size = new System.Drawing.Size(121, 20);
            this.mtbTelefono.TabIndex = 45;
            this.mtbTelefono.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbTelefono_MaskInputRejected);
            // 
            // mtbLegajo
            // 
            this.mtbLegajo.Location = new System.Drawing.Point(410, 95);
            this.mtbLegajo.Mask = "99999";
            this.mtbLegajo.Name = "mtbLegajo";
            this.mtbLegajo.Size = new System.Drawing.Size(121, 20);
            this.mtbLegajo.TabIndex = 46;
            this.mtbLegajo.ValidatingType = typeof(int);
            this.mtbLegajo.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbLegajo_MaskInputRejected);
            // 
            // PersonaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cbIDPlan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTipoPersona);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.mtbFechaNacimiento);
            this.Controls.Add(this.mtbTelefono);
            this.Controls.Add(this.mtbLegajo);
            this.Name = "PersonaDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbIDPlan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTipoPersona;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox mtbFechaNacimiento;
        private System.Windows.Forms.MaskedTextBox mtbTelefono;
        private System.Windows.Forms.MaskedTextBox mtbLegajo;
        private System.Windows.Forms.ToolTip ttFechaNacimiento;
        private System.Windows.Forms.ToolTip ttTelefono;
        private System.Windows.Forms.ToolTip ttLegajo;

    }
}
