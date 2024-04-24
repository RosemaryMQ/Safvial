using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using SAP.Properties;

namespace SAP.Tesoreria.Controles
{
    public partial class Autorizacion : Form
    {
        string master = SAP.Inicio.master;
        string clave = SAP.Inicio.clave;
        string super = (string)Settings.Default["Master"];
        public static int validador;
        String PDV;
        String Efectivo;
        String Tickets;
        String Prepagado;
        String NoPagados;
        String Estado = "Operativo";
        String boton1 = "Desactivar";
        string auxiliar = "";

        public Autorizacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (contrasena.Text == (string)Settings.Default["Master"])
                {
                    switch (SAP.Inicio.acceso)
                    {
                        case 1:
                            SAP.Tesoreria.Usuarios frm = new SAP.Tesoreria.Usuarios();
                            frm.ShowDialog();
                            this.Close();
                            break;
                        case 2:
                            SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                            frm1.ShowDialog();
                            this.Close();
                            break;
                        case 3:
                            break;
                        case 4:
                            SAP.Recaudadores.Controles.EditarCliente frm3 = new SAP.Recaudadores.Controles.EditarCliente();
                            frm3.ShowDialog();
                            this.Close();
                            break;
                        case 5:
                            validador = 1;
                            this.Close();
                            break;
                        case 8:
                            SAP.Recaudadores.Controles.ControlUsuarios frm4 = new SAP.Recaudadores.Controles.ControlUsuarios();
                            frm4.ShowDialog();
                            this.Close();
                            break;
                        case 7:
                            SAP.Recaudadores.Controles.OperacionesDiarias frm5 = new SAP.Recaudadores.Controles.OperacionesDiarias();
                            frm5.ShowDialog();
                            this.Close();
                            break;
                        case 9:
                            this.cajallena(SAP.Inicio.ID);
                            SAP.Inicio.Estado = "Operativo";
                            SAP.Cobradores.Controles.Avance frm9 = new SAP.Cobradores.Controles.Avance();
                            frm9.Show();
                            this.Close();
                            break;
                        case 10:
                            SAP.Tesoreria.Controles.Lista.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                            SAP.Tesoreria.Controles.EditarUsuario frm10 = new SAP.Tesoreria.Controles.EditarUsuario();
                            frm10.ShowDialog();
                            this.Close();
                            break;
                        case 11:
                            SAP.Tesoreria.Controles.Auditoria.RecordCierres frm11 = new SAP.Tesoreria.Controles.Auditoria.RecordCierres();
                            frm11.ShowDialog();
                            this.Close();
                            break;
                        case 12:
                            SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                            frm12.ShowDialog();
                            this.Close();
                            break;
                        case 13:
                            SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                            frm13.ShowDialog();
                            this.Close();
                            break;
                        case 14:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance frm14 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance();
                            frm14.ShowDialog();
                            this.Close();
                            break;
                        case 15:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre frm15 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre();
                            frm15.ShowDialog();
                            this.Close();
                            break;
                        case 16:
                            BloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                            MessageBox.Show("Usuario Bloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SAP.Recaudadores.Controles.Consulta frm16 = new SAP.Recaudadores.Controles.Consulta();
                            frm16.ShowDialog();
                            this.Close();
                            break;
                        case 17:
                            DesbloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                            MessageBox.Show("Usuario Desbloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SAP.Recaudadores.Controles.Consulta frm17 = new SAP.Recaudadores.Controles.Consulta();
                            frm17.ShowDialog();
                            this.Close();
                            break;
                        case 18:
                            actualizarweb(SAP.Recaudadores.SafvialWeb.RecargasAnuladas.id);
                            MessageBox.Show("Cambio de estatus cambiado sastifactoriamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;
                        case 19:
                            SAP.Configurador.MenuConfiguracion frm18 = new SAP.Configurador.MenuConfiguracion();
                            frm18.ShowDialog();
                            this.Close();
                            break;
                        case 20:
                            if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "1")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "NOCTURNO";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 2;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Nocturno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "2")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 1";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 3;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 1", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "3")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 2";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 4;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 2", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "4")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 1";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 5;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "5")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 2";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 6;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "6")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 3";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 7;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "7")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 00:00 - 12:00";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 00:00 - 12:00", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "8")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 12:00 - 23:59";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 12:00 - 23:59", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "9")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "DIURNO";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            break;
                        case 21:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                Arduino5.Close();
                            }
                            SAP.Cobradores.RecaudacionV2.TipoTabulacion = 4;
                            CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Exoneracion", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                            CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Exonerado", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                            this.Close();
                            break;
                        case 22:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Apertura Barrera", 0);
                                Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("B0000");
                                Arduino5.Close();
                            }
                            this.Close();
                            break;
                        case 23:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Cerrar Barrera", 0);
                                Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("C0000");
                                Arduino5.Close();
                            }
                            this.Close();
                            break;
                        case 24:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                Arduino5.Close();
                            }
                            SAP.Cobradores.RecaudacionV2.TipoTabulacion = 5;
                            CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Pago Incompleto", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                            CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Pago Incompleto", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                            this.Close();
                            break;
                        case 25:
                            if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 0)
                            {
                                MessageBox.Show("No hay tabulaciones detectadas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 1)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Normal", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.FacturaV2 frm66 = new SAP.Cobradores.Controles.FacturaV2();
                                frm66.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 2)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Prepagada", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm68 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                frm68.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 3)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Prepagada por Cobrar", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm67 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                frm67.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 4)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es una exoneracion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 5)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es un pago incompleto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            break;
                        case 26:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados frm26 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados();
                            frm26.ShowDialog();
                            this.Close();
                            break;
                        case 27:
                            SAP.Recaudadores.Controles.PromocionesPrepagado.editarPromo = true;
                            SAP.Recaudadores.Controles.PromocionesPrepagado frm27 = new SAP.Recaudadores.Controles.PromocionesPrepagado();
                            frm27.ShowDialog();
                            SAP.Recaudadores.Controles.PromocionesPrepagado.editarPromo = false;
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrasena.Text = "";
                            break;
                    }
                }
                else if (Operacional(contrasena.Text))
                {
                    switch (SAP.Inicio.acceso)
                    {
                        case 1:
                            SAP.Tesoreria.Usuarios frm = new SAP.Tesoreria.Usuarios();
                            frm.ShowDialog();
                            this.Close();
                            break;
                        case 2:
                            SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                            frm1.ShowDialog();
                            this.Close();
                            break;
                        case 3:
                            break;
                        case 4:
                            SAP.Recaudadores.Controles.EditarCliente frm3 = new SAP.Recaudadores.Controles.EditarCliente();
                            frm3.ShowDialog();
                            this.Close();
                            break;
                        case 5:
                            validador = 1;
                            this.Close();
                            break;
                        case 8:
                            SAP.Recaudadores.Controles.ControlUsuarios frm4 = new SAP.Recaudadores.Controles.ControlUsuarios();
                            frm4.ShowDialog();
                            this.Close();
                            break;
                        case 7:
                            SAP.Recaudadores.Controles.OperacionesDiarias frm5 = new SAP.Recaudadores.Controles.OperacionesDiarias();
                            frm5.ShowDialog();
                            this.Close();
                            break;
                        case 9:
                            this.cajallena(SAP.Inicio.ID);
                            SAP.Inicio.Estado = "Operativo";
                            SAP.Cobradores.Controles.Avance frm9 = new SAP.Cobradores.Controles.Avance();
                            frm9.Show();
                            this.Close();
                            break;
                        case 10:
                            SAP.Tesoreria.Controles.Lista.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                            SAP.Tesoreria.Controles.EditarUsuario frm10 = new SAP.Tesoreria.Controles.EditarUsuario();
                            frm10.ShowDialog();
                            this.Close();
                            break;
                        case 11:
                            SAP.Tesoreria.Controles.Auditoria.RecordCierres frm11 = new SAP.Tesoreria.Controles.Auditoria.RecordCierres();
                            frm11.ShowDialog();
                            this.Close();
                            break;
                        case 12:
                            SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                            frm12.ShowDialog();
                            this.Close();
                            break;
                        case 13:
                            SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                            frm13.ShowDialog();
                            this.Close();
                            break;
                        case 14:
                            MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            contrasena.Text = "";
                            break;
                        case 15:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre frm15 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre();
                            frm15.ShowDialog();
                            this.Close();
                            break;
                        case 16:
                            BloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                            MessageBox.Show("Usuario Bloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SAP.Recaudadores.Controles.Consulta frm16 = new SAP.Recaudadores.Controles.Consulta();
                            frm16.ShowDialog();
                            this.Close();
                            break;
                        case 17:
                            DesbloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                            MessageBox.Show("Usuario Desbloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SAP.Recaudadores.Controles.Consulta frm17 = new SAP.Recaudadores.Controles.Consulta();
                            frm17.ShowDialog();
                            this.Close();
                            break;
                        case 18:
                            actualizarweb(SAP.Recaudadores.SafvialWeb.RecargasAnuladas.id);
                            MessageBox.Show("Cambio de estatus cambiado sastifactoriamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;
                        case 19:
                            MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrasena.Text = "";
                            break;
                        case 20:
                            MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrasena.Text = "";
                            break;
                        case 26:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados frm26 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados();
                            frm26.ShowDialog();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrasena.Text = "";
                            break;
                    }
                }
                else if (Auditoria(contrasena.Text) && SAP.Inicio.interfaz == "Administrador")
                {
                    switch (SAP.Inicio.acceso)
                    {
                        case 2:
                            SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                            frm1.ShowDialog();
                            this.Close();
                            break;
                        case 14:
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance frm14 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance();
                            frm14.ShowDialog();
                            this.Close();
                            break;
                        case 20:
                            if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "1")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "NOCTURNO";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 2;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Nocturno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "2")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 1";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 3;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 1", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "3")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 2";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 4;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 2", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "4")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 1";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 5;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "5")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 2";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 6;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "6")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 3";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 7;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "7")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 00:00 - 12:00";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 00:00 - 12:00", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "8")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 12:00 - 23:59";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 12:00 - 23:59", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "9")
                            {
                                CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "DIURNO";
                                SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }

                            break;
                        default:
                            MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrasena.Text = "";
                            break;

                    }
                }
                else if (CanalesSecurity(contrasena.Text) && SAP.Inicio.interfaz == "Recaudador")
                {
                    switch (SAP.Inicio.acceso)
                    {
                        case 25:
                            if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 0)
                            {
                                MessageBox.Show("No hay tabulaciones detectadas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 1)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Normal", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 2)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Prepagada", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 3)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Prepagada por Cobrar", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 4)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es una exoneracion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 5)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es un pago incompleto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            break;
                    }
                }
                else if (Supervisores(contrasena.Text) && SAP.Inicio.interfaz == "Recaudador")
                {
                    switch (SAP.Inicio.acceso)
                    {
                        case 13:
                            SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                            frm13.ShowDialog();
                            this.Close();
                            break;
                        case 12:
                            SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                            SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                            frm12.ShowDialog();
                            this.Close();
                            break;
                        case 21:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                Arduino5.PortName = SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                Arduino5.Close();
                            }
                            SAP.Cobradores.RecaudacionV2.TipoTabulacion = 4;
                            CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Exoneracion", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                            CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Exonerado", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                            this.Close();
                            break;
                        case 22:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Apertura Barrera", 0);
                                Arduino5.PortName = SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("B0000");
                                Arduino5.Close();
                            }
                            this.Close();
                            break;
                        case 23:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Cerrar Barrera", 0);
                                Arduino5.PortName = SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("C0000");
                                Arduino5.Close();
                            }
                            this.Close();
                            break;
                        case 24:
                            if (SAP.Cobradores.RecaudacionV2.com != "0")
                            {

                                Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                Arduino5.DtrEnable = false;
                                Arduino5.Open();
                                Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                Arduino5.Close();
                            }
                            SAP.Cobradores.RecaudacionV2.TipoTabulacion = 5;
                            CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Pago Incompleto", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                            CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Pago Incompleto", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                            this.Close();
                            break;
                        case 25:
                            if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 0)
                            {
                                MessageBox.Show("No hay tabulaciones detectadas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 1)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Normal", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 2)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Prepagada", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 3)
                            {
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Prepagada por Cobrar", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                SAP.Cobradores.RecaudacionV2.com = "0";
                                SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                frm1.Show();
                                SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 4)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es una exoneracion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 5)
                            {
                                MessageBox.Show("la ultima tabulacion detectada es un pago incompleto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            break;
                        default:
                            contrasena.Text = "";
                            MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña Invalida.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    contrasena.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Contraseña Invalida.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contrasena.Text = "";
            }
            
        }

        private void contrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (contrasena.Text == (string)Settings.Default["Master"])
                    {
                        switch (SAP.Inicio.acceso)
                        {
                            case 1:
                                SAP.Tesoreria.Usuarios frm = new SAP.Tesoreria.Usuarios();
                                frm.ShowDialog();
                                this.Close();
                                break;
                            case 2:
                                SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                                frm1.ShowDialog();
                                this.Close();
                                break;
                            case 3:
                                break;
                            case 4:
                                SAP.Recaudadores.Controles.EditarCliente frm3 = new SAP.Recaudadores.Controles.EditarCliente();
                                frm3.ShowDialog();
                                this.Close();
                                break;
                            case 5:
                                validador = 1;
                                this.Close();
                                break;
                            case 8:
                                SAP.Recaudadores.Controles.ControlUsuarios frm4 = new SAP.Recaudadores.Controles.ControlUsuarios();
                                frm4.ShowDialog();
                                this.Close();
                                break;
                            case 7:
                                SAP.Recaudadores.Controles.OperacionesDiarias frm5 = new SAP.Recaudadores.Controles.OperacionesDiarias();
                                frm5.ShowDialog();
                                this.Close();
                                break;
                            case 9:
                                this.cajallena(SAP.Inicio.ID);
                                SAP.Inicio.Estado = "Operativo";
                                SAP.Cobradores.Controles.Avance frm9 = new SAP.Cobradores.Controles.Avance();
                                frm9.Show();
                                this.Close();
                                break;
                            case 10:
                                SAP.Tesoreria.Controles.Lista.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                                SAP.Tesoreria.Controles.EditarUsuario frm10 = new SAP.Tesoreria.Controles.EditarUsuario();
                                frm10.ShowDialog();
                                this.Close();
                                break;
                            case 11:
                                SAP.Tesoreria.Controles.Auditoria.RecordCierres frm11 = new SAP.Tesoreria.Controles.Auditoria.RecordCierres();
                                frm11.ShowDialog();
                                this.Close();
                                break;
                            case 12:
                                SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                                frm12.ShowDialog();
                                this.Close();
                                break;
                            case 13:
                                SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                                frm13.ShowDialog();
                                this.Close();
                                break;
                            case 14:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance frm14 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance();
                                frm14.ShowDialog();
                                this.Close();
                                break;
                            case 15:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre frm15 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre();
                                frm15.ShowDialog();
                                this.Close();
                                break;
                            case 16:
                                BloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                                MessageBox.Show("Usuario Bloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SAP.Recaudadores.Controles.Consulta frm16 = new SAP.Recaudadores.Controles.Consulta();
                                frm16.ShowDialog();
                                this.Close();
                                break;
                            case 17:
                                DesbloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                                MessageBox.Show("Usuario Desbloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SAP.Recaudadores.Controles.Consulta frm17 = new SAP.Recaudadores.Controles.Consulta();
                                frm17.ShowDialog();
                                this.Close();
                                break;
                            case 18:
                                actualizarweb(SAP.Recaudadores.SafvialWeb.RecargasAnuladas.id);
                                MessageBox.Show("Cambio de estatus cambiado sastifactoriamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                break;
                            case 19:
                                SAP.Configurador.MenuConfiguracion frm18 = new SAP.Configurador.MenuConfiguracion();
                                frm18.ShowDialog();
                                this.Close();
                                break;
                            case 20:
                                if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "1")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "NOCTURNO";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 2;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Nocturno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "2")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 1";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 3;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 1", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "3")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 2";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 4;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 2", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "4")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 1";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 5;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "5")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 2";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 6;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "6")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 3";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 7;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "7")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 00:00 - 12:00";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 00:00 - 12:00", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "8")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 12:00 - 23:59";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 12:00 - 23:59", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "9")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "DIURNO";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                break;
                            case 21:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                    Arduino5.Close();
                                }
                                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 4;
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Exoneracion", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Exonerado", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                                this.Close();
                                break;
                            case 22:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Apertura Barrera", 0);
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("B0000");
                                    Arduino5.Close();
                                }
                                this.Close();
                                break;
                            case 23:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Cerrar Barrera", 0);
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("C0000");
                                    Arduino5.Close();
                                }
                                this.Close();
                                break;
                            case 24:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                    Arduino5.Close();
                                }
                                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 5;
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Pago Incompleto", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Pago Incompleto", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                                this.Close();
                                break;
                            case 25:
                                if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 0)
                                {
                                    MessageBox.Show("No hay tabulaciones detectadas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 1)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Normal", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.FacturaV2 frm66 = new SAP.Cobradores.Controles.FacturaV2();
                                    frm66.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 2)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Prepagada", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm68 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                    frm68.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 3)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Prepagada por Cobrar", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm67 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                    frm67.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 4)
                                {
                                    MessageBox.Show("la ultima tabulacion detectada es una exoneracion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 5)
                                {
                                    MessageBox.Show("la ultima tabulacion detectada es un pago incompleto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                break;
                            case 26:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados frm26 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados();
                                frm26.ShowDialog();
                                this.Close();
                                break;
                            case 27:
                                SAP.Recaudadores.Controles.PromocionesPrepagado.editarPromo = true;
                                SAP.Recaudadores.Controles.PromocionesPrepagado frm27 = new SAP.Recaudadores.Controles.PromocionesPrepagado();
                                frm27.ShowDialog();
                                SAP.Recaudadores.Controles.PromocionesPrepagado.editarPromo = false;
                                this.Close();
                                break;
                            default:
                                MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                contrasena.Text = "";
                                break;
                        }
                    }
                    else if (Operacional(contrasena.Text))
                    {
                        switch (SAP.Inicio.acceso)
                        {
                            case 1:
                                SAP.Tesoreria.Usuarios frm = new SAP.Tesoreria.Usuarios();
                                frm.ShowDialog();
                                this.Close();
                                break;
                            case 2:
                                SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                                frm1.ShowDialog();
                                this.Close();
                                break;
                            case 3:
                                break;
                            case 4:
                                SAP.Recaudadores.Controles.EditarCliente frm3 = new SAP.Recaudadores.Controles.EditarCliente();
                                frm3.ShowDialog();
                                this.Close();
                                break;
                            case 5:
                                validador = 1;
                                this.Close();
                                break;
                            case 8:
                                SAP.Recaudadores.Controles.ControlUsuarios frm4 = new SAP.Recaudadores.Controles.ControlUsuarios();
                                frm4.ShowDialog();
                                this.Close();
                                break;
                            case 7:
                                SAP.Recaudadores.Controles.OperacionesDiarias frm5 = new SAP.Recaudadores.Controles.OperacionesDiarias();
                                frm5.ShowDialog();
                                this.Close();
                                break;
                            case 9:
                                this.cajallena(SAP.Inicio.ID);
                                SAP.Inicio.Estado = "Operativo";
                                SAP.Cobradores.Controles.Avance frm9 = new SAP.Cobradores.Controles.Avance();
                                frm9.Show();
                                this.Close();
                                break;
                            case 10:
                                SAP.Tesoreria.Controles.Lista.ID_Usuario1 = SAP.Tesoreria.TesoreriaV2.Identificador;
                                SAP.Tesoreria.Controles.EditarUsuario frm10 = new SAP.Tesoreria.Controles.EditarUsuario();
                                frm10.ShowDialog();
                                this.Close();
                                break;
                            case 11:
                                SAP.Tesoreria.Controles.Auditoria.RecordCierres frm11 = new SAP.Tesoreria.Controles.Auditoria.RecordCierres();
                                frm11.ShowDialog();
                                this.Close();
                                break;
                            case 12:
                                SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                                frm12.ShowDialog();
                                this.Close();
                                break;
                            case 13:
                                SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                                frm13.ShowDialog();
                                this.Close();
                                break;
                            case 14:
                                MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                contrasena.Text = "";
                                break;
                            case 15:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre frm15 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.GenerarCierre();
                                frm15.ShowDialog();
                                this.Close();
                                break;
                            case 16:
                                BloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                                MessageBox.Show("Usuario Bloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SAP.Recaudadores.Controles.Consulta frm16 = new SAP.Recaudadores.Controles.Consulta();
                                frm16.ShowDialog();
                                this.Close();
                                break;
                            case 17:
                                DesbloquearTarjeta(SAP.Recaudadores.Controles.Consulta.ID_Cliente);
                                MessageBox.Show("Usuario Desbloqueado Correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SAP.Recaudadores.Controles.Consulta frm17 = new SAP.Recaudadores.Controles.Consulta();
                                frm17.ShowDialog();
                                this.Close();
                                break;
                            case 18:
                                actualizarweb(SAP.Recaudadores.SafvialWeb.RecargasAnuladas.id);
                                MessageBox.Show("Cambio de estatus cambiado sastifactoriamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                break;
                            case 19:
                                MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                contrasena.Text = "";
                                break;
                            case 20:
                                MessageBox.Show("Contraseña con insuficientes permisos", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                contrasena.Text = "";
                                break;
                            case 26:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados frm26 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Tesorero.AvancesEditados();
                                frm26.ShowDialog();
                                this.Close();
                                break;
                            default:
                                MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                contrasena.Text = "";
                                break;
                        }
                    }
                    else if (Auditoria(contrasena.Text) && SAP.Inicio.interfaz == "Administrador")
                    {
                        switch (SAP.Inicio.acceso)
                        {
                            case 2:
                                SAP.Tesoreria.Reportes frm1 = new SAP.Tesoreria.Reportes();
                                frm1.ShowDialog();
                                this.Close();
                                break;
                            case 14:
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance frm14 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.EditarAvance();
                                frm14.ShowDialog();
                                this.Close();
                                break;
                            case 20:
                                if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "1")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 2, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "NOCTURNO";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 2;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Nocturno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "2")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 3, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 1";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 3;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 1", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "3")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 4, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "COMPLETO 2";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 4;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Completo Grupo 2", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "4")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 5, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 1";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 5;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "5")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 6, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 2";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 6;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "6")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 7, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "TURNO 3";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 7;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "7")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 8, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 00:00 - 12:00";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 00:00 - 12:00", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "8")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 9, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "Turno 12h 12:00 - 23:59";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Turno 12h 12:00 - 23:59", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Tesoreria.Controles.ListaDeclaraciones.turno == "9")
                                {
                                    CambiarTurno(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoTR(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    CambiarTurnoP(SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario, 1, SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial, SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turno = "DIURNO";
                                    SAP.Tesoreria.Controles.Declaraciones.DeclaracionParametrizado.turnocod = 1;
                                    MessageBox.Show("El cambio de turno ha sido procesado exitosamente, el turno asignado es: Diurno", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                break;
                            default:
                                MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                contrasena.Text = "";
                                break;

                        }
                    }
                    else if (CanalesSecurity(contrasena.Text) && SAP.Inicio.interfaz == "Recaudador")
                    {
                        switch (SAP.Inicio.acceso)
                        {
                            case 25:
                                if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 0)
                                {
                                    MessageBox.Show("No hay tabulaciones detectadas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 1)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Normal", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.FacturaV2 frm1 = new SAP.Cobradores.Controles.FacturaV2();
                                    frm1.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 2)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Factura Prepagada", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPrepagada();
                                    frm1.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 3)
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Copia Prepagada por Cobrar", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                    auxiliar = SAP.Cobradores.RecaudacionV2.com;
                                    SAP.Cobradores.RecaudacionV2.com = "0";
                                    SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar frm1 = new SAP.Cobradores.Controles.SaldoPrepagado.FacturaPorCobrar();
                                    frm1.Show();
                                    SAP.Cobradores.RecaudacionV2.com = Convert.ToString(auxiliar);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 4)
                                {
                                    MessageBox.Show("la ultima tabulacion detectada es una exoneracion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else if (SAP.Cobradores.RecaudacionV2.TipoTabulacion == 5)
                                {
                                    MessageBox.Show("la ultima tabulacion detectada es un pago incompleto.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                break;
                        }
                    }
                    else if (Supervisores(contrasena.Text) && SAP.Inicio.interfaz == "Recaudador")
                    {
                        switch (SAP.Inicio.acceso)
                        {
                            case 13:
                                SAP.Tesoreria.Controles.Auditoria.HistorialCanal frm13 = new SAP.Tesoreria.Controles.Auditoria.HistorialCanal();
                                frm13.ShowDialog();
                                this.Close();
                                break;
                            case 12:
                                SAP.Tesoreria.TesoreriaV2.id = SAP.Tesoreria.TesoreriaV2.Identificador;
                                SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances frm12 = new SAP.Tesoreria.Controles.Declaraciones.VersionV2.Avances();
                                frm12.ShowDialog();
                                this.Close();
                                break;
                            case 21:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                    Arduino5.Close();
                                }
                                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 4;
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Exoneracion", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Exonerado", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                                this.Close();
                                break;
                            case 22:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Apertura Barrera", 0);
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("B0000");
                                    Arduino5.Close();
                                }
                                this.Close();
                                break;
                            case 23:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Cerrar Barrera", 0);
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("C0000");
                                    Arduino5.Close();
                                }
                                this.Close();
                                break;
                            case 24:
                                if (SAP.Cobradores.RecaudacionV2.com != "0")
                                {
                                    Arduino5.PortName =  SAP.Cobradores.RecaudacionV2.com;
                                    Arduino5.DtrEnable = false;
                                    Arduino5.Open();
                                    Arduino5.Write("@" + SAP.Cobradores.RecaudacionV2.vehiculo + "0000");
                                    Arduino5.Close();
                                }
                                SAP.Cobradores.RecaudacionV2.TipoTabulacion = 5;
                                CargarOperacion(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Inicio.Canal), contrasena.Text, "Pago Incompleto", Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo));
                                CargarPago(Convert.ToInt32(SAP.Inicio.ID), Convert.ToInt32(SAP.Cobradores.Controles.V2.FormaPago.codigovehiculo), "Pago Incompleto", Convert.ToInt32(SAP.Inicio.Canal), Convert.ToInt32(SAP.Inicio.Turno));
                                this.Close();
                                break;
                            default:
                                contrasena.Text = "";
                                MessageBox.Show("Contraseña con insuficientes permisos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Invalida.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contrasena.Text = "";
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Contraseña Invalida."+ex.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contrasena.Text = "";
            }
           
        }

        private void label2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void reportecaja(string usuario, string canal, string fecha, string monto, int efectivo, int pdv, int tickets, int prepagado, int nopagados)
        {
            string sql = "Insert into CierreCajas (Usuario,Canal,Fecha,MontoVaciado,Efectivo,PDV,Tickets,Prepagado,NoPagados) values (@usuario,@canal,@fecha,@monto,@efectivo,@pdv,@tickets,@prepagado,@nopagados)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", Convert.ToInt32(usuario));
                cmd.Parameters.AddWithValue("canal", Convert.ToInt32(canal));
                cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(fecha));
                cmd.Parameters.AddWithValue("monto", Convert.ToDouble(monto));
                cmd.Parameters.AddWithValue("efectivo", efectivo);
                cmd.Parameters.AddWithValue("pdv", pdv);
                cmd.Parameters.AddWithValue("tickets", tickets);
                cmd.Parameters.AddWithValue("prepagado", prepagado);
                cmd.Parameters.AddWithValue("nopagados", nopagados);
                cmd.ExecuteReader();
                return;
            }
        }
        private bool Auditoria(string password)
        {
            string sql = "SELECT * FROM  Auditoria WHERE Contrasena=@clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void BloquearTarjeta(String Cliente)
        {
            string sql = "Update TarjetasCliente Set Bloqueada=1,Operador=@usuario Where ID_Cliente=@Cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Cliente", Convert.ToInt32(Cliente));
                cmd.Parameters.AddWithValue("usuario", SAP.Inicio.ID);
                cmd.ExecuteReader();
                return;
            }
        }
        private bool Supervisores(string password)
        {
            string sql = "SELECT * FROM Supervisor WHERE Autorizado = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private bool CanalesSecurity(string password)
        {
            string sql = "SELECT Id, Password FROM CanalesSecurity where Password = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private bool Operacional(string password)
        {
            string sql = "SELECT * FROM  Operaciones WHERE (ID <> 5) AND (ID <> 6) AND Password=@clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                int val = Convert.ToInt32(cmd.ExecuteScalar());
                return !(val == 0);
            }
        }
        private void DesbloquearTarjeta(String Cliente)
        {
            string sql = "Update TarjetasCliente Set Bloqueada=0,Operador=@usuario Where ID_Cliente=@Cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("Cliente", Convert.ToInt32(Cliente));
                cmd.Parameters.AddWithValue("usuario", SAP.Inicio.ID);
                cmd.ExecuteReader();
                return;
            }
        }
        private void ContadorPDV(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS PDV FROM Pagos WHERE(FormaPago = 'Punto de Venta') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PDV = dr["PDV"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorTickets(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Tickets FROM Pagos WHERE(FormaPago = 'Ticket') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tickets = dr["Tickets"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorEfectivo(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Efectivo FROM Pagos WHERE(FormaPago = 'Efectivo') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Efectivo = dr["Efectivo"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorPrepagado(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS Prepagado FROM Pagos WHERE(FormaPago = 'Saldo Pre-pagado') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prepagado = dr["Prepagado"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void ContadorNoPagado(String fechas, int canal)
        {
            string sql = " SELECT COUNT(FormaPago) AS NoPagos FROM Pagos WHERE(FormaPago = 'No Pago') AND(Fecha BETWEEN @parametro + '00:00:00' AND @parametro + '23:59:59') AND(ID_Usuario = @usuario)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("parametro", Convert.ToDateTime(fechas));
                cmd.Parameters.AddWithValue("usuario", canal);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NoPagados = dr["NoPagos"].ToString();
                }
                dr.Close();
                return;
            }
        }
        private void cajallena(string usuario)
        {
            string sql = "Update ControlRecaudadores Set Estado='Operativo' Where ID_Usuario=@usuario";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.ExecuteReader();
                return;
            }
        }
        private void actualizarweb(int cliente)
        {
            string sql = "Update RecargasWEB Set Condicion='Pendiente' Where ID_Operacion=@cliente";
            using (SqlConnection cn = new SqlConnection(Inicio.WEB))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("cliente", cliente);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CambiarTurno(int codigo,int turno, string fecha, string fecha1)
        {
            string sql = "UPDATE CierreBalanceV2 SET Turno=@turno WHERE ID_Usuario=@Codigo AND Fecha Between @fecha and @fecha1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CambiarTurnoR(int codigo, int turno, string fecha, string fecha1)
        {
            string sql = "UPDATE Recaudadore SET Turno=@turno WHERE ID_Usuario=@Codigo AND Fecha Between @fecha and @fecha1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CambiarTurnoP(int codigo, int turno, string fecha, string fecha1)
        {
            string sql = "UPDATE Pagos SET Turno=@turno WHERE ID_Usuario=@Codigo AND Fecha Between @fecha and @fecha1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CambiarTurnoTR(int codigo, int turno, string fecha, string fecha1)
        {
            string sql = "UPDATE Turno SET Turno=@turno WHERE ID_Usuario=@Codigo AND Fecha Between @fecha and @fecha1;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarPago(int id_user, int id_vehiculo, string forma, int canal, int turno)
        {
            string sql = "Insert into Pagos (ID_Usuario,ID_Vehiculo,Fecha,FormaPago,Referencia,Canal,Turno) Values (@iduser,@idvehiculo,SYSDATETIME(),@forma,NULL,@canal,@turno)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", id_user);
                cmd.Parameters.AddWithValue("idvehiculo", id_vehiculo);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.ExecuteReader();
                return;
            }
        }
        private void CargarOperacion(int usuario, int canal, string Tarjeta, string operacion,int vehiculo)
        {
            string sql = "Insert into BarreraControl (ID_Usuario,Canal,Tarjeta,Fecha,Operacion,ID_Vehiculo) Values (@iduser,@canal,@tarjeta,SYSDATETIME(),@operacion,@vehiculo)";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("iduser", usuario);
                cmd.Parameters.AddWithValue("canal", canal);
                cmd.Parameters.AddWithValue("tarjeta", Tarjeta);
                cmd.Parameters.AddWithValue("operacion", operacion);
                cmd.Parameters.AddWithValue("vehiculo", vehiculo);
                cmd.ExecuteReader();
                return;
            }
        }
    }
}

