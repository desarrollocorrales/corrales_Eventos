using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace CorralesEventos.Utilerias
{
    public class Generales
    {
        Validador validador = new Validador();

        public void limpiaControles(Panel pn)
        {
            try
            {
                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cmb = ((ComboBox)ctrl);
                        cmb.SelectedIndex = -1;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox texto = ((TextBox)ctrl);
                        texto.Text = "";
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                    {
                        DateTimePicker dtp = ((DateTimePicker)ctrl);
                        dtp.Value = DateTime.Now;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.GroupBox")
                    {
                        limpiaControlesG((GroupBox)ctrl);
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DataGridView")
                    {
                        DataGridView dgv = ((DataGridView)ctrl);
                        dgv.Columns.Clear();
                        dgv.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void limpiaControlesG(GroupBox gb)
        {
            try
            {
                foreach (Control ctrl in gb.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cmb = ((ComboBox)ctrl);
                        cmb.SelectedIndex = -1;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox texto = ((TextBox)ctrl);
                        texto.Text = "";
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                    {
                        DateTimePicker dtp = ((DateTimePicker)ctrl);
                        dtp.Value = DateTime.Now;
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.GroupBox")
                    {
                        limpiaControlesG((GroupBox)ctrl);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool teclapresiondaPesos(KeyPressEventArgs tecla)
        {
            try
            {
                bool resultado = true;
                if (Char.IsLetter(tecla.KeyChar))
                    resultado = true;
                //tecla.Handled = true;
                if ((Char.IsNumber(tecla.KeyChar) || Char.IsPunctuation(tecla.KeyChar)) || tecla.KeyChar.ToString() == "\b")
                    resultado = false;

                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }

        public bool teclaNumero(KeyPressEventArgs tecla)
        {
            try
            {
                bool resultado = false;
                if (!validador.EsNumeroEntero(tecla.KeyChar.ToString()) && tecla.KeyChar.ToString() != "\b")
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }

        public bool teclaLetra(KeyPressEventArgs tecla)
        {
            try
            {
                bool resultado = false;
                if (Char.IsLetter(tecla.KeyChar) || tecla.KeyChar.ToString() == "\b")
                    resultado = false;
                return resultado;
            }
            catch (Exception x)
            { throw x; }
        }

        //Funcion para el printing dialog
        dgvExporta MyDataGridViewPrinter;
        public bool SetupThePrinting(System.Drawing.Printing.PrintDocument print1, DataGridView dgv, string catalogo)
        {
            try
            {
                PrintDialog MyPrintDialog = new PrintDialog();
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;

                if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }


                string titulo = ""; float tamanioL = 9;
                switch (catalogo)
                {
                    case "usuario":
                        titulo = "Reporte Usuarios";
                        break;
                    case "paquete":
                        titulo = "Reporte Paquetes Disponibles";
                        break;
                    case "cliente":
                        titulo = "Reporte Clientes Registrados";
                        break;
                    case "tipo_evento":
                        titulo = "Reporte Tipos de Eventos";
                        break;
                    case "reservaciones":
                        tamanioL = 8;
                        titulo = "Reporte Reservaciones Registradas";
                        break;
                }

                print1.DocumentName = titulo + DateTime.Now.ToString("yyyyMMddhhmmssss");
                print1.PrinterSettings = MyPrintDialog.PrinterSettings;
                print1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
                print1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);

                if (MessageBox.Show("¿Desea que el reporte se centre en la pagina?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    MyDataGridViewPrinter = new dgvExporta(dgv, print1, true, true, titulo, new Font("Tahoma", tamanioL, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
                else
                    MyDataGridViewPrinter = new dgvExporta(dgv, print1, false, true, titulo, new Font("Tahoma", tamanioL, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

                return true;
            }
            catch (Exception x)
            { throw x; }
        }

        public void PrintPages(System.Drawing.Printing.PrintPageEventArgs e, bool reservaciones = false)
        {
            try
            {
                bool more = false;
                if (reservaciones)
                {
                    float fs = 5.0f;
                    more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics, fs);
                }
                else
                {
                    more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics, 5.5f);
                }


                if (more == true)
                    e.HasMorePages = true;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }

    public class Sesion
    {
        public Sesion()
        {
            idusuario = 0;
            nombre = "";
        }

        public int idusuario { get; set; }
        public string nombre { get; set; }
    }

    public class Validador
    {
        public bool EsNumeroEntero(string strIn)
        {
            try
            {
                int.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsNumerico(string strIn)
        {
            try
            {
                decimal.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsPunto(string str)
        {
            try
            {
                decimal.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EsNumericoNull(string strIn)
        {
            try
            {
                if (strIn == "") return true;
                double.Parse(strIn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public double doubleConv(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                double paso;
                double.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public decimal decimalConv(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                decimal paso;
                decimal.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public int Numerico(string cantidad)
        {
            try
            {
                if (cantidad.Trim() == "") return 0;
                cantidad = Regex.Replace(cantidad, @"[^\d\.]", "");
                int paso;
                int.TryParse(cantidad, out paso);
                return paso;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public String CleanInput(string strIn)
        {
            return Regex.Replace(strIn, @"[^\w\.\-\%\s]", "");
        }
        public bool EsAoB(string strIn)
        {
            if (strIn == "A" || strIn == "B")
                return true;
            else
                return false;
        }

        //Validar campos tipo texto
        public bool ValidaTXT(string cadena)
        {
            try{
                bool respuesta = false;
                if (cadena.Trim() != "")
                    respuesta = true;

                return respuesta;
            }
            catch(Exception ex)
            { throw ex; }
        }

        //Validar campos tipo ComboBox
        public bool ValidaCmb(ComboBox cmb)
        {
            try
            {
                bool respuesta = false;
                if (cmb.SelectedIndex != -1)
                    respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public bool validaDateTime(DateTimePicker dtp)
        {
            try
            {
                bool respuesta = true;
                if (dtp.Value.Date <= DateTime.Now.Date)
                    respuesta = false;

                return respuesta;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }

    public class Seguridad
    {
        /// Encripta una cadena
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
