using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace AdivinaElNumero
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Manejar excepciones no controladas a nivel de aplicación
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            MainPage = new NavigationPage(new NivelDificultad());
        }

        private void CurrentDomain_UnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            // Registrar detalles de la excepción
            var exception = e.ExceptionObject as Exception;
            LogException(exception);
        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            // Registrar detalles de la excepción
            var exception = e.Exception;
            LogException(exception);
        }

        private void LogException(Exception? exception)
        {
            if (exception != null)
            {
                var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "error.log");
                File.AppendAllText(logPath, $"{DateTime.UtcNow}: {exception.ToString()}{Environment.NewLine}");
            }
        }
    }
}