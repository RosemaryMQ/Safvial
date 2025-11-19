using SqlServerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading; // Necesario para ThreadExceptionEventHandler
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. MANEJADOR PARA EXCEPCIONES EN EL HILO PRINCIPAL DE LA UI
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // 2. MANEJADOR CRÍTICO PARA EXCEPCIONES EN CUALQUIER OTRO HILO (Timers, Tasks, etc.)
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            Application.Run(new Inicio());
        }

        // --- MANEJADORES DE EXCEPCIONES ---

        // Maneja las excepciones que ocurren en el Hilo de la Interfaz de Usuario (UI).
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Registrar y/o notificar. Este error generalmente no termina el proceso.
            LogException(e.Exception, "Error en Hilo de UI (ThreadException)");
            MessageBox.Show($"Ocurrió un error en la UI: {e.Exception.Message}. Verifique LogErrores.txt.", "Error de UI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Maneja las excepciones que ocurren en hilos de fondo (Thread Pool), 
        // como los generados por System.Timers.Timer. ESTE ES EL CRÍTICO.
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string tipoError = e.IsTerminating ? "Excepción NO CONTROLADA (FATAL)" : "Excepción NO CONTROLADA";

            // Registrar y/o notificar.
            //LogException(ex, tipoError);
            LogException(ex, tipoError);

            string mensaje = $"Ocurrió un error CRÍTICO: {ex.Message}. Verifique LogErrores.txt.";

            if (e.IsTerminating)
            {
                mensaje += "\n\nLa aplicación se cerrará forzosamente para prevenir corrupción de datos.";
            }

            // Nota: Se usa MessageBox.Show aquí, pero es mejor que el manejo sea rápido, 
            // ya que el estado del hilo podría ser inestable.
            MessageBox.Show(mensaje, tipoError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // --- FUNCIÓN DE REGISTRO ---

        private static void LogException(Exception ex, string titulo)
        {
            try
            {
                // **CAMBIO AQUÍ: Establecer la ruta del directorio log a C:\log**
                string logDirectory = @"C:\log";

                // **Las siguientes líneas ya no son necesarias, ya que se está usando una ruta fija.**
                // string logDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                // logDirectory = System.IO.Path.Combine(logDirectory, "SAP_Logs"); // Usa un nombre específico

                // Crear el directorio si no existe
                if (!System.IO.Directory.Exists(logDirectory))
                {
                    System.IO.Directory.CreateDirectory(logDirectory);
                }

                string logPath = System.IO.Path.Combine(logDirectory, "LogErrores.txt");

                string logMessage = $"--- {titulo} - {DateTime.Now} ---\n" +
                                     // ... el resto de tu mensaje de error
                                     $"Mensaje: {ex.Message}\n" +
                                     $"Fuente: {ex.Source}\n" +
                                     $"Stack Trace:\n{ex.StackTrace}\n" +
                                     $"------------------------------------------------\n\n";

                System.IO.File.AppendAllText(logPath, logMessage);
            }
            catch { /* No hacer nada si falla el registro */ }
        }


    }
}