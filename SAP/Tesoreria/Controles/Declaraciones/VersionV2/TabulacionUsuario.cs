using SAP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Tesoreria.Controles.Declaraciones.VersionV2
{
    public partial class TabulacionUsuario : Form
    {
        String fecha = SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial;
        String fecha2 = SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal;
        String id = SAP.Tesoreria.Controles.ListaDeclaraciones.ID_Usuario1;
        public TabulacionUsuario()
        {
            InitializeComponent();
        }

        private async void TabulacionUsuario_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("recaudador", SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario);
            this.reportViewer1.LocalReport.SetParameters(frm);
            Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial);
            this.reportViewer1.LocalReport.SetParameters(frm1);
            Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha1", SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
            this.reportViewer1.LocalReport.SetParameters(frm2);
            this.tabulacionVehiculoTableAdapter.Fill(this.sAPDataSet2.TabulacionVehiculo, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
            this.tabulacionFormaTableAdapter.Fill(this.sAPDataSet2.TabulacionForma, Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
            var desgloseSAP = await TabulacionTipoPagoSAP(Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
            var desglosePrepagado = await TabulacionTipoPago(Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
            foreach (var item in desglosePrepagado)
            {
                desgloseSAP.Add(item);
            }
            this.tabulacionUsuarioPrepagadoBindingSource.DataSource = desgloseSAP.OrderBy(x => x.Fecha);
            var tipoPrepagado = await TabulacionTipoVehiculoPrepagado(Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), SAP.Inicio.sede);
            this.tabulacionTipoPrepagadoBindingSource.DataSource = tipoPrepagado;
            var tabulacionGeneralS = await TabulacionGeneralSAP(Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
            var tabulacionGeneralP = await TabulacionGeneralPrepagado(Convert.ToInt32(id), Convert.ToDateTime(fecha), Convert.ToDateTime(fecha2));
            foreach (var item in tabulacionGeneralS)
            {
                var find = tabulacionGeneralP.FirstOrDefault(x => x.Nombre == item.Nombre);
                if (find != null)
                {
                    item.Cantidad = item.Cantidad + find.Cantidad;
                    var totals = find.Cantidad * find.Tarifa;
                    item.Tarifa = item.Tarifa + totals;
                }
            }
            this.tabulacionGeneralUsuarioBindingSource.DataSource = tabulacionGeneralS;
            this.reportViewer1.RefreshReport();
        }

        //private async void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (hora1.Text != "" && hora2.Text != "" && min1.Text != "" && min2.Text != "")
        //        {
        //            Microsoft.Reporting.WinForms.ReportParameter frm = new Microsoft.Reporting.WinForms.ReportParameter("recaudador", SAP.Tesoreria.Controles.ListaDeclaraciones.nombreusuario);
        //            this.reportViewer1.LocalReport.SetParameters(frm);
        //            Microsoft.Reporting.WinForms.ReportParameter frm1 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", SAP.Tesoreria.Controles.ListaDeclaraciones.fechainicial);
        //            this.reportViewer1.LocalReport.SetParameters(frm1);
        //            Microsoft.Reporting.WinForms.ReportParameter frm2 = new Microsoft.Reporting.WinForms.ReportParameter("Fecha1", SAP.Tesoreria.Controles.ListaDeclaraciones.fechafinal);
        //            this.reportViewer1.LocalReport.SetParameters(frm2);
        //            this.tabulacionVehiculoTableAdapter.Fill(this.sAPDataSet2.TabulacionVehiculo, Convert.ToInt32(id), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
        //            this.tabulacionFormaTableAdapter.Fill(this.sAPDataSet2.TabulacionForma, Convert.ToInt32(id), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
        //            var desgloseSAP = await TabulacionTipoPagoSAP(Convert.ToInt32(id), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), Convert.ToInt32(SAP.Tesoreria.Controles.ListaDeclaraciones.turno));
        //            var desglosePrepagado = await TabulacionTipoPago(Convert.ToInt32(id), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), SAP.Inicio.sede);
        //            foreach (var item in desglosePrepagado)
        //            {
        //                desgloseSAP.Add(item);
        //            }
        //            this.tabulacionUsuarioPrepagadoBindingSource.DataSource = desgloseSAP.OrderBy(x => x.Fecha);
        //            var tipoPrepagado = await TabulacionTipoVehiculoPrepagado(Convert.ToInt32(id), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora1.Text + ":" + min1.Text + ":00"), Convert.ToDateTime(date1.Value.ToShortDateString() + " " + hora2.Text + ":" + min2.Text + ":59"), SAP.Inicio.sede);
        //            this.tabulacionTipoPrepagadoBindingSource.DataSource = tipoPrepagado;
        //            this.reportViewer1.RefreshReport();
        //        }
        //        else
        //        {
        //            MessageBox.Show("debe seleccionar todos los campos hora inicial y fin para poder realizar la consulta", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("error de consulta intente con otras fechas.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
            
          
        //}
        private async Task<List<TabulacionUsuarioPrepagado>> TabulacionTipoPagoSAP(int usuario, DateTime fecha, DateTime fecha1, int turno)
        {
            var listado = new List<TabulacionUsuarioPrepagado>();
            string sql = "SELECT TipoVehiculos.Nombre, Pagos.Canal, Pagos.Fecha, Pagos.Turno, Pagos.FormaPago, Pagos.ID FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo" +
                    " WHERE(Pagos.ID_Usuario = @usuario) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1) AND(Pagos.Turno = @turno)" +
                    " ORDER BY Pagos.Fecha Desc";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.Parameters.AddWithValue("fecha1", fecha1);
                cmd.Parameters.AddWithValue("turno", turno);
                dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    var item = new TabulacionUsuarioPrepagado();
                    item.ID = Convert.ToInt32(dr["ID"]);
                    item.Vehiculo = dr["Nombre"].ToString();
                    item.Canal = Convert.ToInt32(dr["Canal"]);
                    item.FormaPago = dr["FormaPago"].ToString();
                    item.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm:ss");
                    item.Turno = Convert.ToInt32(dr["Turno"]);
                    listado.Add(item);
                }
                dr.Close();
                cn.Close();
                return listado;
            }
        }
        private async Task<List<TabulacionUsuarioPrepagado>> TabulacionTipoPago(int usuario, DateTime fecha, DateTime fecha1, int turno)
        {
            try
            {
                var listado = new List<TabulacionUsuarioPrepagado>();
                string sql = "SELECT TipoVehiculos.Nombre, Pagos.Canal, Pagos.Fecha,Pagos.FormaPago, Pagos.ID FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo" +
                        " WHERE(Pagos.ID_Usuario = @usuario) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1) AND (Pagos.Sede = @sede)" +
                        " ORDER BY Pagos.Fecha Desc";
                using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
                {
                    await cn.OpenAsync();
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("usuario", usuario);
                    cmd.Parameters.AddWithValue("fecha", fecha);
                    cmd.Parameters.AddWithValue("fecha1", fecha1);
                    cmd.Parameters.AddWithValue("sede", SAP.Inicio.sede);
                    dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var item = new TabulacionUsuarioPrepagado();
                        item.ID = Convert.ToInt32(dr["ID"]);
                        item.Vehiculo = dr["Nombre"].ToString();
                        item.Canal = Convert.ToInt32(dr["Canal"]);
                        item.FormaPago = dr["FormaPago"].ToString();
                        item.Turno = turno;
                        item.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm:ss");
                        listado.Add(item);
                    }
                    dr.Close();
                    cn.Close();
                    return listado;
                }
            }
            catch
            {
                var listado = new List<TabulacionUsuarioPrepagado>();
                return listado;
            }
        }
        private async Task<List<TabulacionTipoPrepagado>> TabulacionTipoVehiculoPrepagado(int usuario, DateTime fecha, DateTime fecha1, int turno)
        {
            try
            {
                var listado = new List<TabulacionTipoPrepagado>();
                string sql = "SELECT TipoVehiculos.Nombre, COUNT(Pagos.ID_Vehiculo) AS Cantidad, Pagos.FormaPago" +
                             " FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo"+
                             " WHERE(Pagos.ID_Usuario = @usuario) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1) AND(Pagos.Sede = @sede)"+
                             " GROUP BY TipoVehiculos.Nombre, Pagos.FormaPago";
                using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
                {
                    await cn.OpenAsync();
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("usuario", usuario);
                    cmd.Parameters.AddWithValue("fecha", fecha);
                    cmd.Parameters.AddWithValue("fecha1", fecha1);
                    cmd.Parameters.AddWithValue("sede", SAP.Inicio.sede);
                    dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var item = new TabulacionTipoPrepagado();
                        item.Nombre = dr["Nombre"].ToString();
                        item.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        item.FormaPago = dr["FormaPago"].ToString();
                        listado.Add(item);
                    }
                    dr.Close();
                    cn.Close();
                    return listado;
                }
            }
            catch
            {
                var listado = new List<TabulacionTipoPrepagado>();
                return listado;
            }
        }

        private async Task<List<TabulacionGeneralUsuario>> TabulacionGeneralPrepagado(int usuario, DateTime fecha, DateTime fecha1)
        {
            try
            {
                var listado = new List<TabulacionGeneralUsuario>();
                string sql = "SELECT TipoVehiculos.Nombre, COUNT(Pagos.ID_Vehiculo) AS Cantidad, TipoVehiculos.Tarifa" +
                             " FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo" +
                             " WHERE(Pagos.ID_Usuario = @usuario) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1)  AND (Pagos.Sede = @sede)" +
                             " GROUP BY TipoVehiculos.Nombre, TipoVehiculos.Tarifa";
                using (SqlConnection cn = new SqlConnection(Inicio.conexion2))
                {
                    await cn.OpenAsync();
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("usuario", usuario);
                    cmd.Parameters.AddWithValue("fecha", fecha);
                    cmd.Parameters.AddWithValue("fecha1", fecha1);
                    cmd.Parameters.AddWithValue("sede", SAP.Inicio.sede);
                    dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var item = new TabulacionGeneralUsuario();
                        item.Nombre = dr["Nombre"].ToString();
                        item.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        item.Tarifa = Convert.ToDecimal(dr["Tarifa"]);
                        item.Total = item.Cantidad * item.Total;
                        listado.Add(item);
                    }
                    dr.Close();
                    cn.Close();
                    return listado;
                }
            }
            catch
            {
                var listado = new List<TabulacionGeneralUsuario>();
                return listado;
            }
        }
        private async Task<List<TabulacionGeneralUsuario>> TabulacionGeneralSAP(int usuario, DateTime fecha, DateTime fecha1, int turno)
        {
            try
            {
                var listado = new List<TabulacionGeneralUsuario>();
                string sql = "SELECT TipoVehiculos.Nombre, COUNT(Pagos.ID_Vehiculo) AS Cantidad, TipoVehiculos.Tarifa" +
                             " FROM Pagos INNER JOIN TipoVehiculos ON Pagos.ID_Vehiculo = TipoVehiculos.ID_Vehiculo" +
                             " WHERE(Pagos.ID_Usuario = @usuario) AND(Pagos.Fecha BETWEEN @fecha AND @fecha1)  AND (Pagos.Turno = @turno)" +
                             " GROUP BY TipoVehiculos.Nombre, TipoVehiculos.Tarifa";
                using (SqlConnection cn = new SqlConnection(Inicio.conexion))
                {
                    await cn.OpenAsync();
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("usuario", usuario);
                    cmd.Parameters.AddWithValue("fecha", fecha);
                    cmd.Parameters.AddWithValue("fecha1", fecha1);
                    cmd.Parameters.AddWithValue("turno", turno);
                    dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var item = new TabulacionGeneralUsuario();
                        item.Nombre = dr["Nombre"].ToString();
                        item.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        item.Tarifa = Convert.ToDecimal(dr["Tarifa"]);
                        item.Total = item.Cantidad * item.Total;
                        listado.Add(item);
                    }
                    dr.Close();
                    cn.Close();
                    return listado;
                }
            }
            catch
            {
                var listado = new List<TabulacionGeneralUsuario>();
                return listado;
            }
        }
    }
}
