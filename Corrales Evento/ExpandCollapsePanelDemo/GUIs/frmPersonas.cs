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

namespace CorralesEventos.GUIs
{
    public partial class frmPersonas : Form
    {
        #region Variables
        bool reservacion = false;
        Consultas obj_consulta = new Consultas();
        Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales();
        Validador obj_validador = new Validador();
        frmSiNoDialog frmSiNo;
        public cliente clienteRet = null;
        #endregion

        #region Constructor

        public frmPersonas(bool inicioR = false)
        {
            InitializeComponent();
            reservacion = inicioR;
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            try
            {
                if (reservacion)
                {
                    mnuSeleciona.Visible = tsSepadador.Visible = true;
                }
                else mnuSeleciona.Visible = tsSepadador.Visible = false;

                mnuBaja.Enabled = false;
                MnuBuscar.Enabled = mnuNuevo.Enabled = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Eventos

        private void MnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnbuscar);
                obj_consulta.cargaDatosCatalogo(cmbclientes, "clientes");
                pnbuscar.Visible = mnuBaja.Enabled = true;
                mnuNuevo.Enabled = pnAgrega.Visible = false; //pnModifica.Visible = 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnAgrega);
                pnAgrega.Visible = mnuNuevo.Enabled = true;
                pnbuscar.Visible = mnuBaja.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbclientes.SelectedIndex == -1) return;

                string mensaje = "Se van a Dar de Baja el paquete \n" + ((List<cliente>)cmbclientes.DataSource)[cmbclientes.SelectedIndex].nombre;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaB);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (reservacion) mnuSeleciona.Visible = true;
                else mnuSeleciona.Visible = false;
                
                mnuBaja.Enabled = pnAgrega.Visible = pnbuscar.Visible = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                obj_generales.limpiaControles(pnAgrega);
                obj_generales.limpiaControles(pnbuscar);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj_validador.ValidaTXT(txtnombrec.Text.ToUpper())) { throw new Exception("No ha capturado El nombre del Cliente."); }
                if (!obj_validador.ValidaTXT(txttelcliente.Text.ToUpper())) { throw new Exception("No ha capturado el teléfono del Cliente"); }
                if (!obj_validador.ValidaTXT(txtdireccion.Text.ToUpper())) { throw new Exception("No ha capturado la Dirección del Cliente."); }

                cliente res = obj_negocio.GuardaClienteNuevo(txtnombrec.Text.ToUpper().Trim(), txtdireccion.Text.Trim().ToUpper(), txttelcliente.Text.Trim());

                if (res != null)
                {
                    MessageBox.Show("El Cliente con nombre: " + res.nombre + ". Se ha registrado Correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mnuCancelar_Click(null, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cmbclientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (cmbclientes.SelectedIndex == -1) return;

                    int? idp = ((List<cliente>)cmbclientes.DataSource)[cmbclientes.SelectedIndex].idcliente;
                    cliente obj_cliente = (from p in Ctx.cliente
                                           where p.idcliente == idp && p.status == "A"
                                           select p).FirstOrDefault();

                    txtnombre.Text = obj_cliente.nombre;
                    txtdireccionb.Text = obj_cliente.direccion;
                    txttelefonob.Text = obj_cliente.telefono;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuSeleciona_Click(object sender, EventArgs e)
        {
            try{
                //if (clienteRet == null) return;
                if (cmbclientes.SelectedIndex == -1) return;

                clienteRet = new cliente();
                int idcliente = ((List<cliente>)cmbclientes.DataSource)[cmbclientes.SelectedIndex].idcliente;
                clienteRet = obj_consulta.RetornaCliente(idcliente);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        private void confirmaB(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    int? idp = ((List<cliente>)cmbclientes.DataSource)[cmbclientes.SelectedIndex].idcliente;
                    cliente res = obj_negocio.BajaCliente((int)idp);

                    if (res != null)
                    {
                        MessageBox.Show("Se dio de Baja el paquete: " + res.nombre + " del Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mnuCancelar_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
    }
}
