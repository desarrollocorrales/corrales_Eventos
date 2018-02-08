using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorralesEventos.Utilerias;
using CorralesEventos.GUIs;

namespace ExpandCollapsePanelDemo.GUIs
{
    public partial class frmPanelInicio : Form
    {
        #region Variables
        Sesion inicioSesion;
        #endregion

        #region Constructor
        public frmPanelInicio()
        {
            InitializeComponent();
        }

        public frmPanelInicio(Sesion ss = null)
        {
            InitializeComponent();
            inicioSesion = new Sesion();
            inicioSesion = ss;
        }

        private void frmPanelInicio_Load(object sender, EventArgs e)
        {
            try
            {
                if (inicioSesion != null)
                {
                    this.Text = "BIENVENIDO: " + inicioSesion.nombre;
                    ecpCatalogos.IsExpanded = ecpReservacion.IsExpanded = ecpConsultas.IsExpanded = false;
                    ecpCatalogos.IsExpanded = ecpReservacion.IsExpanded = ecpConsultas.IsExpanded = true;
                }

            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Eventos

        private void btnRReservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportes reporte = new frmReportes();
                reporte.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                frmUsuario animales = new frmUsuario();
                animales.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnpaquete_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaquete paquetes = new frmPaquete();
                paquetes.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonas clientes = new frmPersonas();
                clientes.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnTipoEvento_Click(object sender, EventArgs e)
        {
            try
            {
                frmTipoEvento clientes = new frmTipoEvento();
                clientes.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReservacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmReservaciones reservaciones = new frmReservaciones(inicioSesion);
                reservaciones.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatalogos catalogo = new frmCatalogos();
                catalogo.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSaldos_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaldos saldos = new frmSaldos();
                saldos.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Metodos
        #endregion
        
    }
}
