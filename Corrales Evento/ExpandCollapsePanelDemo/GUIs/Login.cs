using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorralesEventos.GUIs;
using CorralesEventos.Utilerias;
using ExpandCollapsePanelDemo.Entidades;
using ExpandCollapsePanelDemo;
using ExpandCollapsePanelDemo.GUIs;

namespace CorralesEventos.GUIs
{
    public partial class Login : Form
    {
        #region Variables
        public CorralesEventos.Utilerias.Sesion inicioSession;
        frmUsuario frmU;
        usuarios usuario_log = new usuarios();
        Consultas obj_consulta = new Consultas();
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                using (corrales_eventosEntities ctx = new corrales_eventosEntities())
                {
                    usuario_log = obj_consulta.BuscaUsuarioInicio();
                    if (usuario_log == null)
                    {
                        MessageBox.Show("Se debe registrar el usuario de Inicio de la Aplicación", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmU = new frmUsuario(true);
                        frmU.FormClosed += new FormClosedEventHandler(resultado);
                        frmU.ShowDialog();
                    }
                    else
                        txbUser.Focus();
                }

                txbUser.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (InicarSesion())
                {
                    this.Hide();
                    new frmPanelInicio(inicioSession).ShowDialog();
                    //new Demo(inicioSession).ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbUser_TabIndexChanged(object sender, EventArgs e)
        {
            txbPass.Focus();
        }

        private void txbPass_TabIndexChanged(object sender, EventArgs e)
        {
            btnIngresar.Focus();
        }

        private void txbPass_Enter(object sender, EventArgs e)
        {
            if (txbPass.Text == "" || txbUser.Text == "") return;

            btnIngresar_Click(null, null);
        }

        private void txbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnIngresar_Click(null, null);
            }
        }

        #endregion

        #region Metodos

        private bool InicarSesion()
        {
            string user = txbUser.Text.ToUpper();
            string pass = new Seguridad().Encriptar(txbPass.Text.ToUpper());

            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    usuarios obj_usuario = (from us in Ctx.usuarios
                                            where us.usuario == txbUser.Text.Trim().ToUpper() && us.password == pass && us.status == "A"
                                           select us).FirstOrDefault();

                    if (obj_usuario == null)
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Login",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txbUser.Text = "";
                        txbPass.Text = "";
                        txbUser.Focus();

                        return false;
                    }
                    else
                    {
                        inicioSession = new CorralesEventos.Utilerias.Sesion();
                        inicioSession.idusuario = obj_usuario.idusuario;
                        inicioSession.nombre = obj_usuario.nombre + " " + obj_usuario.apellido;
                        return true;
                    }
                }

                
            }
            catch (Exception ex)
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.AppendLine("Ocurrió un error: ");
                sbMensaje.AppendLine(ex.Message);
                if (ex.InnerException != null)
                    sbMensaje.AppendLine(ex.InnerException.Message);
                MessageBox.Show(sbMensaje.ToString(), "Login",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void resultado(object sender, EventArgs e)
        {
            try
            {
                if (frmU.DialogResult.ToString() == "OK")
                {
                    using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                    {
                        txbUser.Text = frmU.usuarioR;
                        txbPass.Text = frmU.passR;
                        btnIngresar.Focus();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion
    }
}
