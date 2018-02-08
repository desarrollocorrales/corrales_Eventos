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
    public partial class frmSaldos : Form
    {
        #region Variables
        Consultas obj_consulta = new Consultas(); Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales(); Validador obj_validador = new Validador();
        List<DatosSeguimiento> lst_Seguimiento;
        #endregion

        #region Constructor
        public frmSaldos()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos

        private void btnFechas_Click(object sender, EventArgs e)
        {
            try
            {
                pnBuscar.Visible = pnbtnCnst.Visible = true;
                obj_generales.limpiaControles(pnBuscar);
                obj_consulta.cargaDatosCatalogo(cmbreservacion, "reservaciones");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRecarga_Click(object sender, EventArgs e)
        {
            try
            {
                pnbtnCnst.Visible = pnBuscar.Visible = false;
                obj_generales.limpiaControles(pnBuscar);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResultado.DataSource != null)
                {
                    if (obj_generales.SetupThePrinting(print1, dgvResultado, "reservaciones"))
                        print1.Print();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                lst_Seguimiento = new List<DatosSeguimiento>(); string condicion = string.Empty;
                if (pnBuscar.Visible)
                {
                    condicion = "WHERE r.idreservacion = '" + ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].idreservacion + "';";
                    lst_Seguimiento = obj_consulta.BuscaSeguimiento(condicion);
                }


                if (lst_Seguimiento.Count > 0)

                {
                    dgvResultado.DataSource = null; dgvResultado.Columns.Clear();
                    dgvResultado.DataSource = lst_Seguimiento;
                    FormatoGrid(dgvResultado);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados con los criterios seleccionados, intentelo con otros.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvResultado.DataSource = null; dgvResultado.Columns.Clear();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
        
        #region Metodos

        private void FormatoGrid(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                    column.ReadOnly = true;
                }

                dgv.Columns["no_reservacion"].Visible = true;
                dgv.Columns["no_reservacion"].DisplayIndex = 0;
                dgv.Columns["no_reservacion"].HeaderText = "No.";
                dgv.Columns["no_reservacion"].Width = 50;

                dgv.Columns["cliente"].Visible = true;
                dgv.Columns["cliente"].DisplayIndex = 1;
                dgv.Columns["cliente"].HeaderText = "Cliente";
                dgv.Columns["cliente"].Width = 200;

                dgv.Columns["direccion"].Visible = true;
                dgv.Columns["direccion"].DisplayIndex = 2;
                dgv.Columns["direccion"].HeaderText = "Dirección";
                dgv.Columns["direccion"].Width = 300;

                dgv.Columns["telefono"].Visible = true;
                dgv.Columns["telefono"].DisplayIndex = 3;
                dgv.Columns["telefono"].HeaderText = "Contacto";
                dgv.Columns["telefono"].Width = 100;

                dgv.Columns["paquete"].Visible = true;
                dgv.Columns["paquete"].DisplayIndex = 4;
                dgv.Columns["paquete"].HeaderText = "Paquete";
                dgv.Columns["paquete"].Width = 120;

                dgv.Columns["evento"].Visible = true;
                dgv.Columns["evento"].DisplayIndex = 5;
                dgv.Columns["evento"].HeaderText = "Tipo Evento";
                dgv.Columns["evento"].Width = 80;

                dgv.Columns["deposito"].Visible = true;
                dgv.Columns["deposito"].DisplayIndex = 6;
                dgv.Columns["deposito"].HeaderText = "Deposito";
                dgv.Columns["deposito"].DefaultCellStyle.Format = "C2";
                dgv.Columns["deposito"].Width = 75;

                dgv.Columns["saldo"].Visible = true;
                dgv.Columns["saldo"].DisplayIndex = 7;
                dgv.Columns["saldo"].HeaderText = "Saldo";
                dgv.Columns["saldo"].DefaultCellStyle.Format = "C2";
                dgv.Columns["saldo"].Width = 75;

                dgv.Columns["fecha_actualizacion"].Visible = true;
                dgv.Columns["fecha_actualizacion"].DisplayIndex = 8;
                dgv.Columns["fecha_actualizacion"].HeaderText = "Actualización";
                dgv.Columns["fecha_actualizacion"].Width = 75;

                dgv.CurrentCell = dgv.Rows[0].Cells["no_reservacion"];
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        private void print1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                obj_generales.PrintPages(e, true);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

    }
}
