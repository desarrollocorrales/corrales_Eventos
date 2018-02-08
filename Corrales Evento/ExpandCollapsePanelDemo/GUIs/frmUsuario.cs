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
    public partial class frmUsuario : Form
    {
        #region Variables
        bool iniciar = false;
        Validador obj_validador = new Validador(); Negocio obj_negocio = new Negocio(); Generales obj_generales = new Generales(); Consultas obj_consultas = new Consultas(); Sesion inicioS = new Sesion();
        public string usuarioR, passR;
        frmSiNoDialog frmSiNo;
        #endregion

        #region Constructor

        public frmUsuario(bool inicio = false, Sesion ss = null)
        {
            InitializeComponent();
            iniciar = inicio;
            inicioS = ss;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                if (iniciar == true)
                {
                    pnBaja.Visible = false;
                    pnNuevo.Visible = true;
                    tsMenuInicio.Enabled = false;
                }
                else
                {
                    pnBaja.Visible = pnNuevo.Visible = mnuCamPas.Enabled = mnuBaja.Enabled = false;
                    mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Eventos

        private void MnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                pnBaja.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = true;
                pnNuevo.Visible = mnuNuevo.Enabled =  false;
                obj_generales.limpiaControles(pnBaja);
                obj_consultas.cargaDatosCatalogo(cmbUsuarios, "usuarios");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cmbUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (cmbUsuarios.SelectedIndex == -1) return;

                    txtuser2.Text = ((List<usuarios>)cmbUsuarios.DataSource)[cmbUsuarios.SelectedIndex].usuario;
                    int? idu = ((List<usuarios>)cmbUsuarios.DataSource)[cmbUsuarios.SelectedIndex].idusuario;
                    usuarios obj_usuario = (from p in Ctx.usuarios
                                            where p.idusuario == idu && p.status == "A"
                                            select p).FirstOrDefault();

                    txtnombre2.Text = obj_usuario.nombre;
                    txtapellido_p2.Text = obj_usuario.apellido;
                    txtuser2.Text = obj_usuario.usuario;
                    txtcontrasenia2.Text = obj_usuario.password;

                    pnBaja.Visible = mnuBaja.Enabled = mnuCamPas.Visible = true;
                    pnNuevo.Visible = mnuNuevo.Enabled =  false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                pnBaja.Visible = mnuBaja.Enabled = mnuCamPas.Enabled = false;
                pnNuevo.Visible = mnuNuevo.Enabled =  true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuCamPas_Click(object sender, EventArgs e)
        {
            try
            {
                pnBaja.Visible = pnNuevo.Visible = mnuBaja.Enabled = mnuNuevo.Enabled = MnuBuscar.Enabled = false;
                mnuCamPas.Enabled = pnModifica.Visible = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuBaja_Click(object sender, EventArgs e)
        {
            try{
                if (cmbUsuarios.SelectedIndex == -1) return;

                string mensaje = "Se van a Dar de baja el usuario " + ((List<usuarios>)cmbUsuarios.DataSource)[cmbUsuarios.SelectedIndex].usuario ;
                frmSiNo = new frmSiNoDialog(mensaje);
                frmSiNo.FormClosed += new FormClosedEventHandler(confirmaB);
                frmSiNo.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void mnuCancelar_Click(object sender, EventArgs e)
        {
            try{
                pnBaja.Visible = pnNuevo.Visible = pnModifica.Visible = mnuCamPas.Enabled = mnuBaja.Enabled = false;
                mnuNuevo.Enabled = MnuBuscar.Enabled = true;
                obj_generales.limpiaControles(pnBaja);
                obj_generales.limpiaControles(pnNuevo);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    if (!obj_validador.ValidaTXT(txtnombre.Text.ToUpper())) { throw new Exception("No ha capturado El nombre."); }
                    if (!obj_validador.ValidaTXT(txtapellido_p.Text.ToUpper())) { throw new Exception("No ha capturado Los Apellidos."); }
                    if (!obj_validador.ValidaTXT(txtUser.Text.ToUpper())) { throw new Exception("No ha capturado El nombre de usuario para el sistema."); }
                    if (!obj_validador.ValidaTXT(txtcontrasenia.Text.ToUpper())) { throw new Exception("No ha capturado La Contraseña deusuario de sistema."); }

                    usuarios res = obj_negocio.GuardaUsuarioInicio(txtnombre.Text.ToUpper().Trim(), txtapellido_p.Text.ToUpper().Trim(), txtUser.Text.ToUpper().Trim(), txtcontrasenia.Text.ToUpper().Trim());

                    if (res != null)
                    {
                        usuarioR = res.usuario;
                        passR = new Seguridad().DesEncriptar(res.password);
                        if (iniciar)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            mnuCancelar_Click(null, null);
                        }
                    }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj_validador.ValidaTXT(txtuserM.Text.ToUpper())) { throw new Exception("No ha capturado el usuario."); }
                if (!obj_validador.ValidaTXT(txtContraseniaM.Text.Trim().ToUpper())) { throw new Exception("No ha capturado la contraseña Anterior"); }
                if (!obj_validador.ValidaTXT(txtnuevacontra.Text.ToUpper())) { throw new Exception("No ha Capturado la nueva Contraseña de usuario de logeo del sistema."); }
                if (!obj_validador.ValidaTXT(txtcontraseniaCon.Text.ToUpper())) { throw new Exception("No ha Capturado la confirmación de nueva Contraseña de usuario de logeo del sistema."); }

                if (txtnuevacontra.Text.Trim().ToUpper() != txtcontraseniaCon.Text.Trim().ToUpper()) throw new Exception("La nueva contraseña no conicide con la confirmacion, capture de nuevo.");

                usuarios res = obj_negocio.ModificaUsuario(txtuserM.Text.ToUpper(), txtnuevacontra.Text.Trim().ToUpper(), txtContraseniaM.Text.ToUpper().Trim());

                if (res != null)
                {
                    MessageBox.Show("Se actualizo la contraseña del usuario: " + res.usuario + " correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mnuCancelar_Click(null, null);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Metodos

        private void confirmaB(object sender, EventArgs e)
        {
            try
            {
                if (frmSiNo.DialogResult.ToString() == "OK")
                {
                    int? idp = ((List<usuarios>)cmbUsuarios.DataSource)[cmbUsuarios.SelectedIndex].idusuario;
                    usuarios res = obj_negocio.BajaUsuario((int)idp);

                    if (res != null)
                    {
                        MessageBox.Show("Se dio de Baja al Usuario: " + res.usuario + " del Sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mnuCancelar_Click(null, null);

                        //if (inicioS.idusuario == res.idusuario)
                        //{

                        //}
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion



    }
}
