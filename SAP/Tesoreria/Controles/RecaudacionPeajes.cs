using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SAP.Properties;
using System.Collections.Generic;

namespace SAP.Tesoreria.Controles
{
    public partial class RecaudacionPeajes : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        Double webg;
        Double webe;
        string fechainicial ="";
        string fechafin = "";
        string fechainicial2 = "";
        string fechafin2 = "";
        double livianos = 0;
        double microbus = 0;
        double autobus = 0;
        double cargaliviana = 0;
        double ejes2 = 0;
        double eje3 = 0;
        double eje4 = 0;
        double eje5 = 0;
        double eje6 = 0;
        double livianosP = 0;
        double microbusP = 0;
        double autobusP = 0;
        double cargalivianaP = 0;
        double ejes2P = 0;
        double eje3P = 0;
        double eje4P = 0;
        double eje5P = 0;
        double eje6P = 0;
        public RecaudacionPeajes()
        {
            InitializeComponent();
            fechas = Convert.ToString(this.LastDayOfMonthFromDateTime(DateTime.Now));
            date1.Value.ToShortDateString();
            fecha2.Value.ToShortDateString();
    
        }
        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        private async Task<double> ConsultaEspecia(string forma, int sedes, DateTime fecha1, DateTime fecha2)
        {
            string sql = "SELECT (CASE WHEN  SUM(Ventas.Monto) IS NULL THEN 0  ELSE SUM(Ventas.Monto) END) AS Recaudado FROM Ventas INNER JOIN Sede ON Ventas.Sede = Sede.ID_Sede WHERE Ventas.FormaPago = @forma AND Ventas.Sede = @donde AND Ventas.Fecha BETWEEN @fecha1 AND @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                double resultado = 0;
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("donde", sedes);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {

                    resultado = Convert.ToDouble(dr["Recaudado"]);
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        private async void RecaudacionPeajes_Load(object sender, EventArgs e)
        {

            try
            {
                int turnos = 0;
                int turnos2 = 0;
                string Guacara;
                string LaEntrada;
                Loading.Visible = true;
                Accion.Text = "Inicializando el proceso...";
                fechainicial = "";
                fechafin = "";
                Accion.Text = "Conectando con ambas sedes...";
                turnos = 1;
                fechainicial = await Control(1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                Accion.Text = "Obteniendo informacion.";
                if (fechainicial == "")
                {
                    turnos = 2;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial = await Control(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }

                if (fechainicial == "")
                {
                    turnos = 3;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial = await Control(3, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 4;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control(4, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 5;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 03:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 6;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 12:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 7;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 12:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 11:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 8;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 10:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 9;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 10:59:59"), (string)Settings.Default["Sede1"]);
                }
                Accion.Text = "Obteniendo Turno...";
                if (fechafin == "" && turnos == 1)
                {
                    turnos++;
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 2)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 20:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 3)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 4)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 5)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 6)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["Sede1"]);
                }
                 if (fechafin == "" && turnos == 8)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00").AddHours(-4), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 9)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 10:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 10:00:00"), (string)Settings.Default["Sede1"]);
                }
                turnos2 = 1;
                fechainicial2 = await Control(1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                Accion.Text = "Obteniendo informacion.";
                if (fechainicial2 == "")
                {
                    turnos2 = 2;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial2 = await Control(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 3;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial2 = await Control(3, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 4;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control(4, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 5;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 04:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 6;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 12:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 7;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 10:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 8;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 9;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 11:59:59"), (string)Settings.Default["SAP2"]);
                }
                Accion.Text = "Obteniendo Turno...";
                if (fechafin2 == "" && turnos2 == 1)
                {
                    turnos2++;
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 2)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 20:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 3)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 4)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 5)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 13:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 04:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 6)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 13:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 04:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 7)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 13:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 04:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 8)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00").AddHours(-4), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 9)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 11:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 09:59:59"), (string)Settings.Default["SAP2"]);
                }
                //if (fechafin2 == "" && turnos2 == 5)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                //if (fechafin2 == "" && turnos2 == 6)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                //if (fechafin2 == "" && turnos2 == 7)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                Accion.Text = "Validando informacion...";
                if (fechainicial != "" && fechafin != "" && fechainicial2 != "" && fechafin2 != "")
                {
                    Accion.Text = "Obteniendo datos del servicio prepagado...";
                    webe = await ConsultaEspecia("Recarga WEB", 2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 06:30:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 06:30:00"));
                    webg = await ConsultaEspecia("Recarga WEB", 1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 06:30:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 06:30:00"));
                    Accion.Text = "Obteniendo informacion faltante...";
                    Guacara = await Sede((string)Settings.Default["Sede1"]);
                    LaEntrada = await Sede((string)Settings.Default["SAP2"]);
                    Microsoft.Reporting.WinForms.ReportParameter frm10 = new Microsoft.Reporting.WinForms.ReportParameter("sede1", Guacara.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm10);
                    Microsoft.Reporting.WinForms.ReportParameter frm11 = new Microsoft.Reporting.WinForms.ReportParameter("sede2", LaEntrada.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm11);
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", fechainicial);
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fechafin);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    double rt = 0;
                    double rt2 = 0;
                    double result = 0;
                    if (turnos > 2)
                    {
                        rt = 0;
                        rt = Consulta(turnos, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm12 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG1", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm12);
                        rt = 0;
                        rt = Consulta2(turnos, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm14 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG1", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm14);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm101 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede1", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm102 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede1", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm103 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede1", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm104 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm105 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm106 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede1", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm107 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede1", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm108 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede1", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm109 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede1", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm101);
                        this.reportViewer1.LocalReport.SetParameters(frm102);
                        this.reportViewer1.LocalReport.SetParameters(frm103);
                        this.reportViewer1.LocalReport.SetParameters(frm104);
                        this.reportViewer1.LocalReport.SetParameters(frm105);
                        this.reportViewer1.LocalReport.SetParameters(frm106);
                        this.reportViewer1.LocalReport.SetParameters(frm107);
                        this.reportViewer1.LocalReport.SetParameters(frm108);
                        this.reportViewer1.LocalReport.SetParameters(frm109);
                    }
                    if (turnos2 > 2)
                    {
                        rt = 0;
                        rt = Consulta(turnos2, "Efectivo", Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm49 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm49);
                        rt = 0;
                        rt = Consulta2(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm50 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm50);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(2, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede2", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede2", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede2", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede2", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede2", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede2", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede2", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);
                    }
                    if (turnos == 2)
                    {
                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta(1, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt2 = Consulta(2, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm51 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG1", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm51);
                        result = 0;
                        rt = 0;
                        rt2 = 0;
                        rt = Consulta2(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt2 = Consulta2(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm52 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG1", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm52);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm101 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede1", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm102 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede1", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm103 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede1", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm104 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm105 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm106 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede1", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm107 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede1", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm108 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede1", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm109 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede1", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm101);
                        this.reportViewer1.LocalReport.SetParameters(frm102);
                        this.reportViewer1.LocalReport.SetParameters(frm103);
                        this.reportViewer1.LocalReport.SetParameters(frm104);
                        this.reportViewer1.LocalReport.SetParameters(frm105);
                        this.reportViewer1.LocalReport.SetParameters(frm106);
                        this.reportViewer1.LocalReport.SetParameters(frm107);
                        this.reportViewer1.LocalReport.SetParameters(frm108);
                        this.reportViewer1.LocalReport.SetParameters(frm109);
                    }

                    if (turnos2 == 2)
                    {
                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta(1, "Efectivo", Convert.ToDateTime(fechainicial2), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt2 = Consulta(2, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm53 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm53);
                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta2(1, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt2 = Consulta2(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm54 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG2", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(2, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede2", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede2", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede2", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede2", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede2", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede2", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede2", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);
                    }
                  


                    Microsoft.Reporting.WinForms.ReportParameter frm99 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBG", Convert.ToString(webg));
                    Microsoft.Reporting.WinForms.ReportParameter frm98 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBE", Convert.ToString(webe));
                    this.reportViewer1.LocalReport.SetParameters(frm99);
                    this.reportViewer1.LocalReport.SetParameters(frm98);
                    this.recargasPeajeTableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 1);
                    this.recargasPeaje1TableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje1, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 2);
                    Loading.Visible = false;
                    fechainicial = "";
                    fechafin = "";
                    fechafin2 = "";
                    fechainicial2 = "";
                    this.reportViewer1.RefreshReport();
                    //MessageBox.Show("Fecha 1:"+ fechainicial+" Turno 1:"+ Convert.ToString(turnos) + " Turno 2:"+Convert.ToString(turnos1), "Notificar");
                }
                else
                {
                    Loading.Visible = false;
                    MessageBox.Show("La fecha que esta intentando consultar no tiene registros, intente con otros parametros.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Fecha Sede 1: " + fechainicial + " Fecha Fin Sede 1:" + fechafin + " Fecha Sede 2:" + fechainicial2 + " Fecha Fin Sede 2:" + fechafin2, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fechainicial = "";
                    fechafin = "";
                    fechafin2 = "";
                    fechainicial2 = "";
                }
            }
            catch
            {
                fechainicial = "";
                fechafin = "";
                fechafin2 = "";
                fechainicial2 = "";
                Loading.Visible = false;
                MessageBox.Show("Error de conexion, por favor reintente mas tarde.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int turnos = 0;
                int turnos2 = 0;
                string Guacara;
                string LaEntrada;
                Loading.Visible = true;
                Accion.Text = "Inicializando el proceso...";
                fechainicial = "";
                fechafin = "";
                Accion.Text = "Conectando con ambas sedes...";
                turnos = 1;
                fechainicial = await Control(1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                Accion.Text = "Obteniendo informacion.";
                if (fechainicial == "")
                {
                    turnos = 2;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial = await Control(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }

                if (fechainicial == "")
                {
                    turnos = 3;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial = await Control(3, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 4;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control(4, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 5;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 6;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 7;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 8;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.AddDays(-1).ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 19:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechainicial == "")
                {
                    turnos = 9;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 10:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 09:59:59"), (string)Settings.Default["Sede1"]);
                }
                Accion.Text = "Obteniendo Turno...";
                if (fechafin == "" && turnos == 1)
                {
                    turnos++;
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 2)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 20:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 3)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 4)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control1(turnos, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 5)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 6)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 8)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.AddDays(-1).ToShortDateString() + " 20:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 19:59:59"), (string)Settings.Default["Sede1"]);
                }
                if (fechafin == "" && turnos == 9)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 10:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 09:59:59"), (string)Settings.Default["Sede1"]);
                }
                turnos2 = 1;
                fechainicial2 = await Control(1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                Accion.Text = "Obteniendo informacion.";
                if (fechainicial2 == "")
                {
                    turnos2 = 2;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial2 = await Control(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 3;
                    Accion.Text = "Obteniendo informacion..";
                    fechainicial2 = await Control(3, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 4;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control(4, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 5;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 6;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 8;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.AddDays(-1).ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 19:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechainicial2 == "")
                {
                    turnos2 = 9;
                    Accion.Text = "Obteniendo informacion...";
                    fechainicial2 = await Control4(Convert.ToDateTime(date1.Value.ToShortDateString() + " 10:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 09:59:59"), (string)Settings.Default["SAP2"]);
                }

                Accion.Text = "Obteniendo Turno...";
                if (fechafin2 == "" && turnos2 == 1)
                {
                    turnos2++;
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 2)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 20:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 3)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 16:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 4)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 5)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 13:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 04:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 6)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 13:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 04:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 7)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 19:59:59"), (string)Settings.Default["SAP2"]);
                }
                if (fechafin2 == "" && turnos2 == 8)
                {
                    Accion.Text = "Obteniendo Turno....";
                    fechafin2 = await Control3(Convert.ToDateTime(fecha2.Value.AddDays(-1).ToShortDateString() + " 20:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 09:59:59"), (string)Settings.Default["SAP2"]);
                }
                //if (fechafin2 == "" && turnos2 == 5)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                //if (fechafin2 == "" && turnos2 == 6)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                //if (fechafin2 == "" && turnos2 == 7)
                //{
                //    Accion.Text = "Obteniendo Turno....";
                //    fechafin2 = await Control1(turnos2, Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 14:59:59"), (string)Settings.Default["SAP2"]);
                //}
                Accion.Text = "Validando informacion...";
                if (fechainicial != "" && fechafin != "" && fechainicial2 != "" && fechafin2 != "")
                {
                    Accion.Text = "Obteniendo datos del servicio prepagado...";
                    webe = await ConsultaEspecia("Recarga WEB", 2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 06:30:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 06:30:00"));
                    webg = await ConsultaEspecia("Recarga WEB", 1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 06:30:00"), Convert.ToDateTime(fecha2.Value.ToShortDateString() + " 06:30:00"));
                    Accion.Text = "Obteniendo informacion faltante...";
                    Guacara = await Sede((string)Settings.Default["Sede1"]);
                    LaEntrada = await Sede((string)Settings.Default["SAP2"]);
                    Microsoft.Reporting.WinForms.ReportParameter frm10 = new Microsoft.Reporting.WinForms.ReportParameter("sede1", Guacara.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm10);
                    Microsoft.Reporting.WinForms.ReportParameter frm11 = new Microsoft.Reporting.WinForms.ReportParameter("sede2", LaEntrada.ToUpper());
                    this.reportViewer1.LocalReport.SetParameters(frm11);
                    Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", fechainicial);
                    Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fechafin);
                    this.reportViewer1.LocalReport.SetParameters(frm);
                    this.reportViewer1.LocalReport.SetParameters(frm1);
                    double rt = 0;
                    double rt2 = 0;
                    double result = 0;
                    if (turnos > 2 && turnos < 5)
                    {
                        rt = 0;
                        rt = Consulta(turnos, "Efectivo", Convert.ToDateTime(fechainicial).AddHours(-2), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm12 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG1", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm12);
                        rt = 0;
                        rt = Consulta2(turnos, Convert.ToDateTime(fechainicial).AddHours(-2), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm14 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG1", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm14);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm101 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede1", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm102 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede1", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm103 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede1", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm104 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm105 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm106 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede1", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm107 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede1", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm108 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede1", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm109 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede1", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm101);
                        this.reportViewer1.LocalReport.SetParameters(frm102);
                        this.reportViewer1.LocalReport.SetParameters(frm103);
                        this.reportViewer1.LocalReport.SetParameters(frm104);
                        this.reportViewer1.LocalReport.SetParameters(frm105);
                        this.reportViewer1.LocalReport.SetParameters(frm106);
                        this.reportViewer1.LocalReport.SetParameters(frm107);
                        this.reportViewer1.LocalReport.SetParameters(frm108);
                        this.reportViewer1.LocalReport.SetParameters(frm109);
                    }
                    if (turnos2 > 2 && turnos2 < 5)
                    {
                        rt = 0;
                        rt = Consulta(turnos2, "Efectivo", Convert.ToDateTime(fechainicial2).AddHours(-2), Convert.ToDateTime(fechafin2).AddHours(2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm49 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm49);
                        rt = 0;
                        rt = Consulta2(turnos2, Convert.ToDateTime(fechainicial2).AddHours(-2), Convert.ToDateTime(fechafin2).AddHours(2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm50 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm50);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(2, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede2", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede2", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede2", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede2", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede2", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede2", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede2", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);
                    }
                    if (turnos == 2)
                    {

                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta(1, "Efectivo", Convert.ToDateTime(fechainicial).AddHours(-2), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt2 = Consulta(2, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00").AddHours(-2), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm51 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG1", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm51);
                        result = 0;
                        rt = 0;
                        rt2 = 0;
                        rt = Consulta2(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59").AddHours(-2), (string)Settings.Default["Sede1"]);
                        rt2 = Consulta2(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00").AddHours(-2), Convert.ToDateTime(fechafin), (string)Settings.Default["Sede1"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm52 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG1", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm52);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin),(string)Settings.Default["Sede1"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm101 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede1", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm102 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede1", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm103 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede1", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm104 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm105 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm106 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede1", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm107 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede1", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm108 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede1", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm109 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede1", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm101);
                        this.reportViewer1.LocalReport.SetParameters(frm102);
                        this.reportViewer1.LocalReport.SetParameters(frm103);
                        this.reportViewer1.LocalReport.SetParameters(frm104);
                        this.reportViewer1.LocalReport.SetParameters(frm105);
                        this.reportViewer1.LocalReport.SetParameters(frm106);
                        this.reportViewer1.LocalReport.SetParameters(frm107);
                        this.reportViewer1.LocalReport.SetParameters(frm108);
                        this.reportViewer1.LocalReport.SetParameters(frm109);

                    }

                    if (turnos2 == 2)
                    {
                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta(1, "Efectivo", Convert.ToDateTime(fechainicial2), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt2 = Consulta(2, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm53 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm53);
                        rt = 0;
                        rt2 = 0;
                        result = 0;
                        rt = Consulta2(1, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt2 = Consulta2(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        result = rt + rt2;
                        Microsoft.Reporting.WinForms.ReportParameter frm54 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG2", Convert.ToString(result));
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(2, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede2", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede2", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede2", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede2", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede2", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede2", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede2", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);

                    }
                    if (turnos2 > 5)
                    {
                        rt = 0;
                        rt += Consulta(5, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt += Consulta(6, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt += Consulta(7, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm53 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm53);
                        rt = 0;
                        rt += Consulta2(5, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt += Consulta2(5, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["SAP2"]);
                        rt += Consulta2(7, Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm54 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos2, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["SAP2"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(2, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede2", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede2", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede2", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede2750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede2", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede2", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede2", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede2", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);

                    }
                    if (turnos > 5)
                    {
                        rt = 0;
                        rt += Consulta(5, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt += Consulta(6, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt += Consulta(7, "Efectivo", Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm53 = new Microsoft.Reporting.WinForms.ReportParameter("EfectivoG2", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm53);
                        rt = 0;
                        rt += Consulta2(5, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt += Consulta2(5, Convert.ToDateTime(fechainicial), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"), (string)Settings.Default["Sede1"]);
                        rt += Consulta2(7, Convert.ToDateTime(date1.Value.ToShortDateString() + " 16:00:00"), Convert.ToDateTime(fechafin2), (string)Settings.Default["Sede1"]);
                        Microsoft.Reporting.WinForms.ReportParameter frm54 = new Microsoft.Reporting.WinForms.ReportParameter("PDVG1", Convert.ToString(rt));
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        this.reportViewer1.LocalReport.SetParameters(frm54);
                        Boolean resultFlujo1 = ConsultarFlujo(turnos, Convert.ToDateTime(fechainicial2), Convert.ToDateTime(fechafin2), (string)Settings.Default["Sede1"]);
                        Boolean resultFlujoP = ConsultarFlujoPrepagado(1, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), (string)Settings.Default["Prepagado"]);
                        livianos = livianos + livianosP;
                        autobus = autobus + autobusP;
                        microbus = microbus + microbusP;
                        cargaliviana = cargaliviana + cargalivianaP;
                        ejes2 = ejes2 + ejes2P;
                        eje3 = eje3 + eje3P;
                        eje4 = eje4 + eje4P;
                        eje5 = eje5 + eje5P;
                        eje6 = eje6 + eje6P;
                        Microsoft.Reporting.WinForms.ReportParameter frm110 = new Microsoft.Reporting.WinForms.ReportParameter("LivianoSede1", livianos.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm111 = new Microsoft.Reporting.WinForms.ReportParameter("MicrobusSede1", microbus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm112 = new Microsoft.Reporting.WinForms.ReportParameter("AutobusSede1", autobus.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm113 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1350", cargaliviana.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm114 = new Microsoft.Reporting.WinForms.ReportParameter("Sede1750", ejes2.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm115 = new Microsoft.Reporting.WinForms.ReportParameter("Eje3Sede1", eje3.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm116 = new Microsoft.Reporting.WinForms.ReportParameter("Eje4Sede1", eje4.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm117 = new Microsoft.Reporting.WinForms.ReportParameter("Eje5Sede1", eje5.ToString());
                        Microsoft.Reporting.WinForms.ReportParameter frm118 = new Microsoft.Reporting.WinForms.ReportParameter("Eje6Sede1", eje6.ToString());
                        this.reportViewer1.LocalReport.SetParameters(frm110);
                        this.reportViewer1.LocalReport.SetParameters(frm111);
                        this.reportViewer1.LocalReport.SetParameters(frm112);
                        this.reportViewer1.LocalReport.SetParameters(frm113);
                        this.reportViewer1.LocalReport.SetParameters(frm114);
                        this.reportViewer1.LocalReport.SetParameters(frm115);
                        this.reportViewer1.LocalReport.SetParameters(frm116);
                        this.reportViewer1.LocalReport.SetParameters(frm117);
                        this.reportViewer1.LocalReport.SetParameters(frm118);

                    }
                    Microsoft.Reporting.WinForms.ReportParameter frm5 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBG", Convert.ToString(webg));
                    Microsoft.Reporting.WinForms.ReportParameter frm6 = new Microsoft.Reporting.WinForms.ReportParameter("RecargasWEBE", Convert.ToString(webe));
                    this.reportViewer1.LocalReport.SetParameters(frm5);
                    this.reportViewer1.LocalReport.SetParameters(frm6);
                    this.recargasPeajeTableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 1);
                    this.recargasPeaje1TableAdapter.Fill(this.prepagadoDataSet.RecargasPeaje1, Convert.ToDateTime(date1.Value.ToShortDateString()), Convert.ToDateTime(fecha2.Value.ToShortDateString()), 2);
                    Loading.Visible = false;
                    fechainicial = "";
                    fechafin = "";
                    fechafin2 = "";
                    fechainicial2 = "";
                    this.reportViewer1.RefreshReport();
                    //MessageBox.Show("Fecha 1:"+ fechainicial+" Turno 1:"+ Convert.ToString(turnos) + " Turno 2:"+Convert.ToString(turnos1), "Notificar");
                }
                else
                {
                    Loading.Visible = false;
                    MessageBox.Show("La fecha que esta intentando consultar no tiene registros, intente con otros parametros.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Fecha Sede 1: "+fechainicial+" Fecha Fin Sede 1:"+ fechafin+ " Fecha Sede 2:"+ fechainicial2+" Fecha Fin Sede 2:"+fechafin2, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fechainicial = "";
                    fechafin = "";
                    fechafin2 = "";
                    fechainicial2 = "";
                }
            }
            catch(Exception ex)
            {
                fechainicial = "";
                fechafin = "";
                fechafin2 = "";
                fechainicial2 = "";
                Loading.Visible = false;
                MessageBox.Show("Error de conexion, por favor reintente mas tarde. "+ex.ToString(), "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<string> Sede(string ruta)
        {
            string sql = "SELECT TOP 1 Nombre FROM Peaje ORDER BY ID_Peaje ASC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Nombre"].ToString() != "")
                    {
                        resultado = dr["Nombre"].ToString();
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                cn.Close();
                return resultado;
            }
        }
        // FECHA FIN
        private async Task<string> Control1(int turno, DateTime hora1, DateTime hora2,string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Pagos WHERE Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado="";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString()!="")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddHours(2));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        // FECHA DE INICIO
        private async Task<String> Control(int turno, DateTime hora1, DateTime hora2,string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = await cmd.ExecuteReaderAsync(); 
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString() != "")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        // FECHA FIN
        private async Task<string> Control3(DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Pagos WHERE Fecha BETWEEN @fecha AND @fecha1 Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString() != "")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddHours(2));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        // FECHA DE INICIO
        private async Task<String> Control4(DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Fecha BETWEEN @fecha AND @fecha1  Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string resultado = "";
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    if (dr["Fecha"].ToString() != "")
                    {
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]));
                    }
                    else
                    {
                        resultado = "";
                    }
                }
                dr.Close();
                cn.Close();
                return resultado;
            }
        }
        private double Consulta(int turno, string Forma,DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) AS Forma FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo = Pagos.ID_Vehiculo WHERE(Pagos.FormaPago = @pago) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1) AND(Pagos.Turno = @turno)";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                double rt39 = 0;
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                cmd.Parameters.AddWithValue("turno", turno);
                cmd.Parameters.AddWithValue("pago", Forma);
                dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Forma"].ToString() != "")
                    {
                        rt39 = Convert.ToDouble(dr["Forma"]);
                    }
                    else
                    {
                        rt39 = 0;
                    }
                }
                dr.Close();
                cn.Close();
                return rt39;
            }
        }
        private double Consulta2(int turno, DateTime hora1, DateTime hora2, string ruta)
        {
            string sql = "SELECT SUM(TipoVehiculos.Tarifa) AS Forma FROM TipoVehiculos INNER JOIN Pagos ON TipoVehiculos.ID_Vehiculo = Pagos.ID_Vehiculo WHERE (Pagos.FormaPago IN ('Punto de Venta', 'Transferencia')) AND (Pagos.Fecha BETWEEN @fecha AND @fecha1) AND (Pagos.Turno = @turno)";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                double rt40 = 0;
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", hora1);
                cmd.Parameters.AddWithValue("fecha1", hora2);
                cmd.Parameters.AddWithValue("turno", turno);
                dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Forma"].ToString() != "")
                    {
                        rt40 = Convert.ToDouble(dr["Forma"]);
                    }
                    else
                    {
                        rt40 = 0;
                    }
                }
                dr.Close();
                cn.Close();
                return rt40;
            }
        }
        private Boolean ConsultarFlujo(int turno, DateTime fecha1, DateTime fecha2, string ruta)
        {
            string sql = "SELECT SUM(CASE WHEN Nombre = 'Liviano' THEN 1 ELSE 0 END) AS Livianos, SUM(CASE WHEN Nombre = 'Microbus' THEN 1 ELSE 0 END) AS Microbus, SUM(CASE WHEN Nombre = 'Autobus' THEN 1 ELSE 0 END) AS Autobus, SUM(CASE WHEN Nombre = 'Carga Liviana' THEN 1 ELSE 0 END) AS CargaLiviana, SUM(CASE WHEN Nombre = '2 Ejes' THEN 1 ELSE 0 END) AS Ejes2, SUM(CASE WHEN Nombre = '3 Ejes' THEN 1 ELSE 0 END) AS Ejes3, SUM(CASE WHEN Nombre = '4 Ejes' THEN 1 ELSE 0 END) AS Ejes4, SUM(CASE WHEN Nombre = '5 Ejes' THEN 1 ELSE 0 END) AS Ejes5, SUM(CASE WHEN Nombre = '6 Ejes o Mas' THEN 1 ELSE 0 END) AS Ejes6 FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo WHERE(Pagos.Fecha BETWEEN @fecha AND @fecha1)";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fecha1);
                cmd.Parameters.AddWithValue("fecha1", fecha2);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    livianos = Convert.ToDouble(dr["Livianos"]);
                    microbus = Convert.ToDouble(dr["Microbus"]); ;
                    autobus = Convert.ToDouble(dr["Autobus"]); ;
                    cargaliviana = Convert.ToDouble(dr["CargaLiviana"]); ;
                    ejes2 = Convert.ToDouble(dr["Ejes2"]); ;
                    eje3 = Convert.ToDouble(dr["Ejes3"]); ;
                    eje4 = Convert.ToDouble(dr["Ejes4"]); ;
                    eje5 = Convert.ToDouble(dr["Ejes5"]); ;
                    eje6 = Convert.ToDouble(dr["Ejes6"]); ;
                }
                dr.Close();
                cn.Close();
                return true;
            }
        }
        private Boolean ConsultarFlujoPrepagado(int sede, DateTime fecha1, DateTime fecha2, string ruta)
        {
            string sql = "SELECT SUM(CASE WHEN Nombre = 'Liviano' THEN 1 ELSE 0 END) AS Livianos, SUM(CASE WHEN Nombre = 'Microbus' THEN 1 ELSE 0 END) AS Microbus, SUM(CASE WHEN Nombre = 'Autobus' THEN 1 ELSE 0 END) AS Autobus, SUM(CASE WHEN Nombre = 'Carga Liviana' THEN 1 ELSE 0 END) AS CargaLiviana, SUM(CASE WHEN Nombre = '2 Ejes' THEN 1 ELSE 0 END) AS Ejes2, SUM(CASE WHEN Nombre = '3 Ejes' THEN 1 ELSE 0 END) AS Ejes3, SUM(CASE WHEN Nombre = '4 Ejes' THEN 1 ELSE 0 END) AS Ejes4, SUM(CASE WHEN Nombre = '5 Ejes' THEN 1 ELSE 0 END) AS Ejes5, SUM(CASE WHEN Nombre = '6 Ejes o Mas' THEN 1 ELSE 0 END) AS Ejes6 FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo WHERE (Pagos.Fecha BETWEEN @fecha AND @fecha1) AND (Pagos.Sede = @Sede)";
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("fecha", fecha1);
                cmd.Parameters.AddWithValue("fecha1", fecha2);
                cmd.Parameters.AddWithValue("Sede", sede);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    livianosP = Convert.ToDouble(dr["Livianos"]);
                    microbusP = Convert.ToDouble(dr["Microbus"]); ;
                    autobusP = Convert.ToDouble(dr["Autobus"]); ;
                    cargalivianaP = Convert.ToDouble(dr["CargaLiviana"]); ;
                    ejes2P = Convert.ToDouble(dr["Ejes2"]); ;
                    eje3P = Convert.ToDouble(dr["Ejes3"]); ;
                    eje4P = Convert.ToDouble(dr["Ejes4"]); ;
                    eje5P = Convert.ToDouble(dr["Ejes5"]); ;
                    eje6P = Convert.ToDouble(dr["Ejes6"]); ;
                }
                dr.Close();
                cn.Close();
                return true;
            }
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
