namespace ExpandCollapsePanelDemo.GUIs
{
    partial class frmCatalogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogos));
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.tsMenuInicio = new System.Windows.Forms.ToolStrip();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecarga = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.cmbCatalogos = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.print1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tsMenuInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 118);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(802, 264);
            this.dgvDatos.TabIndex = 1;
            // 
            // tsMenuInicio
            // 
            this.tsMenuInicio.BackColor = System.Drawing.Color.White;
            this.tsMenuInicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImprimir,
            this.toolStripSeparator2,
            this.btnRecarga,
            this.toolStripSeparator1,
            this.mnuCerrar});
            this.tsMenuInicio.Location = new System.Drawing.Point(0, 0);
            this.tsMenuInicio.Name = "tsMenuInicio";
            this.tsMenuInicio.Size = new System.Drawing.Size(819, 52);
            this.tsMenuInicio.TabIndex = 4;
            this.tsMenuInicio.Text = "toolStrip1";
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
            // cmbCatalogos
            // 
            this.cmbCatalogos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCatalogos.FormattingEnabled = true;
            this.cmbCatalogos.Location = new System.Drawing.Point(219, 75);
            this.cmbCatalogos.Name = "cmbCatalogos";
            this.cmbCatalogos.Size = new System.Drawing.Size(281, 21);
            this.cmbCatalogos.TabIndex = 5;
            this.cmbCatalogos.SelectionChangeCommitted += new System.EventHandler(this.cmbCatalogos_SelectionChangeCommitted);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 77);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(194, 15);
            this.label25.TabIndex = 22;
            this.label25.Text = "Selecciona Catálogo a Consultar:";
            // 
            // print1
            // 
            this.print1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print1_PrintPage);
            // 
            // frmCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 386);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cmbCatalogos);
            this.Controls.Add(this.tsMenuInicio);
            this.Controls.Add(this.dgvDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCatalogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogos";
            this.Load += new System.EventHandler(this.frmCatalogos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tsMenuInicio.ResumeLayout(false);
            this.tsMenuInicio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolStrip tsMenuInicio;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.ToolStripButton btnRecarga;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cmbCatalogos;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Drawing.Printing.PrintDocument print1;
    }
}