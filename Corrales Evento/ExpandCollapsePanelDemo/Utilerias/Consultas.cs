using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpandCollapsePanelDemo.Entidades;
using System.Drawing;

namespace CorralesEventos.Utilerias
{
    public class Consultas
    {
        public usuarios BuscaUsuarioInicio()
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    usuarios users = (from u in Ctx.usuarios where u.status == "A" select u).FirstOrDefault();

                    return users;
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public usuarios BuscaUsuario(string nombre, string contrasenia)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities()){
                    usuarios users = (from u in Ctx.usuarios where u.usuario == nombre && u.password == contrasenia && u.status == "A" select u).FirstOrDefault();

                    return users;
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void cargaDatosCatalogo(ComboBox cmb, string catalogo)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    switch (catalogo)
                    {
                        case "usuarios":
                            List<usuarios> lst_usuario = new List<usuarios>();
                            lst_usuario = (from ps in Ctx.usuarios where ps.status == "A" orderby ps.usuario select ps).ToList();
                            cmb.ValueMember = "idusuario";
                            cmb.DisplayMember = "usuario";
                            cmb.DataSource = lst_usuario;
                            cmb.SelectedIndex = -1;
                            break;
                        case "paquetes":
                            List<paquete> lst_paquetes = (from p in Ctx.paquete where p.status == "A" orderby p.descripcion select p).ToList();                                                        
                            if (lst_paquetes.Count > 0)
                            {
                                cmb.ValueMember = "idpaquete";
                                cmb.DisplayMember = "nombre";
                                cmb.DataSource = lst_paquetes;
                                cmb.SelectedIndex = -1;
                            }
                            else { throw new Exception("No se han encontrado paquetes registrados."); }
                            break;
                        case "clientes":
                            List<cliente> lst_cliente = (from c in Ctx.cliente where c.status == "A" orderby c.nombre select c).ToList();

                            if (lst_cliente.Count > 0)
                            {
                                cmb.ValueMember = "idcliente";
                                cmb.DisplayMember = "nombre";
                                cmb.DataSource = lst_cliente;
                                cmb.SelectedIndex = -1;
                            }
                            else { throw new Exception("No se han encontrado clientes registrados."); }
                            break;
                        case "tipo_evento":
                            List<tipo_evento> lst_eventos = (from c in Ctx.tipo_evento where c.status == "A" orderby c.nombre select c).ToList();

                            if (lst_eventos.Count > 0)
                            {
                                cmb.ValueMember = "idtevento";
                                cmb.DisplayMember = "nombre";
                                cmb.DataSource = lst_eventos;
                                cmb.SelectedIndex = -1;
                            }
                            else { throw new Exception("No se han encontrado Tipos de Eventos registrados."); }
                            break;
                        case "reservaciones":
                            List<reservacion> lst_reservacion = (from r in Ctx.reservacion where r.estatus == "A" orderby r.no_reservacion select r).ToList();

                            if (lst_reservacion.Count > 0)
                            {
                                cmb.ValueMember = "idreservacion";
                                cmb.DisplayMember = "no_reservacion";
                                cmb.DataSource = lst_reservacion;
                                cmb.SelectedIndex = -1;
                            }
                            else { throw new Exception("No se han encontrado reservaciones registrados."); }
                            break;
                    }
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void RetornaDatosCatalogos(DataGridView dgv, string catalogo)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    switch (catalogo)
                    {
                        case "usuario":
                            List<usuarios> lst_usuario = (from ps in Ctx.usuarios where ps.status == "A" orderby ps.usuario select ps).ToList();
                            dgv.DataSource = lst_usuario;
                            break;
                        case "paquete":
                            List<paquete> lst_paquetes = (from p in Ctx.paquete where p.status == "A" orderby p.descripcion select p).ToList();
                            dgv.DataSource = lst_paquetes;
                            break;
                        case "cliente":
                            List<cliente> lst_cliente = (from c in Ctx.cliente where c.status == "A" orderby c.nombre select c).ToList();
                            dgv.DataSource = lst_cliente;
                            break;
                        case "tipo_evento":
                            List<tipo_evento> lst_eventos = (from c in Ctx.tipo_evento where c.status == "A" orderby c.nombre select c).ToList();
                            dgv.DataSource = lst_eventos;
                            break;
                    }
                }
            }
            catch(Exception ex)
            { throw ex; }
        }

        public paquete RetornaPaquete(int idpaquete)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    paquete obj_paquete = new paquete();
                    return obj_paquete= (from p in Ctx.paquete where p.idpaquete == idpaquete select p).FirstOrDefault();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public cliente RetornaCliente(int idcliente)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    cliente obj_paquete = new cliente();
                    return obj_paquete = (from cli in Ctx.cliente where cli.idcliente == idcliente select cli).FirstOrDefault();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<reservacion> FechasReservadas(int mes, int anio)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    List<reservacion> lst_reservacion = (from r in Ctx.reservacion where r.fecha_reservacion.Month == mes && r.fecha_reservacion.Year == anio orderby r.fecha_reservacion select r).ToList();
                    return lst_reservacion;
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public void BuscaElemento(string tabla, int idelemento, ComboBox cmb)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    switch (tabla)
                    {
                        case "tipo_evento":
                            List<tipo_evento> lst_evento = (from te in Ctx.tipo_evento orderby te.nombre select te).ToList();
                            if (lst_evento.Count > 0)
                            {
                                cmb.DataSource = lst_evento;
                                cmb.DisplayMember = "nombre";
                                cmb.SelectedIndex = -1;
                            }
                            else
                            {
                                cmb.DataSource = null;
                                cmb.SelectedIndex = -1;
                            }
                            if (idelemento > 0)
                            {
                                int x = 0;
                                foreach (tipo_evento elemento in ((List<tipo_evento>)cmb.DataSource))
                                {
                                    if (elemento.idtevento == idelemento)
                                    {
                                        cmb.SelectedIndex = x;
                                        break;
                                    }
                                    x++;
                                }
                            }
                            break;
                        case "catalogos":
                            List<catalogos> lst_catalogos= (from te in Ctx.catalogos orderby te.nombre_tabla select te).ToList();
                            if (lst_catalogos.Count > 0)
                            {
                                cmb.DataSource = lst_catalogos;
                                cmb.DisplayMember = "nombre_tabla";
                                cmb.SelectedIndex = -1;
                            }
                            else
                            {
                                cmb.DataSource = null;
                                cmb.SelectedIndex = -1;
                            }
                            if (idelemento > 0)
                            {
                                int x = 0;
                                foreach (catalogos elemento in ((List<catalogos>)cmb.DataSource))
                                {
                                    if (elemento.idcatalogo == idelemento)
                                    {
                                        cmb.SelectedIndex = x;
                                        break;
                                    }
                                    x++;
                                }
                            }
                            break;
                    }                    
                }
            }
            catch(Exception ex)
            { throw ex;}
        }

        public void ResetCalendario(Panel pn)
        {
            try
            {
                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                Button btn = ((Button)CtrlS);
                                btn.Text = ""; btn.Visible = false;
                                btn.BackColor = Color.White; btn.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Retorna el nombre del dia especificado
        /// </summary>
        /// <param name="dia"> Dia de la semana en letra</param>
        /// <returns> cadena con el tag que inicia los dias del mes</returns>
        public string RetornaDia(string dia)
        {
            try
            {
                string diaR = string.Empty;
                switch (dia)
                {
                    case "lunes":
                        diaR = "LUN";
                        break;
                    case "martes":
                        diaR = "MAR";
                        break;
                    case "miércoles":
                        diaR = "MIE";
                        break;
                    case "jueves":
                        diaR = "JUE";
                        break;
                    case "viernes":
                        diaR = "VIE";
                        break;
                    case "sábado":
                        diaR = "SAB";
                        break;
                    case "domingo":
                        diaR = "DOM";
                        break;
                }

                return diaR;
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Metodo para cargar los dias correspondientes al mes consultado
        /// </summary>
        /// <param name="pn"> Panel contenedor de los Dias</param>
        /// <param name="tag"> Nombre del dia de inicio del mes</param>
        /// <param name="diasMes"> Dias que contiene el mes</param>
        public void AsignaDias(Panel pn, string tag, int diasMes)
        {
            try
            {
                int contador = 0; int dias = 1;
                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana1")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                Button btn = ((Button)CtrlS);
                                if (btn.Tag == tag)
                                {
                                    btn.Text = dias.ToString();
                                    btn.Visible = true;
                                    contador++;
                                }
                                else if (contador > 0)
                                {
                                    dias++;
                                    btn.Text = (dias).ToString();
                                    btn.Visible = true;
                                    contador++;
                                }
                            }
                        }
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana2")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                dias++;
                                Button btn = ((Button)CtrlS);
                                btn.Text = (dias).ToString();
                                btn.Visible = true;
                            }
                        }
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana3")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                dias++;
                                Button btn = ((Button)CtrlS);
                                btn.Text = (dias).ToString();
                                btn.Visible = true;
                            }
                        }
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana4")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                dias++;
                                Button btn = ((Button)CtrlS);
                                btn.Text = (dias).ToString();
                                btn.Visible = true;
                            }
                        }
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana5")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                Button btn = ((Button)CtrlS);

                                if (dias >= diasMes) return;

                                dias++;
                                btn.Text = (dias).ToString();
                                btn.Visible = true;
                            }
                        }
                    }
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel" && ctrl.Name == "pnSemana6")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                Button btn = ((Button)CtrlS);

                                if (dias >= diasMes) return;
                                dias++;
                                btn.Text = (dias).ToString();
                                btn.Visible = true;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Metodo para marcar en el calendario los dias ocupados.
        /// </summary>
        /// <param name="pn"> Panel contenedor de la representacion de los dias en el calendario</param>
        /// <param name="diaReservacion"> Dia registrado de reservacion</param>
        public void MarcaDias(Panel pn, int diaReservacion)
        {
            try
            {
                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl.GetType().ToString() == "System.Windows.Forms.Panel")
                    {
                        Panel pnS = ((Panel)ctrl);
                        foreach (Control CtrlS in pnS.Controls)
                        {
                            if (CtrlS.GetType().ToString() == "System.Windows.Forms.Button")
                            {
                                Button btn = ((Button)CtrlS);
                                if (btn.Visible == false) continue;
                                if (Convert.ToInt32(btn.Text) == diaReservacion)
                                {
                                    btn.BackColor = Color.Red;
                                    btn.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DatosReservaciones> BuscaReservaciones(string condicion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    List<DatosReservaciones> animales = Ctx.ExecuteStoreQuery<DatosReservaciones>("SELECT r.idreservacion, r.no_reservacion, c.idcliente, c.nombre cliente, c.direccion, c.telefono, p.idpaquete, p.nombre paquete, "
                        + "p.descripcion paquete_desc, tp.idtevento, tp.nombre evento, tp.descripcion evento_desc, r.saldo, p.costo, DATE_FORMAT(r.fecha_reservacion, '%d/%m/%Y') fecha_reservacion, TIME_FORMAT(r.hora_reservacion, '%r') hora_reservacion "
                        + " FROM corrales_eventos.reservacion r INNER JOIN corrales_eventos.cliente c on c.idcliente = r.idcliente INNER JOIN corrales_eventos.paquete p on p.idpaquete = r.idpaquete INNER JOIN corrales_eventos.tipo_evento tp on tp.idtevento = r.idtevento " 
                        + condicion).ToList();

                    return animales;
                }
            }
            catch (Exception x)
            { throw x; }
        }

        public List<DatosSeguimiento> BuscaSeguimiento(string condicion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    List<DatosSeguimiento> animales = Ctx.ExecuteStoreQuery<DatosSeguimiento>("SELECT r.idreservacion, r.no_reservacion, c.idcliente, c.nombre cliente, c.direccion, c.telefono, p.idpaquete, p.nombre paquete, " 
                    + "p.descripcion paquete_desc, tp.idtevento, tp.nombre evento, tp.descripcion evento_desc, s.deposito, s.saldo, p.costo, DATE_FORMAT(r.fecha_reservacion, '%d/%m/%Y') fecha_reservacion, "
                    + "TIME_FORMAT(r.hora_reservacion, '%r') hora_reservacion, DATE_FORMAT(s.fecha_seguimiento, '%d/%m/%Y') fecha_actualizacion FROM corrales_eventos.reservacion r INNER JOIN corrales_eventos.cliente c on c.idcliente = r.idcliente "
                    + "INNER JOIN corrales_eventos.paquete p on p.idpaquete = r.idpaquete INNER JOIN corrales_eventos.tipo_evento tp on tp.idtevento = r.idtevento INNER JOIN corrales_eventos.seguimiento s on s.idreservacion = r.idreservacion " + condicion).ToList();

                    return animales;
                }
            }
            catch (Exception x)
            { throw x; }
        }
    }

    public class DatosReservaciones
    {
        public int idreservacion { get; set; }
        public string no_reservacion { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int idpaquete{ get; set; }
        public string paquete { get; set; }
        public string paquete_desc { get; set; }
        public int idtevento { get; set; }
        public string evento { get; set; }
        public string evento_desc { get; set; }
        public double saldo { get; set; }
        public double costo { get; set; }
        public string fecha_reservacion { get; set; }
        public string hora_reservacion { get; set; }
    }

    public class DatosSeguimiento
    {
        public int idreservacion { get; set; }
        public string no_reservacion { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int idpaquete { get; set; }
        public string paquete { get; set; }
        public string paquete_desc { get; set; }
        public int idtevento { get; set; }
        public string evento { get; set; }
        public string evento_desc { get; set; }
        public double deposito { get; set; }
        public double saldo { get; set; }
        public double costo { get; set; }
        public string fecha_reservacion { get; set; }
        public string hora_reservacion { get; set; }
        public string fecha_actualizacion { get; set; }
    }
}
