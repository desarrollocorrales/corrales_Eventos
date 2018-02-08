namespace ExpandCollapsePanelDemo.GUIs
{
    partial class frmSaldos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldos));
            this.pnContenedor = new System.Windows.Forms.Panel();
            this.pnbtnCnst = new System.Windows.Forms.Panel();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbreservacion = new System.Windows.Forms.ComboBox();
            this.pnBuscar = new System.Windows.Forms.Panel();
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
            this.tsMenuInicio = new System.Windows.Forms.ToolStrip();
            this.print1 = new System.Drawing.Printing.PrintDocument();
            this.pnContenedor.SuspendLayout();
            this.pnbtnCnst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.pnBuscar.SuspendLayout();
            this.tsMenuInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContenedor
            // 
            this.pnContenedor.Controls.Add(this.pnBuscar);
            this.pnContenedor.Controls.Add(this.pnbtnCnst);
            this.pnContenedor.Controls.Add(this.dgvResultado);
            this.pnContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnContenedor.Location = new System.Drawing.Point(0, 52);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.Size = new System.Drawing.Size(1059, 490);
            this.pnContenedor.TabIndex = 8;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reservación";
            // 
            // cmbreservacion
            // 
            this.cmbreservacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreservacion.FormattingEnabled = true;
            this.cmbreservacion.Location = new System.Drawing.Point(87, 10);
            this.cmbreservacion.Name = "cmbreservacion";
            this.cmbreservacion.Size = new System.Drawing.Size(225, 21);
            this.cmbreservacion.TabIndex = 4;
            // 
            // pnBuscar
            // 
            this.pnBuscar.Controls.Add(this.label1);
            this.pnBuscar.Controls.Add(this.cmbreservacion);
            this.pnBuscar.Location = new System.Drawing.Point(3, 4);
            this.pnBuscar.Name = "pnBuscar";
            this.pnBuscar.Size = new System.Drawing.Size(346, 38);
            this.pnBuscar.TabIndex = 6;
            this.pnBuscar.Visible = false;
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
            this.btnFechas.ToolTipText = "Reservaciones";
            this.btnFechas.Click += new System.EventHandler(this.btnFechas_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            this.toolStripSeparator3.Visible = false;
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
            this.btnPaquetes.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            this.toolStripSeparator4.Visible = false;
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
            this.btnClientes.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            this.toolStripSeparator5.Visible = false;
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
            this.btnEventos.Visible = false;
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
            this.tsMenuInicio.TabIndex = 6;
            this.tsMenuInicio.Text = "toolStrip1";
            // 
            // print1
            // 
            this.print1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print1_PrintPage);
            // 
            // frmSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 558);
            this.Controls.Add(this.pnContenedor);
            this.Controls.Add(this.tsMenuInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSaldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldos";
            this.pnContenedor.ResumeLayout(false);
            this.pnbtnCnst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.pnBuscar.ResumeLayout(false);
            this.pnBuscar.PerformLayout();
            this.tsMenuInicio.ResumeLayout(false);
            this.tsMenuInicio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnContenedor;
        private System.Windows.Forms.Panel pnbtnCnst;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Panel pnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbreservacion;
        private System.Windows.Forms.ToolStripButton btnFechas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPaquetes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEventos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRecarga;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.ToolStrip tsMenuInicio;
        private System.Drawing.Printing.PrintDocument print1;
    }
}