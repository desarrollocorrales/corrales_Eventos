using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorralesEventos.Utilerias;
using ExpandCollapsePanelDemo.Entidades;

namespace ExpandCollapsePanelDemo.GUIs
{
    public partial class frmCatalogos : Form
    {
        #region Variables
        Consultas obj_consulta = new Consultas(); Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales(); Validador obj_validador = new Validador();
        #endregion

        #region Constructor
        public frmCatalogos()
        {
            InitializeComponent();
        }

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            try
            {
                obj_consulta.BuscaElemento("catalogos", 0, cmbCatalogos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Eventos
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.DataSource != null)
                {
                    if (obj_generales.SetupThePrinting(print1, dgvDatos, ((List<catalogos>)cmbCatalogos.DataSource)[cmbCatalogos.SelectedIndex].nombre_tabla))
                        print1.Print();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRecarga_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDatos.DataSource = null; dgvDatos.Columns.Clear();
                cmbCatalogos.SelectedIndex = -1;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void print1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                obj_generales.PrintPages(e);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cmbCatalogos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbCatalogos.SelectedIndex == -1) return;

                dgvDatos.DataSource = null; dgvDatos.Columns.Clear();
                obj_consulta.RetornaDatosCatalogos(dgvDatos, ((List<catalogos>)cmbCatalogos.DataSource)[cmbCatalogos.SelectedIndex].nombre_tabla);
                formatoGrid(dgvDatos, ((List<catalogos>)cmbCatalogos.DataSource)[cmbCatalogos.SelectedIndex].nombre_tabla);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Metodos

        private void formatoGrid(DataGridView dgv, string catalogo)
        {
            try{
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                switch (catalogo)
                {
                    case "usuario":
                        dgv.Columns["usuario"].Visible = true;
                        dgv.Columns["usuario"].DisplayIndex = 0;
                        dgv.Columns["usuario"].HeaderText = "Usuario";
                        dgv.Columns["usuario"].Width = 250;

                        dgv.Columns["nombre"].Visible = true;
                        dgv.Columns["nombre"].DisplayIndex = 1;
                        dgv.Columns["nombre"].HeaderText = "Nombre";
                        dgv.Columns["nombre"].Width = 250;

                        dgv.Columns["apellido"].Visible = true;
                        dgv.Columns["apellido"].DisplayIndex = 2;
                        dgv.Columns["apellido"].HeaderText = "Apellidos";
                        dgv.Columns["apellido"].Width = 250;

                        dgv.Columns["status"].Visible = true;
                        dgv.Columns["status"].DisplayIndex = 3;
                        dgv.Columns["status"].HeaderText = "Estatus";
                        dgv.Columns["status"].Width = 50;
                        break;
                    case "paquete":
                        dgv.Columns["nombre"].Visible = true;
                        dgv.Columns["nombre"].DisplayIndex = 0;
                        dgv.Columns["nombre"].HeaderText = "Nombre";
                        dgv.Columns["nombre"].Width = 250;

                        dgv.Columns["descripcion"].Visible = true;
                        dgv.Columns["descripcion"].DisplayIndex = 1;
                        dgv.Columns["descripcion"].HeaderText = "Descripcion";
                        dgv.Columns["descripcion"].Width = 300;

                        dgv.Columns["costo"].Visible = true;
                        dgv.Columns["costo"].DisplayIndex = 2;
                        dgv.Columns["costo"].HeaderText = "Costo";
                        dgv.Columns["costo"].DefaultCellStyle.Format = "C2";
                        dgv.Columns["costo"].Width = 150;

                        dgv.Columns["status"].Visible = true;
                        dgv.Columns["status"].DisplayIndex = 3;
                        dgv.Columns["status"].HeaderText = "Estatus";
                        dgv.Columns["status"].Width = 50;
                        break;
                    case "cliente":
                        dgv.Columns["nombre"].Visible = true;
                        dgv.Columns["nombre"].DisplayIndex = 0;
                        dgv.Columns["nombre"].HeaderText = "Nombre";
                        dgv.Columns["nombre"].Width = 250;

                        dgv.Columns["direccion"].Visible = true;
                        dgv.Columns["direccion"].DisplayIndex = 1;
                        dgv.Columns["direccion"].HeaderText = "Dirección";
                        dgv.Columns["direccion"].Width = 300;

                        dgv.Columns["telefono"].Visible = true;
                        dgv.Columns["telefono"].DisplayIndex = 2;
                        dgv.Columns["telefono"].HeaderText = "Contacto";
                        dgv.Columns["telefono"].Width = 150;

                        dgv.Columns["status"].Visible = true;
                        dgv.Columns["status"].DisplayIndex = 3;
                        dgv.Columns["status"].HeaderText = "Estatus";
                        dgv.Columns["status"].Width = 50;
                        break;
                    case "tipo_evento":
                        dgv.Columns["nombre"].Visible = true;
                        dgv.Columns["nombre"].DisplayIndex = 0;
                        dgv.Columns["nombre"].HeaderText = "Nombre";
                        dgv.Columns["nombre"].Width = 300;

                        dgv.Columns["descripcion"].Visible = true;
                        dgv.Columns["descripcion"].DisplayIndex = 1;
                        dgv.Columns["descripcion"].HeaderText = "Descripción";
                        dgv.Columns["descripcion"].Width = 300;

                        dgv.Columns["status"].Visible = true;
                        dgv.Columns["status"].DisplayIndex = 2;
                        dgv.Columns["status"].HeaderText = "Estatus";
                        dgv.Columns["status"].Width = 50;
                        break;
                }

                
            }
            catch(Exception ex)
            { throw ex; }
        }

        #endregion

    }
}
