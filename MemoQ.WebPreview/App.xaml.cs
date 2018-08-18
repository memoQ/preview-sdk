using MemoQ.WebPreview.CefSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static MemoQ.WebPreview.Log.LogEntry;

namespace MemoQ.WebPreview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            CefHelper.LoadCefDllsAndInit();
            MainWindow = new MainWindow();
            MainWindow.Show();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            Log.Instance.WriteMessage($"Unexpected error occurred: {ex}", SeverityOption.Error);
        }
    }
}
