using SAP.Common.Enums;
using SAP.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
    public class LibreriaComun
    {
        public void ErroLog(string ex)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            string path = CurrentDirectory + @"\LogError.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " - " + ex);
                }
            }
            else
            {
                string[] line = File.ReadAllLines(path);
                File.AppendAllText(path, DateTime.Now.ToString() + " - " + ex);
            }
        }

        public async Task<TypeUser> ValidatePermission(string password, string interfaceType)
        {
            try
            {
                if (interfaceType == "administrador")
                {
                    if (password == (string)Settings.Default["Master"])
                    {
                        return TypeUser.Administrador;
                    }
                    else if (await Auditoria(password))
                    {
                        return TypeUser.Auditor;
                    }
                    else
                    {
                        return TypeUser.Invalido;
                    }
                }
                else if (interfaceType == "recaudador")
                {
                    if (password == (string)Settings.Default["Master"])
                    {
                        return TypeUser.Administrador;
                    }
                    else if (await Supervisores(password))
                    {
                        return TypeUser.Supervisor;
                    }
                    else if (await CanalesSecurity(password))
                    {
                        return TypeUser.AuditorCanal;
                    }
                    else
                    {
                        return TypeUser.Invalido;
                    }
                }
                else if (interfaceType == "cobrador")
                {
                    if (password == (string)Settings.Default["Master"])
                    {
                        return TypeUser.Administrador;
                    }
                    else if (await Operacional(password))
                    {
                        return TypeUser.Operacional;
                    }
                    else
                    {
                        return TypeUser.Invalido;
                    }
                }
            }
            catch(Exception ex)
            {
                ErroLog(ex.Message);
            }

            return TypeUser.Invalido;
        }

        private async Task<bool> Auditoria(string password)
        {
            string sql = "SELECT * FROM  Auditoria WHERE Contrasena=@clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                var query = await cmd.ExecuteScalarAsync();
                int val = Convert.ToInt32(query);
                return !(val == 0);
            }
        }
        private async Task<bool> Operacional(string password)
        {
            string sql = "SELECT * FROM  Operaciones WHERE Password=@clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                var query = await cmd.ExecuteScalarAsync();
                int val = Convert.ToInt32(query);
                return !(val == 0);
            }
        }
        private async Task<bool> CanalesSecurity(string password)
        {
            string sql = "SELECT Id, Password FROM CanalesSecurity where Password = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                var query = await cmd.ExecuteScalarAsync();
                int val = Convert.ToInt32(query);
                return !(val == 0);
            }
        }
        private async Task<bool> Supervisores(string password)
        {
            string sql = "SELECT * FROM Supervisor WHERE Autorizado = @clave";
            using (SqlConnection cn = new SqlConnection(Inicio.conexion))
            {
                await cn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("clave", password);
                var query = await cmd.ExecuteScalarAsync();
                int val = Convert.ToInt32(query);
                return !(val == 0);
            }
        }
    }
}
