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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoQ.WebPreview
{
    /// <summary>
    /// Interaction logic for ConnectControl.xaml
    /// </summary>
    public partial class ConnectControl : UserControl
    {
        private LogWindow logWindow;

        public ConnectControl()
        {
            InitializeComponent();
        }

        public void SetLogWindow(LogWindow logWindow)
        {
            this.logWindow = logWindow;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow(logWindow);
            settingsWindow.Topmost = logWindow.Topmost;
            settingsWindow.ShowDialog();
        }
    }
}
