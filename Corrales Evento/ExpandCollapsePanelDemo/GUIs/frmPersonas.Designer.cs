namespace CorralesEventos.GUIs
{
    partial class frmPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonas));
            this.tsMenuInicio = new System.Windows.Forms.ToolStrip();
            this.MnuBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBaja = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSeleciona = new System.Windows.Forms.ToolStripButton();
            this.tsSepadador = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnbuscar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdireccionb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttelefonob = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbclientes = new System.Windows.Forms.ComboBox();
            this.pnAgrega = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttelcliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtnombrec = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tsMenuInicio.SuspendLayout();
            this.pnbuscar.SuspendLayout();
            this.pnAgrega.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuInicio
            // 
            this.tsMenuInicio.BackColor = System.Drawing.Color.White;
            this.tsMenuInicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuBuscar,
            this.toolStripSeparator1,
            this.mnuNuevo,
            this.toolStripSeparator2,
            this.mnuBaja,
            this.toolStripSeparator4,
            this.mnuSeleciona,
            this.tsSepadador,
            this.mnuCancelar,
            this.toolStripSeparator5,
            this.mnuCerrar});
            this.tsMenuInicio.Location = new System.Drawing.Point(0, 0);
            this.tsMenuInicio.Name = "tsMenuInicio";
            this.tsMenuInicio.Size = new System.Drawing.Size(577, 53);
            this.tsMenuInicio.TabIndex = 4;
            this.tsMenuInicio.Text = "toolStrip1";
            // 
            // MnuBuscar
            // 
            this.MnuBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MnuBuscar.Image = ((System.Drawing.Image)(resources.GetObject("MnuBuscar.Image")));
            this.MnuBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuBuscar.Name = "MnuBuscar";
            this.MnuBuscar.Size = new System.Drawing.Size(60, 50);
            this.MnuBuscar.Text = "toolStripButton1";
            this.MnuBuscar.ToolTipText = "Buscar";
            this.MnuBuscar.Click += new System.EventHandler(this.MnuBuscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = ((System.Drawing.Image)(resources.GetObject("mnuNuevo.Image")));
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(60, 50);
            this.mnuNuevo.Text = "toolStripButton2";
            this.mnuNuevo.ToolTipText = "Nuevo Cliente";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // mnuBaja
            // 
            this.mnuBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBaja.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaja.Image")));
            this.mnuBaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBaja.Name = "mnuBaja";
            this.mnuBaja.Size = new System.Drawing.Size(60, 50);
            this.mnuBaja.Text = "toolStripButton4";
            this.mnuBaja.ToolTipText = "Elimina Cliente";
            this.mnuBaja.Click += new System.EventHandler(this.mnuBaja_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 53);
            // 
            // mnuSeleciona
            // 
            this.mnuSeleciona.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSeleciona.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeleciona.Image")));
            this.mnuSeleciona.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSeleciona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSeleciona.Name = "mnuSeleciona";
            this.mnuSeleciona.Size = new System.Drawing.Size(59, 50);
            this.mnuSeleciona.Text = "toolStripButton1";
            this.mnuSeleciona.ToolTipText = "Seleccionar";
            this.mnuSeleciona.Visible = false;
            this.mnuSeleciona.Click += new System.EventHandler(this.mnuSeleciona_Click);
            // 
            // tsSepadador
            // 
            this.tsSepadador.Name = "tsSepadador";
            this.tsSepadador.Size = new System.Drawing.Size(6, 53);
            this.tsSepadador.Visible = false;
            // 
            // mnuCancelar
            // 
            this.mnuCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCancelar.Image = ((System.Drawing.Image)(resources.GetObject("mnuCancelar.Image")));
            this.mnuCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCancelar.Name = "mnuCancelar";
            this.mnuCancelar.Size = new System.Drawing.Size(60, 50);
            this.mnuCancelar.Text = "toolStripButton1";
            this.mnuCancelar.ToolTipText = "Recargar";
            this.mnuCancelar.Click += new System.EventHandler(this.mnuCancelar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 53);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = ((System.Drawing.Image)(resources.GetObject("mnuCerrar.Image")));
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(59, 50);
            this.mnuCerrar.Text = "toolStripButton5";
            this.mnuCerrar.ToolTipText = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // pnbuscar
            // 
            this.pnbuscar.Controls.Add(this.label4);
            this.pnbuscar.Controls.Add(this.txtdireccionb);
            this.pnbuscar.Controls.Add(this.label5);
            this.pnbuscar.Controls.Add(this.txttelefonob);
            this.pnbuscar.Controls.Add(this.label2);
            this.pnbuscar.Controls.Add(this.txtnombre);
            this.pnbuscar.Controls.Add(this.label1);
            this.pnbuscar.Controls.Add(this.cmbclientes);
            this.pnbuscar.Location = new System.Drawing.Point(1, 55);
            this.pnbuscar.Name = "pnbuscar";
            this.pnbuscar.Size = new System.Drawing.Size(574, 187);
            this.pnbuscar.TabIndex = 5;
            this.pnbuscar.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dirección";
            // 
            // txtdireccionb
            // 
            this.txtdireccionb.BackColor = System.Drawing.Color.White;
            this.txtdireccionb.Location = new System.Drawing.Point(157, 143);
            this.txtdireccionb.MaxLength = 500;
            this.txtdireccionb.Multiline = true;
            this.txtdireccionb.Name = "txtdireccionb";
            this.txtdireccionb.ReadOnly = true;
            this.txtdireccionb.Size = new System.Drawing.Size(398, 20);
            this.txtdireccionb.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Teléfono";
            // 
            // txttelefonob
            // 
            this.txttelefonob.BackColor = System.Drawing.Color.White;
            this.txttelefonob.Location = new System.Drawing.Point(27, 143);
            this.txttelefonob.MaxLength = 12;
            this.txttelefonob.Name = "txttelefonob";
            this.txttelefonob.ReadOnly = true;
            this.txttelefonob.Size = new System.Drawing.Size(93, 20);
            this.txttelefonob.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.txtnombre.BackColor = System.Drawing.Color.White;
            this.txtnombre.Location = new System.Drawing.Point(27, 90);
            this.txtnombre.MaxLength = 500;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.ReadOnly = true;
            this.txtnombre.Size = new System.Drawing.Size(528, 20);
            this.txtnombre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes";
            // 
            // cmbclientes
            // 
            this.cmbclientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbclientes.FormattingEnabled = true;
            this.cmbclientes.Location = new System.Drawing.Point(27, 35);
            this.cmbclientes.Name = "cmbclientes";
            this.cmbclientes.Size = new System.Drawing.Size(351, 21);
            this.cmbclientes.TabIndex = 0;
            this.cmbclientes.SelectionChangeCommitted += new System.EventHandler(this.cmbclientes_SelectionChangeCommitted);
            // 
            // pnAgrega
            // 
            this.pnAgrega.Controls.Add(this.label3);
            this.pnAgrega.Controls.Add(this.txtdireccion);
            this.pnAgrega.Controls.Add(this.label6);
            this.pnAgrega.Controls.Add(this.txttelcliente);
            this.pnAgrega.Controls.Add(this.label7);
            this.pnAgrega.Controls.Add(this.txtnombrec);
            this.pnAgrega.Controls.Add(this.btnAceptar);
            this.pnAgrega.Location = new System.Drawing.Point(3, 55);
            this.pnAgrega.Name = "pnAgrega";
            this.pnAgrega.Size = new System.Drawing.Size(574, 187);
            this.pnAgrega.TabIndex = 6;
            this.pnAgrega.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Dirección";
            // 
            // txtdireccion
            // 
            this.txtdireccion.BackColor = System.Drawing.Color.White;
            this.txtdireccion.Location = new System.Drawing.Point(157, 90);
            this.txtdireccion.MaxLength = 500;
            this.txtdireccion.Multiline = true;
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(398, 20);
            this.txtdireccion.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Teléfono";
            // 
            // txttelcliente
            // 
            this.txttelcliente.BackColor = System.Drawing.Color.White;
            this.txttelcliente.Location = new System.Drawing.Point(27, 90);
            this.txttelcliente.MaxLength = 12;
            this.txttelcliente.Name = "txttelcliente";
            this.txttelcliente.Size = new System.Drawing.Size(93, 20);
            this.txttelcliente.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nombre";
            // 
            // txtnombrec
            // 
            this.txtnombrec.BackColor = System.Drawing.Color.White;
            this.txtnombrec.Location = new System.Drawing.Point(27, 37);
            this.txtnombrec.MaxLength = 500;
            this.txtnombrec.Name = "txtnombrec";
            this.txtnombrec.Size = new System.Drawing.Size(528, 20);
            this.txtnombrec.TabIndex = 15;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(467, 135);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 35);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 244);
            this.Controls.Add(this.tsMenuInicio);
            this.Controls.Add(this.pnbuscar);
            this.Controls.Add(this.pnAgrega);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmPersonas_Load);
            this.tsMenuInicio.ResumeLayout(false);
            this.tsMenuInicio.PerformLayout();
            this.pnbuscar.ResumeLayout(false);
            this.pnbuscar.PerformLayout();
            this.pnAgrega.ResumeLayout(false);
            this.pnAgrega.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuInicio;
        private System.Windows.Forms.ToolStripButton MnuBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnuBaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton mnuCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnbuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbclientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdireccionb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttelefonob;
        private System.Windows.Forms.ToolStripButton mnuSeleciona;
        private System.Windows.Forms.ToolStripSeparator tsSepadador;
        private System.Windows.Forms.Panel pnAgrega;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttelcliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnombrec;
        private System.Windows.Forms.Button btnAceptar;
    }
}