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
    public partial class frmTipoEvento : Form
    {
        #region Variables
        Validador obj_validador = new Validador(); Negocio obj_negocio = new Negocio();
        Generales obj_generales = new Generales(); Consultas obj_consultas = new Consultas(); 
        Sesion inicioS = new Sesion();
        frmSiNoDialog frmSiNo;
        #endregion

        #region Constructor

        public frmTipoEvento()
        {
            InitializeComponent();
        }

        private void frmTipoEvento_Load(object sender, EventArgs e)
        {
            try
            {
                pnBaja.Visible = pnNuevo.Visible = mnuCamPas.Enabled = mnuBaja.Enabled = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Eventos

        private void MnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                obj_generales.limpiaControles(pnBaja);
                obj_consultas.cargaDatosCatalogo(cmbTipoEvento, "tipo_evento");
                pnNuevo.Visible = mnuNuevo.Enabled = false;                
                pnBaja.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                pnBaja.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = false;
                pnNuevo.Visible = mnuNuevo.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCamPas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoEvento.SelectedIndex == -1) return;

                string mensaje = "Se van a Modificar la informacion del Evento " + ((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].nombre;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaM);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoEvento.SelectedIndex == -1) return;

                string mensaje = "Se van a Dar de Baja el tipo de Evento \n" + ((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].nombre;
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
                mnuCamPas.Enabled = mnuBaja.Enabled = pnNuevo.Visible = pnBaja.Visible = pnModifica.Visible = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                obj_generales.limpiaControles(pnNuevo);
                obj_generales.limpiaControles(pnBaja);
                obj_generales.limpiaControles(pnModifica);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (!obj_validador.ValidaTXT(txtNombre.Text.ToUpper())) { throw new Exception("No ha capturado El nombre del tipo de Evento."); }

                    tipo_evento res = obj_negocio.GuardaTipoEvento(txtNombre.Text.ToUpper().Trim(), txtDescripcion.Text.ToUpper().Trim());

                    if (res != null)
                    {
                        MessageBox.Show("El tipo de Evento: " + res.nombre + ". Se ha registrado Correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mnuCancelar_Click(null, null);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try{
                if (!obj_validador.ValidaTXT(txtnombreA.Text.ToUpper())) { throw new Exception("No ha capturado El nombre del Tipo de Evento."); }


                tipo_evento res = obj_negocio.ModificaEvento(((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].idtevento, txtnombreA.Text.Trim().ToUpper(), txtdescripcionA.Text.Trim().ToUpper());

                if (res != null)
                {
                    MessageBox.Show("El Tipo evento con nombre: " + res.nombre + ". Se ha Modificado Correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mnuCancelar_Click(null, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cmbTipoEvento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (cmbTipoEvento.SelectedIndex == -1) return;

                    int? idp = ((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].idtevento;
                    tipo_evento obj_cliente = (from p in Ctx.tipo_evento
                                               where p.idtevento == idp && p.status == "A"
                                           select p).FirstOrDefault();

                    txtDescripcionB.Text = obj_cliente.descripcion;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        private void confirmaM(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    obj_generales.limpiaControles(pnModifica);
                    pnModifica.Visible = mnuCamPas.Enabled = true;

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void confirmaB(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    int? idp = ((List<tipo_evento>)cmbTipoEvento.DataSource)[cmbTipoEvento.SelectedIndex].idtevento;
                    tipo_evento res = obj_negocio.BajaTipoEvento((int)idp);

                    if (res != null)
                    {
                        MessageBox.Show("Se dio de Baja el Tipo de Evento: " + res.nombre + " del Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
