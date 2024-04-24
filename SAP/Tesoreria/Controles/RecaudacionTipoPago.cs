using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SAP.Tesoreria.Controles
{
    public partial class RecaudacionTipoPago : Form
    {
        String fecha = DateTime.Now.ToShortDateString();
        String fechas;
        String acumulador;
        Double acumulador1;
        Double acumulador2;
        Double RecargaPDVG;
        Double RecargaTransG;
        Double RecargaPDVE;
        Double RecargaTransE;
        Double Guacara;
        Double Entrada;
        string fechainicial = "";
        string fechafin = "";
        int turno = 0;
        public RecaudacionTipoPago()
        {
            InitializeComponent();
            fechas = Convert.ToString(this.LastDayOfMonthFromDateTime(DateTime.Now));
            date1.Value.ToShortDateString();
            date2.Value.ToShortDateString();
        }
        private void ConsultaEspecia(string forma, int sedes, DateTime fecha1, DateTime fecha2)
        {
            string sql = "SELECT Ventas.Monto AS Recaudado FROM Ventas INNER JOIN Sede ON Ventas.Sede = Sede.ID_Sede WHERE Ventas.FormaPago = @forma AND Ventas.Sede = @donde AND Ventas.Fecha BETWEEN @fecha1 AND @fecha2";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
            {
                acumulador = "";
                acumulador1 = 0;
                acumulador2 = 0;
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("forma", forma);
                cmd.Parameters.AddWithValue("donde", sedes);
                cmd.Parameters.AddWithValue("fecha1", Convert.ToDateTime(fecha1));
                cmd.Parameters.AddWithValue("fecha2", Convert.ToDateTime(fecha2));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    acumulador = dr["Recaudado"].ToString();
                    if (acumulador != "")
                    {
                        acumulador1 = Convert.ToDouble(acumulador);
                        acumulador2 = acumulador2 + acumulador1;
                    }

                }
                dr.Close();
                return;
            }
        }
        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        private void RecaudacionTipoPago_Load(object sender, EventArgs e)
        {
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Loading.Visible = true;
                Accion.Text = "Inicializando el proceso...";
                turno = 0;
                fechafin = "";
                fechainicial = "";
                Guacara = 0;
                if (filtro.SelectedItem != null )
                {
                    Accion.Text = "Obteniendo informacion del turno...";
                    if (filtro.SelectedItem.ToString().Trim() == "Diurno (12 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 1;
                        fechainicial = await Control(1, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
                        fechafin = await Control1(1, Convert.ToDateTime(date2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 16:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {
                           
                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Nocturno (12 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 2;
                        fechainicial = await Control(2, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
                        fechafin = await Control1(2, Convert.ToDateTime(date2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 16:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {
                           
                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Completo 1 (24 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 3;
                        fechainicial = await Control(3, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
                        fechafin = await Control1(3, Convert.ToDateTime(date2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 16:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {
                            cargar();

                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Completo 2 (24 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 4;
                        fechainicial = await Control(4, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
                        fechafin = await Control1(4, Convert.ToDateTime(date2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 16:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {
         
                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Turno 1 (8 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 5;
                        fechainicial = await Control(5, Convert.ToDateTime(date1.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 18:00:00"));
                        fechafin = await Control1(5, Convert.ToDateTime(date2.Value.ToShortDateString() + " 20:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 18:00:00"));
                        if (fechainicial != "" && fechafin != "")
                        {

                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Turno 2 (8 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 6;
                        fechainicial = await Control(6, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
                        fechafin = await Control1(6, Convert.ToDateTime(date2.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {

                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Turno 3 (8 Horas)")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 7;
                        fechainicial = await Control(7, Convert.ToDateTime(date1.Value.ToShortDateString() + " 12:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 06:59:59"));
                        fechafin = await Control1(7, Convert.ToDateTime(date2.Value.ToShortDateString() + " 12:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 06:59:59"));
                        if (fechainicial != "" && fechafin != "")
                        {

                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Turno 12h 00:00 - 12:00")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 8;
                        fechainicial = await Control(8, Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:00:00"));
                        fechafin = await Control1(8, Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 23:00:00"));
                        if (fechainicial != "" && fechafin != "")
                        {

                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (filtro.SelectedItem.ToString().Trim() == "Turno 12h 12:00 - 23:59")
                    {
                        Accion.Text = "Cargando reporte...";
                        turno = 9;
                        fechainicial = await Control(9, Convert.ToDateTime(date1.Value.ToShortDateString() + " 09:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 09:00:00"));
                        fechafin = await Control1(9, Convert.ToDateTime(date2.Value.ToShortDateString() + " 09:00:00"), Convert.ToDateTime(date2.Value.ToShortDateString() + " 09:00:00"));
                        if (fechainicial != "" && fechafin != "")
                        {

                            cargar();
                        }
                        else
                        {
                            Loading.Visible = false;
                            MessageBox.Show("Turno Seleccionado no contiene informacion.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (filtro.SelectedItem == null)
                    {
                        Loading.Visible = false;
                        MessageBox.Show("Debe seleccionar un turno a filtrar.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Loading.Visible = false;
                        MessageBox.Show("Debe introducir los parametros de fecha correctamente.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                Loading.Visible = false;
                MessageBox.Show("Error al cargar el reporte", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FECHA FIN
        private async Task<string> Control1(int turno, DateTime hora1, DateTime hora2)
        {
            string sql = "SELECT TOP 1 Fecha FROM CierreBalanceV2 WHERE Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha DESC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
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
                        resultado = Convert.ToString(Convert.ToDateTime(dr["Fecha"]).AddMinutes(1));
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
        // FECHA DE INICIO
        private async Task<String> Control(int turno, DateTime hora1, DateTime hora2)
        {
            string sql = "SELECT TOP 1 Fecha FROM Turno WHERE Fecha BETWEEN @fecha AND @fecha1 AND Turno=@turno Order by Fecha ASC;";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
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
                        resultado = dr["Fecha"].ToString();
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
        private void cargar()
        {
            RecargaPDVG = 0;
            RecargaTransG = 0;
            Guacara = 0;
            acumulador = "";
            acumulador1 = 0;
            acumulador2 = 0;
            ConsultaEspecia("Recarga PDV", SAP.Inicio.sede, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
            RecargaPDVG = acumulador2;
            ConsultaEspecia("Recarga Transf", SAP.Inicio.sede, Convert.ToDateTime(date1.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " 23:59:59"));
            RecargaTransG = acumulador2;
            Guacara = RecargaPDVG + RecargaTransG;
            Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicial", fechainicial);
            Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", fechafin);
            this.reportViewer1.LocalReport.SetParameters(frm);
            this.reportViewer1.LocalReport.SetParameters(frm1);
            Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Recargas", Convert.ToString(Guacara));
            this.reportViewer1.LocalReport.SetParameters(frm2);
            Microsoft.Reporting.WinForms.ReportParameter frm3 = new Microsoft.Reporting.WinForms.ReportParameter("Sede", SAP.Tesoreria.Reportes.Peaje);
            this.reportViewer1.LocalReport.SetParameters(frm3);
            this.pagoIncompletoTableAdapter.Fill(this.sAPDataSet2.PagoIncompleto, "Pago Incompleto", Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), turno);
            this.efectivoTableAdapter.Fill(this.sAPDataSet2.Efectivo, "Efectivo", Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), turno);
            this.pDVTableAdapter.Fill(this.sAPDataSet2.PDV, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), turno);
            this.tesoreriaTableAdapter.Fill(this.sAPDataSet2.Tesoreria, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin));
            this.reporteTableAdapter.Fill(this.sAPDataSet2.reporte, Convert.ToDateTime(fechainicial), Convert.ToDateTime(fechafin), turno);
            this.reportViewer1.RefreshReport();
            Loading.Visible = false;
        }
    }
}
