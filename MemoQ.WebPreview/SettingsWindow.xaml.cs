using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MemoQ.WebPreview.Log.LogEntry;

namespace MemoQ.WebPreview
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private LogWindow logWindow = null;

        public SettingsWindow(LogWindow logWindow)
        {
            InitializeComponent();
            this.logWindow = logWindow;
            DataContext = new SettingsViewModel();

            foreach (SeverityOption severity in Enum.GetValues(typeof(SeverityOption)))
            {
                cbMinimalSeverityToShowOnLog.Items.Add(severity.ToString());
            }
        }

        private void linkShowLog_Click(object sender, RoutedEventArgs e)
        {
            logWindow.Show();
        }
        
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var settingsViewModel = DataContext as SettingsViewModel;
            Settings.Instance.AlwaysOnTop = settingsViewModel.AlwaysOnTop;
            Settings.Instance.NamedPipeAddress = settingsViewModel.NamedPipeAddress;
            SeverityOption severity = SeverityOption.Warning;
            if (Enum.TryParse(settingsViewModel.MinimalSeverityToShowInLog, out severity))
                Settings.Instance.MinimalSeverityToShowInLog = severity;
            Settings.Instance.SaveSettings();
            Close();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            // TODO dlengyel - help?
        }

        private void linkResetSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Instance.ResetSettings();
            var settingsViewModel = DataContext as SettingsViewModel;
            settingsViewModel.UpdateProperties();
        }
    }
}
