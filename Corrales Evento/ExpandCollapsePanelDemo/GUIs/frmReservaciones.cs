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
    public partial class frmReservaciones : Form
    {

        #region Variables
        bool reservacion = false;
        Consultas obj_consulta = new Consultas(); Negocio obj_negocio = new Negocio(); 
        Generales obj_generales = new Generales(); Validador obj_validador = new Validador();
        frmSiNoDialog frmSiNo; frmPersonas clientesSel; frmPaquete paqueteSel; cliente clienteRes; paquete paqueteRes; frmfechas fechas;
        Sesion sesion = new Sesion();
        double saldoOriginal = 0;
        #endregion

        #region Constructor

        public frmReservaciones(Sesion inicioS = null)
        {
            InitializeComponent();
            sesion = inicioS;
        }

        private void frmReservaciones_Load(object sender, EventArgs e)
        {
            try {
                mnuBaja.Enabled = mnuCamPas.Enabled = false;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } 
        }

        #endregion

        #region Eventos

        private void MnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //frmfechas paquetes = new frmfechas();
                //paquetes.ShowDialog();

                obj_generales.limpiaControles(pnbuscar);
                obj_consulta.cargaDatosCatalogo(cmbreservacion, "reservaciones");
                pnbuscar.Visible = mnuCamPas.Enabled = mnuBaja.Enabled = true;
                mnuNuevo.Enabled = pnAgrega.Visible = pnModificar.Visible = false; //pnModifica.Visible = 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnAgrega);
                pnAgrega.Visible = mnuNuevo.Enabled = true;
                pnbuscar.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = false;
                obj_consulta.BuscaElemento("tipo_evento", 0, cmbTipoEvento);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {

                int id_reservacion = ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].idreservacion;
                if (!obj_validador.ValidaTXT(txtDepositoM.Text.ToUpper())) { throw new Exception("No ha capturado El depósito."); }

                bool res = obj_negocio.ActualizaReservacion(id_reservacion, double.Parse(txtDepositoM.Text), double.Parse(txtSaldoM.Text), txtObservacionM.Text);

                if (res)
                {
                    using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                    {
                        List<seguimiento> seg = (from s in Ctx.seguimiento where s.idreservacion == id_reservacion select s).ToList();
                        reservacion reservacion = (from r in Ctx.reservacion where r.idreservacion == id_reservacion select r).FirstOrDefault();

                        double? saldos = (from p in seg select p.saldo).Min();
                        if (saldos == 0)
                            MessageBox.Show("Se ha cubierto la totalidad de la renta por el evento No: " + reservacion.no_reservacion, "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Se registro el deposito a la reservacion No.: " + reservacion.no_reservacion + " \n La cantidad de: $" + txtDepositoM.Text + ". \n El saldo restante es: $" + saldos.ToString(), "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        mnuCancelar_Click(null, null);
                    }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbreservacion.SelectedIndex == -1) return;

                string mensaje = "Se van a Dar de Baja la Reservacion \n" + ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].no_reservacion;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaBR);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                mnuCamPas.Enabled = mnuBaja.Enabled = pnAgrega.Visible = pnbuscar.Visible = pnModificar.Visible = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                obj_generales.limpiaControles(pnAgrega);
                obj_generales.limpiaControles(pnbuscar);
                obj_generales.limpiaControles(pnModificar);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbreservacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (cmbreservacion.SelectedIndex == -1) return;

                    int? idp = ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].idreservacion;
                    reservacion obj_paquete = (from p in Ctx.reservacion
                                           where p.idreservacion == idp && p.estatus == "A"
                                           select p).FirstOrDefault();

                    txtNoRes.Text = obj_paquete.no_reservacion;
                    txtclienteB.Text = obj_paquete.cliente.nombre;
                    txtpaqueteB.Text = obj_paquete.paquete.nombre;
                    dtpFechaRes.Value = obj_paquete.fecha_reservacion;
                    dtphoraB.Value = new DateTime(obj_paquete.fecha_reservacion.Year, obj_paquete.fecha_reservacion.Month, obj_paquete.fecha_reservacion.Day, obj_paquete.hora_reservacion.Hours, obj_paquete.hora_reservacion.Minutes, obj_paquete.hora_reservacion.Seconds);
                    obj_consulta.BuscaElemento("tipo_evento", obj_paquete.idtevento, cmnEventoB);

                    List<seguimiento> seg = (from s in Ctx.seguimiento where s.idreservacion == obj_paquete.idreservacion orderby s.idseguimiento select s).ToList();
                    double? depositado = seg.Sum(x => x.deposito);
                    txtdepositado.Text = depositado.ToString();

                    int idseguimiento = 0; int idreservacion = 0;
                    for (int x = 0; x <= seg.Count - 1; x++)
                    {
                        if (x != 0)
                        {
                            idseguimiento = seg[x - 1].idseguimiento;
                            idreservacion = seg[x - 1].idreservacion;
                            if (seg[x].idreservacion == idreservacion)
                            {

                                if (seg[x].idseguimiento > idseguimiento)
                                {
                                    txtObservacionesB.Text = seg[x].observacion;
                                }
                            }
                        }
                        else
                            txtObservacionesB.Text = seg[0].observacion;
                    }


                    txtSaldoB.Text = (from p in seg select p.saldo).Min().ToString();
                    txttotalB.Text = obj_paquete.total.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCamPas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbreservacion.SelectedIndex == -1) return;

                string mensaje = "Se van a Actualizar el saldo de la Reservacion: " + ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].no_reservacion;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaRA);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtDepositoG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = obj_generales.teclaNumero(e);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                clientesSel = new frmPersonas(true);
                clientesSel.FormClosed += new FormClosedEventHandler(confirmaSelClie);
                clientesSel.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnbuscaPaquete_Click(object sender, EventArgs e)
        {
            try
            {
                paqueteSel = new frmPaquete(true);
                paqueteSel.FormClosed += new FormClosedEventHandler(confirmaSelPaq);
                paqueteSel.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj_validador.ValidaTXT(txtNoReservacion.Text.ToUpper())) { throw new Exception("No ha capturado El Número de Reservación."); }
                if (!obj_validador.ValidaTXT(txtcliente.Text.ToUpper())) { throw new Exception("No ha seleccionado El Cliente."); }
                if (!obj_validador.ValidaTXT(txtpaquete.Text.ToUpper())) { throw new Exception("No ha seleccionado El Paquete."); }
                if (!obj_validador.ValidaTXT(txtDepositoG.Text.ToUpper())) { throw new Exception("No ha capturado El Depósito."); }

                string mensaje = "Se van a Agregar el Evento \n" + txtNoReservacion.Text + ". \nCon Fecha: " + dtpfecha.Value.ToShortDateString() + " y Hora: " + dtphora.Value.ToShortTimeString() + " \n Con un Depósito de: $" + txtDepositoG.Text +  " y con Saldo: $" + txtsaldoG.Text;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaG);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtDepositoG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Convert the text to a Double and determine if it is a negative number.
                if (txtDepositoG.Text.Length > 0)
                {
                    double saldo = Math.Round(double.Parse(txttotalG.Text) - double.Parse(txtDepositoG.Text), 2);

                    if (saldo > 0)
                    {
                        txtsaldoG.Text = saldo.ToString();
                        txtsaldoG.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtsaldoG.Text = saldo.ToString();
                        txtsaldoG.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSelFecha_Click(object sender, EventArgs e)
        {
            try
            {
                fechas = new frmfechas();
                fechas.FormClosed += new FormClosedEventHandler(confirmaFecha);
                fechas.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtDepositoM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Convert the text to a Double and determine if it is a negative number.
                if (txtDepositoM.Text.Length > 0)
                {
                    double deposito = double.Parse(txtDepositoM.Text);

                    double saldo = Math.Round(saldoOriginal - deposito, 2);

                    if (saldo > 0)
                    {
                        txtSaldoM.Text = saldo.ToString();
                        txtSaldoM.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtSaldoM.Text = saldo.ToString();
                        txtSaldoM.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        public void confirmaSelClie(object sender, EventArgs e)
        {
            try
            {
                if (clientesSel.DialogResult.ToString() == "OK")
                {
                    clienteRes = new cliente();
                    clienteRes = clientesSel.clienteRet;
                    txtcliente.Text = clienteRes.nombre;
                    //int? idp = ((List<cliente>)cmbclientes.DataSource)[cmbclientes.SelectedIndex].idcliente;
                    //cliente res = obj_negocio.BajaCliente((int)idp);

                    //if (res != null)
                    //{
                    //    MessageBox.Show("Se dio de Baja el paquete: " + res.nombre + " del Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    mnuCancelar_Click(null, null);
                    //}
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaSelPaq(object sender, EventArgs e)
        {
            try
            {
                if (paqueteSel.DialogResult.ToString() == "OK")
                {
                    paqueteRes = new paquete();
                    paqueteRes = paqueteSel.paqueteRet;
                    txtpaquete.Text = paqueteRes.nombre;
                    txttotalG.Text = paqueteRes.costo.ToString();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaG(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    reservacion res = obj_negocio.GuardaReservacion(txtNoReservacion.Text, clienteRes.idcliente, paqueteRes.idpaquete, ((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].idtevento, dtpfecha.Value, dtphora.Value, sesion.idusuario, double.Parse(txttotalG.Text), txtobservaciones.Text, double.Parse(txtDepositoG.Text), double.Parse(txtsaldoG.Text));

                    if (res != null)
                    {
                        MessageBox.Show("Se Registro el evento: " + res.no_reservacion + " en el Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mnuCancelar_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaFecha(object sender, EventArgs e)
        {
            try{
                if (fechas.DialogResult.ToString() == "OK")
                {
                    dtpfecha.Value = fechas.fecha;
                    dtphora.Value = new DateTime(fechas.fecha.Year, fechas.fecha.Month, fechas.fecha.Day, fechas.hora.Hours, fechas.hora.Minutes, fechas.hora.Seconds);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaRA(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (frmSiNo.DialogResult.ToString() == "OK")
                    {
                        obj_generales.limpiaControles(pnModificar);
                        pnModificar.Visible = mnuCamPas.Enabled = true;
                        pnbuscar.Visible = pnAgrega.Visible = mnuNuevo.Enabled = mnuBaja.Enabled = MnuBuscar.Enabled = false;

                        int? idp = ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].idreservacion;
                        reservacion obj_paquete = (from p in Ctx.reservacion
                                                   where p.idreservacion == idp && p.estatus == "A"
                                                   select p).FirstOrDefault();

                        txtNoRM.Text = obj_paquete.no_reservacion;
                        txtClienteM.Text = obj_paquete.cliente.nombre;
                        txtPaqueteM.Text = obj_paquete.paquete.nombre;
                        dtpfr.Value = obj_paquete.fecha_reservacion;
                        dtphr.Value = new DateTime(obj_paquete.fecha_reservacion.Year, obj_paquete.fecha_reservacion.Month, obj_paquete.fecha_reservacion.Day, obj_paquete.hora_reservacion.Hours, obj_paquete.hora_reservacion.Minutes, obj_paquete.hora_reservacion.Seconds);
                        obj_consulta.BuscaElemento("tipo_evento", obj_paquete.idtevento, cmnEventoB);

                        List<seguimiento> seg = (from s in Ctx.seguimiento where s.idreservacion == obj_paquete.idreservacion select s).ToList();
                        //double? depositado = seg.Sum(x => x.deposito);
                        //txtdepositado.Text = depositado.ToString();
                        saldoOriginal = (double)(from p in seg select p.saldo).Min();
                        txtSaldoM.Text = (from p in seg select p.saldo).Min().ToString();
                        txtTotalM.Text = obj_paquete.total.ToString();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void confirmaBR(object sender, EventArgs e)
        {
            try{
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    int? idp = ((List<reservacion>)cmbreservacion.DataSource)[cmbreservacion.SelectedIndex].idreservacion;
                    reservacion res = obj_negocio.BajaReservación((int)idp);

                    if (res != null)
                    {
                        MessageBox.Show("Se dio de Baja la Reservación: " + res.no_reservacion + " del Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
