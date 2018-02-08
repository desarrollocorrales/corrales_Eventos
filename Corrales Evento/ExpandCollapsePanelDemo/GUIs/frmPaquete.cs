using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpandCollapsePanelDemo.Entidades;
using CorralesEventos.Utilerias;

namespace CorralesEventos.GUIs
{
    public partial class frmPaquete : Form
    {
        #region Variables
        Consultas obj_consulta = new Consultas();
        Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales();
        Validador obj_validador = new Validador();
        frmSiNoDialog frmSiNo;
        bool reservacion = false;
        public paquete paqueteRet = null;
        #endregion

        #region Constructor
        public frmPaquete(bool inicioR = false)
        {
            InitializeComponent();
            reservacion = inicioR;
        }

        private void frmPaquete_Load(object sender, EventArgs e)
        {
            try
            {
                if (reservacion) { mnuSeleciona.Visible = true; tsSepadadorSel.Visible = true; }
                else { mnuSeleciona.Visible = tsSepadadorSel.Visible = false; }

                mnuBaja.Enabled = mnuCamPas.Enabled = false;
                MnuBuscar.Enabled = mnuNuevo.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        #endregion

        #region Eventos

        private void MnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnbuscar);
                obj_consulta.cargaDatosCatalogo(cmbpaquetes, "paquetes");
                pnbuscar.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = true;
                pnAgrega.Visible = mnuNuevo.Enabled = pnModifica.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try{
                obj_generales.limpiaControles(pnAgrega);
                pnAgrega.Visible = mnuNuevo.Enabled = true;
                pnbuscar.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuBaja_Click(object sender, EventArgs e)
        {
            try{
                if (cmbpaquetes.SelectedIndex == -1) return;

                string mensaje = "Se van a Dar de Baja el paquete \n" + ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].nombre;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaB);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCamPas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbpaquetes.SelectedIndex == -1) return;

                string mensaje = "Se van a Modificar la informacion del paquete " + ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].nombre;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaM);
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

                mnuCamPas.Enabled = mnuBaja.Enabled = pnAgrega.Visible = pnbuscar.Visible = pnModifica.Visible = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                obj_generales.limpiaControles(pnAgrega);
                obj_generales.limpiaControles(pnbuscar);
                obj_generales.limpiaControles(pnModifica);

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cmbpaquetes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (cmbpaquetes.SelectedIndex == -1) return;

                    int? idp = ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].idpaquete;
                    paquete obj_paquete = (from p in Ctx.paquete
                                           where p.idpaquete == idp && p.status == "A"
                                           select p).FirstOrDefault();

                    txtnombre.Text = obj_paquete.nombre;
                    txtdescripcion.Text = obj_paquete.descripcion;
                    txtestatus.Text = obj_paquete.status == "A" ? "ACTIVO" : "INACTIVO";
                    txtcosto.Text = obj_paquete.costo.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj_validador.ValidaTXT(txtnombreA.Text.ToUpper())) { throw new Exception("No ha capturado El nombre del paquete."); }
                if (!obj_validador.ValidaTXT(txtdescripcionA.Text.ToUpper())) { throw new Exception("No ha capturado una descripcion del paquete"); }
                if (!obj_validador.ValidaTXT(txtcostoA.Text.ToUpper())) { throw new Exception("No ha capturado el costo del paquete."); }
                if (!obj_validador.ValidaCmb(cmbstatus)) { throw new Exception("No ha capturado El estatus del Paquete."); }

                paquete res = obj_negocio.GuardaPaqueteNuevo(txtnombreA.Text.ToUpper().Trim(), txtdescripcionA.Text.Trim().ToUpper(), cmbstatus.SelectedItem == "ACTIVO" ? "A": "B", double.Parse(txtcostoA.Text));

                if(res != null)
                {
                    MessageBox.Show("El paquete con nombre: " + res.nombre + ". Se ha registrado Correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mnuCancelar_Click(null, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj_validador.ValidaTXT(txtnombreM.Text.ToUpper())) { throw new Exception("No ha capturado El nombre del paquete."); }
                if (!obj_validador.ValidaTXT(txtdescripcionM.Text.ToUpper())) { throw new Exception("No ha capturado una descripcion del paquete"); }
                if (!obj_validador.ValidaTXT(txtcostoM.Text.ToUpper())) { throw new Exception("No ha capturado una descripcion del paquete"); }
                if (!obj_validador.ValidaCmb(cmbestatusM)) { throw new Exception("No ha capturado El estatus del Paquete."); }

                paquete res = obj_negocio.ModificaPaquete(((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].idpaquete, txtnombreM.Text.ToUpper().Trim(), txtdescripcionM.Text.Trim().ToUpper(), cmbestatusM.SelectedItem == "ACTIVO" ? "A" : "B", double.Parse(txtcostoM.Text));

                if (res != null)
                {
                    MessageBox.Show("El paquete con nombre: " + res.nombre + ". Se ha Modificado Correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mnuCancelar_Click(null, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtcosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = obj_generales.teclapresiondaPesos(e);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuSeleciona_Click(object sender, EventArgs e)
        {
            try
            {
                //if (paqueteRet == null) return;
                if (cmbpaquetes.SelectedIndex == -1) return;

                paqueteRet = new paquete();
                int idpaquete = ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].idpaquete;
                paqueteRet = obj_consulta.RetornaPaquete(idpaquete);

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
                    int? idp = ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].idpaquete;
                    paquete res = obj_negocio.BajaPaquete((int)idp);

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

        private void confirmaM(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    obj_generales.limpiaControles(pnModifica);
                    pnModifica.Visible = mnuCamPas.Enabled = true;
                    pnbuscar.Visible = pnAgrega.Visible = mnuNuevo.Enabled = mnuBaja.Enabled = MnuBuscar.Enabled = false;

                    int? idpa = ((List<paquete>)cmbpaquetes.DataSource)[cmbpaquetes.SelectedIndex].idpaquete;
                    paquete obj_paq_res = obj_consulta.RetornaPaquete((int)idpa);

                    txtdescripcionM.Text = obj_paq_res.descripcion;
                    txtnombreM.Text = obj_paq_res.nombre;
                    cmbestatusM.SelectedIndex = obj_paq_res.status == "A" ? 0 : 1;
                    lblcosto.Text = obj_paq_res.costo.ToString();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

    }
}
