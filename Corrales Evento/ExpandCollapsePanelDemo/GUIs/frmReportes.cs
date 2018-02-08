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
    public partial class frmReportes : Form
    {
        #region Variables
        Consultas obj_consulta = new Consultas(); Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales(); Validador obj_validador = new Validador();
        List<DatosReservaciones> lst_Reservaciones;
        #endregion

        #region Constructor
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Eventos

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecarga_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnFechas);
                obj_generales.limpiaControles(pnPaquete);
                obj_generales.limpiaControles(pnClientes);
                obj_generales.limpiaControles(pnTEvento);
                pnFechas.Visible = pnbtnCnst.Visible = pnPaquete.Visible = pnClientes.Visible = pnTEvento.Visible = false;
                dgvResultado.DataSource = null; dgvResultado.Columns.Clear();
                //obj_generales.limpiaControles(pnModificar);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnFechas_Click(object sender, EventArgs e)
        {
            try
            {
                pnFechas.Visible = pnbtnCnst.Visible = true;
                pnPaquete.Visible = pnClientes.Visible = pnTEvento.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            try
            {
                pnFechas.Visible = pnClientes.Visible = pnTEvento.Visible = false;
                pnPaquete.Visible = pnbtnCnst.Visible = true;
                obj_consulta.cargaDatosCatalogo(cmbPaquete, "paquetes");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                pnFechas.Visible = pnClientes.Visible = pnTEvento.Visible = false;
                pnClientes.Visible = pnbtnCnst.Visible = true;
                obj_consulta.cargaDatosCatalogo(cmbClientes, "clientes");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            try
            {
                pnTEvento.Visible = pnbtnCnst.Visible = true;
                pnFechas.Visible = pnClientes.Visible = false;
                obj_consulta.cargaDatosCatalogo(cmbTEventos, "tipo_evento");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                lst_Reservaciones = new List<DatosReservaciones>(); string condicion = string.Empty;
                if (pnFechas.Visible)
                {
                    condicion = "WHERE CAST(r.fecha_reservacion AS DATE) BETWEEN '" + dtpFechaDe.Value.Year + "/" + dtpFechaDe.Value.Month + "/" + dtpFechaDe.Value.Day + "'" + " AND '" + dtpFechaA.Value.Year + "/" + dtpFechaA.Value.Month + "/" + dtpFechaA.Value.Day + "';";
                    lst_Reservaciones = obj_consulta.BuscaReservaciones(condicion);
                }
                if (pnPaquete.Visible)
                {
                    condicion = "WHERE p.idpaquete =  " + ((List<paquete>)cmbPaquete.DataSource)[cmbPaquete.SelectedIndex].idpaquete;
                    lst_Reservaciones = obj_consulta.BuscaReservaciones(condicion);
                }
                if (pnClientes.Visible)
                {
                    condicion = "WHERE c.idcliente =  " + ((List<cliente>)cmbClientes.DataSource)[cmbClientes.SelectedIndex].idcliente;
                    lst_Reservaciones = obj_consulta.BuscaReservaciones(condicion);
                }
                if (pnTEvento.Visible)
                {
                    condicion = "WHERE tp.idtevento =  " + ((List<tipo_evento>)cmbTEventos.DataSource)[cmbTEventos.SelectedIndex].idtevento;
                    lst_Reservaciones = obj_consulta.BuscaReservaciones(condicion);
                }

                if (lst_Reservaciones.Count > 0)
                {
                    dgvResultado.DataSource = null; dgvResultado.Columns.Clear();
                    dgvResultado.DataSource = lst_Reservaciones;
                    FormatoGrid(dgvResultado);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados con los criterios seleccionados, intentelo con otros.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvResultado.DataSource = null; dgvResultado.Columns.Clear();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void print1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                obj_generales.PrintPages(e, true);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

                dgv.Columns["saldo"].Visible = true;
                dgv.Columns["saldo"].DisplayIndex = 6;
                dgv.Columns["saldo"].HeaderText = "Saldo";
                dgv.Columns["saldo"].DefaultCellStyle.Format = "C2";
                dgv.Columns["saldo"].Width = 75;

                dgv.Columns["costo"].Visible = true;
                dgv.Columns["costo"].DisplayIndex = 7;
                dgv.Columns["costo"].HeaderText = "Costo";
                dgv.Columns["costo"].DefaultCellStyle.Format = "C2";
                dgv.Columns["costo"].Width = 75;

                dgv.CurrentCell = dgv.Rows[0].Cells["no_reservacion"];
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

    }
}
