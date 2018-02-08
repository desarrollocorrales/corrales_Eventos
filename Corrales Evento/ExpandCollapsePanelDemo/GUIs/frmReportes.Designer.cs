namespace ExpandCollapsePanelDemo.GUIs
{
    partial class frmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            this.tsMenuInicio = new System.Windows.Forms.ToolStrip();
            this.btnFechas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPaquetes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEventos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecarga = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnContenedor = new System.Windows.Forms.Panel();
            this.pnTEvento = new System.Windows.Forms.Panel();
            this.cmbTEventos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnClientes = new System.Windows.Forms.Panel();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnPaquete = new System.Windows.Forms.Panel();
            this.cmbPaquete = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pnbtnCnst = new System.Windows.Forms.Panel();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.pnFechas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dtpFechaA = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDe = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.print1 = new System.Drawing.Printing.PrintDocument();
            this.tsMenuInicio.SuspendLayout();
            this.pnContenedor.SuspendLayout();
            this.pnTEvento.SuspendLayout();
            this.pnClientes.SuspendLayout();
            this.pnPaquete.SuspendLayout();
            this.pnbtnCnst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.pnFechas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuInicio
            // 
            this.tsMenuInicio.BackColor = System.Drawing.Color.White;
            this.tsMenuInicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFechas,
            this.toolStripSeparator3,
            this.btnPaquetes,
            this.toolStripSeparator4,
            this.btnClientes,
            this.toolStripSeparator5,
            this.btnEventos,
            this.toolStripSeparator6,
            this.btnImprimir,
            this.toolStripSeparator2,
            this.btnRecarga,
            this.toolStripSeparator1,
            this.mnuCerrar});
            this.tsMenuInicio.Location = new System.Drawing.Point(0, 0);
            this.tsMenuInicio.Name = "tsMenuInicio";
            this.tsMenuInicio.Size = new System.Drawing.Size(1059, 52);
            this.tsMenuInicio.TabIndex = 5;
            this.tsMenuInicio.Text = "toolStrip1";
            // 
            // btnFechas
            // 
            this.btnFechas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFechas.Image = ((System.Drawing.Image)(resources.GetObject("btnFechas.Image")));
            this.btnFechas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFechas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFechas.Name = "btnFechas";
            this.btnFechas.Size = new System.Drawing.Size(60, 49);
            this.btnFechas.Text = "toolStripButton1";
            this.btnFechas.ToolTipText = "Fechas";
            this.btnFechas.Click += new System.EventHandler(this.btnFechas_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // btnPaquetes
            // 
            this.btnPaquetes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaquetes.Image = ((System.Drawing.Image)(resources.GetObject("btnPaquetes.Image")));
            this.btnPaquetes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPaquetes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaquetes.Name = "btnPaquetes";
            this.btnPaquetes.Size = new System.Drawing.Size(60, 49);
            this.btnPaquetes.Text = "toolStripButton2";
            this.btnPaquetes.ToolTipText = "Paquetes";
            this.btnPaquetes.Click += new System.EventHandler(this.btnPaquetes_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // btnClientes
            // 
            this.btnClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(60, 49);
            this.btnClientes.Text = "toolStripButton3";
            this.btnClientes.ToolTipText = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // btnEventos
            // 
            this.btnEventos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEventos.Image = ((System.Drawing.Image)(resources.GetObject("btnEventos.Image")));
            this.btnEventos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEventos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEventos.Name = "btnEventos";
            this.btnEventos.Size = new System.Drawing.Size(60, 49);
            this.btnEventos.Text = "toolStripButton4";
            this.btnEventos.ToolTipText = "Eventos";
            this.btnEventos.Click += new System.EventHandler(this.btnEventos_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 52);
            // 
            // btnImprimir
            // 
            this.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 49);
            this.btnImprimir.ToolTipText = "Imprime";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // btnRecarga
            // 
            this.btnRecarga.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecarga.Image = ((System.Drawing.Image)(resources.GetObject("btnRecarga.Image")));
            this.btnRecarga.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRecarga.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecarga.Name = "btnRecarga";
            this.btnRecarga.Size = new System.Drawing.Size(60, 49);
            this.btnRecarga.Text = "toolStripButton1";
            this.btnRecarga.ToolTipText = "Recargar";
            this.btnRecarga.Click += new System.EventHandler(this.btnRecarga_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = ((System.Drawing.Image)(resources.GetObject("mnuCerrar.Image")));
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(59, 49);
            this.mnuCerrar.Text = "toolStripButton5";
            this.mnuCerrar.ToolTipText = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // pnContenedor
            // 
            this.pnContenedor.Controls.Add(this.pnPaquete);
            this.pnContenedor.Controls.Add(this.pnbtnCnst);
            this.pnContenedor.Controls.Add(this.dgvResultado);
            this.pnContenedor.Controls.Add(this.pnFechas);
            this.pnContenedor.Controls.Add(this.pnTEvento);
            this.pnContenedor.Controls.Add(this.pnClientes);
            this.pnContenedor.Location = new System.Drawing.Point(0, 61);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.Size = new System.Drawing.Size(1059, 490);
            this.pnContenedor.TabIndex = 7;
            // 
            // pnTEvento
            // 
            this.pnTEvento.Controls.Add(this.cmbTEventos);
            this.pnTEvento.Controls.Add(this.label3);
            this.pnTEvento.Location = new System.Drawing.Point(7, 3);
            this.pnTEvento.Name = "pnTEvento";
            this.pnTEvento.Size = new System.Drawing.Size(379, 39);
            this.pnTEvento.TabIndex = 53;
            this.pnTEvento.Visible = false;
            // 
            // cmbTEventos
            // 
            this.cmbTEventos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTEventos.FormattingEnabled = true;
            this.cmbTEventos.Location = new System.Drawing.Point(67, 9);
            this.cmbTEventos.Name = "cmbTEventos";
            this.cmbTEventos.Size = new System.Drawing.Size(281, 21);
            this.cmbTEventos.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "T. Evento";
            // 
            // pnClientes
            // 
            this.pnClientes.Controls.Add(this.cmbClientes);
            this.pnClientes.Controls.Add(this.label2);
            this.pnClientes.Location = new System.Drawing.Point(6, 3);
            this.pnClientes.Name = "pnClientes";
            this.pnClientes.Size = new System.Drawing.Size(380, 39);
            this.pnClientes.TabIndex = 52;
            this.pnClientes.Visible = false;
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(69, 9);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(281, 21);
            this.cmbClientes.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Clientes";
            // 
            // pnPaquete
            // 
            this.pnPaquete.Controls.Add(this.cmbPaquete);
            this.pnPaquete.Controls.Add(this.label27);
            this.pnPaquete.Location = new System.Drawing.Point(4, 3);
            this.pnPaquete.Name = "pnPaquete";
            this.pnPaquete.Size = new System.Drawing.Size(385, 39);
            this.pnPaquete.TabIndex = 4;
            this.pnPaquete.Visible = false;
            // 
            // cmbPaquete
            // 
            this.cmbPaquete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaquete.FormattingEnabled = true;
            this.cmbPaquete.Location = new System.Drawing.Point(69, 9);
            this.cmbPaquete.Name = "cmbPaquete";
            this.cmbPaquete.Size = new System.Drawing.Size(281, 21);
            this.cmbPaquete.TabIndex = 51;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 15);
            this.label27.TabIndex = 28;
            this.label27.Text = "Paquete";
            // 
            // pnbtnCnst
            // 
            this.pnbtnCnst.Controls.Add(this.btnConsulta);
            this.pnbtnCnst.Location = new System.Drawing.Point(463, 4);
            this.pnbtnCnst.Name = "pnbtnCnst";
            this.pnbtnCnst.Size = new System.Drawing.Size(96, 38);
            this.pnbtnCnst.TabIndex = 3;
            this.pnbtnCnst.Visible = false;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsulta.Location = new System.Drawing.Point(0, 0);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(96, 38);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.Text = "Consultar";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(3, 44);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultado.Size = new System.Drawing.Size(1043, 443);
            this.dgvResultado.TabIndex = 1;
            // 
            // pnFechas
            // 
            this.pnFechas.Controls.Add(this.label1);
            this.pnFechas.Controls.Add(this.label25);
            this.pnFechas.Controls.Add(this.dtpFechaA);
            this.pnFechas.Controls.Add(this.dtpFechaDe);
            this.pnFechas.Location = new System.Drawing.Point(3, 3);
            this.pnFechas.Name = "pnFechas";
            this.pnFechas.Size = new System.Drawing.Size(385, 39);
            this.pnFechas.TabIndex = 0;
            this.pnFechas.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "A:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(16, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 15);
            this.label25.TabIndex = 22;
            this.label25.Text = "De:";
            // 
            // dtpFechaA
            // 
            this.dtpFechaA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaA.Location = new System.Drawing.Point(181, 9);
            this.dtpFechaA.Name = "dtpFechaA";
            this.dtpFechaA.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaA.TabIndex = 1;
            // 
            // dtpFechaDe
            // 
            this.dtpFechaDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDe.Location = new System.Drawing.Point(44, 9);
            this.dtpFechaDe.Name = "dtpFechaDe";
            this.dtpFechaDe.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaDe.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsMenuInicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 55);
            this.panel1.TabIndex = 8;
            // 
            // print1
            // 
            this.print1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print1_PrintPage);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnContenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Reservaciones";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.tsMenuInicio.ResumeLayout(false);
            this.tsMenuInicio.PerformLayout();
            this.pnContenedor.ResumeLayout(false);
            this.pnTEvento.ResumeLayout(false);
            this.pnTEvento.PerformLayout();
            this.pnClientes.ResumeLayout(false);
            this.pnClientes.PerformLayout();
            this.pnPaquete.ResumeLayout(false);
            this.pnPaquete.PerformLayout();
            this.pnbtnCnst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.pnFechas.ResumeLayout(false);
            this.pnFechas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuInicio;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRecarga;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnContenedor;
        private System.Windows.Forms.Panel pnFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaA;
        private System.Windows.Forms.DateTimePicker dtpFechaDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.ToolStripButton btnFechas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPaquetes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEventos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnbtnCnst;
        private System.Windows.Forms.Panel pnPaquete;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbPaquete;
        private System.Windows.Forms.Panel pnClientes;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTEventos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnTEvento;
        private System.Drawing.Printing.PrintDocument print1;
    }
}