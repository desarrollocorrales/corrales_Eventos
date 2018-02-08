using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpandCollapsePanelDemo.Entidades;

namespace CorralesEventos.Utilerias
{
    public class Negocio
    {
        public usuarios GuardaUsuarioInicio(string nombre, string apellidos, string usuario, string contrasenia)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    usuarios obj_usuario = new usuarios();
                    obj_usuario.nombre = nombre;
                    obj_usuario.apellido = apellidos;
                    obj_usuario.usuario = usuario;
                    obj_usuario.password = new Seguridad().Encriptar(contrasenia);
                    obj_usuario.status = "A";

                    Ctx.usuarios.AddObject(obj_usuario);
                    Ctx.SaveChanges();

                    return obj_usuario;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public usuarios ModificaUsuario(string usuario, string NuevaContrasenia, string anteriorContrasenia)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    string pass = new Seguridad().Encriptar(anteriorContrasenia);
                    string NewPass = new Seguridad().Encriptar(NuevaContrasenia);

                    usuarios obj_usuarios = (from us in Ctx.usuarios where us.usuario == usuario.Trim() && us.password == pass.Trim() && us.status == "A" select us).FirstOrDefault();

                    if (obj_usuarios == null) throw new Exception("No se encontro usuario con los criterios capturados, favor de revisar.");
                    else
                    {
                        obj_usuarios.password = NewPass;
                        Ctx.SaveChanges();

                        return obj_usuarios;
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public usuarios BajaUsuario(int idusuario)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {

                    usuarios obj_usuario = (from p in Ctx.usuarios
                                            where p.idusuario == idusuario && p.status == "A"
                                            select p).FirstOrDefault();
                    obj_usuario.status = "B";
                    Ctx.SaveChanges();

                    return obj_usuario;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public paquete GuardaPaqueteNuevo(string nombre, string descripcion, string estatus, double costo)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    paquete obj_paquete = new paquete();
                    obj_paquete.nombre = nombre;
                    obj_paquete.descripcion = descripcion;
                    obj_paquete.status = estatus;
                    obj_paquete.costo = costo;

                    Ctx.paquete.AddObject(obj_paquete);
                    Ctx.SaveChanges();

                    return obj_paquete;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public paquete BajaPaquete(int idpaquete)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {

                    paquete obj_paquete = (from p in Ctx.paquete
                                           where p.idpaquete == idpaquete && p.status == "A"
                                            select p).FirstOrDefault();
                    obj_paquete.status = "B";
                    Ctx.SaveChanges();

                    return obj_paquete;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public paquete ModificaPaquete(int idpaquete, string nombre, string descripcion, string estatus, double costo)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    paquete obj_paquete = (from pqt in Ctx.paquete where pqt.idpaquete == idpaquete select pqt).FirstOrDefault();

                    obj_paquete.nombre = nombre;
                    obj_paquete.descripcion = descripcion;
                    obj_paquete.status = estatus;
                    obj_paquete.costo = costo;

                    Ctx.SaveChanges();
                    return obj_paquete;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public cliente GuardaClienteNuevo(string nombre, string direccion, string telefono)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    cliente obj_cliente = new cliente();
                    obj_cliente.nombre = nombre;
                    obj_cliente.direccion = direccion;
                    obj_cliente.telefono = telefono;
                    obj_cliente.status = "A";

                    Ctx.cliente.AddObject(obj_cliente);
                    Ctx.SaveChanges();

                    return obj_cliente;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public cliente BajaCliente(int idcliente)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {

                    cliente obj_cliente = (from p in Ctx.cliente
                                           where p.idcliente == idcliente && p.status == "A"
                                           select p).FirstOrDefault();
                    obj_cliente.status = "B";
                    Ctx.SaveChanges();

                    return obj_cliente;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public reservacion GuardaReservacion(string no_reservacion, int idcliente, int idpaquete, int idtipoevento, DateTime fecha, DateTime hora, int idusuario, double total, string observacion, double deposito, double saldo)
        {
            try{
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    reservacion newReservacion = new reservacion();

                    newReservacion.no_reservacion = no_reservacion;
                    newReservacion.idcliente = idcliente;
                    newReservacion.idpaquete = idpaquete;
                    newReservacion.fecha_reservacion = fecha;
                    newReservacion.hora_reservacion =  new TimeSpan(hora.Hour, hora.Minute, hora.Second);
                    newReservacion.idusuario = idusuario;
                    newReservacion.total = total;
                    newReservacion.estatus = "A";
                    newReservacion.idtevento = idtipoevento;

                    Ctx.reservacion.AddObject(newReservacion);
                    Ctx.SaveChanges();

                    seguimiento newSeguimiento = new seguimiento();

                    newSeguimiento.idreservacion = newReservacion.idreservacion;
                    newSeguimiento.observacion = observacion;
                    newSeguimiento.fecha_seguimiento = DateTime.Now;
                    newSeguimiento.saldo = saldo;
                    newSeguimiento.deposito = deposito;

                    Ctx.seguimiento.AddObject(newSeguimiento);
                    Ctx.SaveChanges();

                    return newReservacion;

                }
            }
            catch(Exception ex)
            { throw ex; }
        }

        public bool ActualizaReservacion(int id_reservacion, double deposito, double saldo, string observacion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    seguimiento UpdateRes = new seguimiento();
                    UpdateRes.idreservacion = id_reservacion;
                    UpdateRes.deposito = deposito;
                    UpdateRes.saldo = saldo;
                    UpdateRes.observacion = observacion;
                    UpdateRes.fecha_seguimiento = DateTime.Now;

                    Ctx.seguimiento.AddObject(UpdateRes);
                    Ctx.SaveChanges();

                    List<seguimiento> seg = (from s in Ctx.seguimiento where s.idreservacion == id_reservacion select s).ToList();
                    reservacion reservacion = (from r in Ctx.reservacion where r.idreservacion == id_reservacion select r).FirstOrDefault();

                    double? saldos = (from p in seg select p.saldo).Min();
                    if (saldos == 0)
                    {
                        reservacion.estatus = "T";
                        Ctx.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public reservacion BajaReservación(int idreservacion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {

                    reservacion obj_reservacion = (from p in Ctx.reservacion
                                                   where p.idreservacion == idreservacion && p.estatus == "A"
                                                   select p).FirstOrDefault();
                    obj_reservacion.estatus = "B";
                    Ctx.SaveChanges();

                    return obj_reservacion;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public tipo_evento GuardaTipoEvento(string nombre, string descripcion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    tipo_evento obj_evento = new tipo_evento();
                    obj_evento.nombre = nombre;
                    obj_evento.descripcion = descripcion;
                    obj_evento.status = "A";

                    Ctx.tipo_evento.AddObject(obj_evento);
                    Ctx.SaveChanges();

                    return obj_evento;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public tipo_evento ModificaEvento(int idtipo_evento, string nombre, string descripcion)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {
                    tipo_evento obj_tipo_evento = (from pqt in Ctx.tipo_evento where pqt.idtevento == idtipo_evento select pqt).FirstOrDefault();

                    obj_tipo_evento.nombre = nombre;
                    obj_tipo_evento.descripcion = descripcion;

                    Ctx.SaveChanges();
                    return obj_tipo_evento;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public tipo_evento BajaTipoEvento(int idevento)
        {
            try
            {
                using (corrales_eventosEntities Ctx = new corrales_eventosEntities())
                {

                    tipo_evento obj_tipo_evento = (from p in Ctx.tipo_evento
                                                   where p.idtevento == idevento && p.status == "A"
                                                   select p).FirstOrDefault();
                    obj_tipo_evento.status = "B";
                    Ctx.SaveChanges();

                    return obj_tipo_evento;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
