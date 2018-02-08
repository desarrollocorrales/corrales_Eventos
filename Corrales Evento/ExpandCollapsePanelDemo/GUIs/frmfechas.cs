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
using System.Globalization;


namespace CorralesEventos.GUIs
{
    public partial class frmfechas : Form
    {
        #region Variables
        Consultas obj_consulta = new Consultas();
        public DateTime fecha;
        public TimeSpan hora;
        int MES = 0;
        int ANIO = 0;
        string valorSeleccionado = string.Empty;
        #endregion

        #region Constructor


        public frmfechas()
        {
            InitializeComponent();
        }

        private void frmfechas_Load(object sender, EventArgs e)
        {
            try
            {
                lblMes.Text = cargaMes(DateTime.Now.Month, DateTime.Now.Year);
                MES = DateTime.Now.Month; ANIO = DateTime.Now.Year;
                cargareservaciones(MES, ANIO);
                llenaHerramientaCalendario(MES, ANIO);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (valorSeleccionado == string.Empty) { throw new Exception("No ha capturado la fecha para el evento."); }


                fecha = new DateTime(ANIO, MES, int.Parse(valorSeleccionado));
                if (fecha.Date < DateTime.Now.Date) { throw new Exception("La Fecha de reservación no puede ser menor a la fecha actual."); }
                hora = new TimeSpan(dtphora.Value.Hour, dtphora.Value.Minute, dtphora.Value.Second);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void mcReservaciones_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                cargareservaciones(mcReservaciones.SelectionStart.Month, mcReservaciones.SelectionStart.Year);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mcReservaciones_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                dtpfecha.Value = mcReservaciones.SelectionStart;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            try{
                if (MES == 1)
                {
                    MES = 12;
                    ANIO = ANIO - 1;
                }
                else
                    MES = MES - 1;

                lblMes.Text = cargaMes(MES, ANIO);
                llenaHerramientaCalendario(MES, ANIO);
                cargareservaciones(MES, ANIO);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            try{
                if (MES == 12)
                {
                    MES = 1;
                    ANIO = ANIO + 1;
                }
                else MES = MES + 1;


                lblMes.Text = cargaMes(MES, ANIO);
                llenaHerramientaCalendario(MES, ANIO);
                cargareservaciones(MES, ANIO);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Metodos
        private void cargareservaciones(int mes, int anio)
        {
            try
            {
                List<reservacion> lst_reservacion = obj_consulta.FechasReservadas(mes, anio);

                if (lst_reservacion.Count > 0)
                {
                    foreach(reservacion r in lst_reservacion)
                    {
                        obj_consulta.MarcaDias(pnDias, r.fecha_reservacion.Date.Day);
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private string cargaMes(int mes, int anio)
        {
            try
            {
                string msj = string.Empty;
                switch (mes)
                {
                    case 1:
                        msj = "ENERO DE " + anio;
                        break;
                    case 2:
                        msj = "FEBRERO DE " + anio;
                        break;
                    case 3:
                        msj = "MARZO DE " + anio;
                        break;
                    case 4:
                        msj = "ABRIL DE " + anio;
                        break;
                    case 5:
                        msj = "MAYO DE " + anio;
                        break;
                    case 6:
                        msj = "JUNIO DE " + anio;
                        break;
                    case 7:
                        msj = "JULIO DE " + anio;
                        break;
                    case 8:
                        msj = "AGOSTO DE " + anio;
                        break;
                    case 9:
                        msj = "SEPTIEMBRE DE " + anio;
                        break;
                    case 10:
                        msj = "OCTUBRE DE " + anio;
                        break;
                    case 11:
                        msj = "NOVIEMBRE DE " + anio;
                        break;
                    case 12:
                        msj = "DICIEMBRE DE " + anio;
                        break;
                }

                return msj;
            }
            catch (Exception es)
            { throw es; }
        }

        private void llenaHerramientaCalendario(int mes, int anio)
        {
            try
            {
                string diaI = new DateTime(anio, mes, 1).ToString("dddd", new CultureInfo("es-ES")); 
                // string diaF = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes)).ToString("dddd", new CultureInfo("es-ES"));
                obj_consulta.ResetCalendario(pnDias);
                obj_consulta.AsignaDias(pnDias, obj_consulta.RetornaDia(diaI), DateTime.DaysInMonth(anio, mes));

            }
            catch (Exception x)
            { throw x; }
        }
        #endregion        

        private void btnS1B1_Click(object sender, EventArgs e)
        {
            try
            {
                Button boton = (Button)sender;
                lblFechaSel.Text = "Fecha Seleccionada: \n" + boton.Text + "/" + MES.ToString() + "/" + ANIO.ToString();
                valorSeleccionado = boton.Text;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
