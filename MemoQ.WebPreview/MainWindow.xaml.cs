using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CefSharp.WinForms;
using static MemoQ.WebPreview.Log.LogEntry;
using CefSharp;

namespace MemoQ.WebPreview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogWindow logWindow = new LogWindow();

        private readonly ChromiumWebBrowser webBrowser;

        private IFrame frame;

        /// <summary>
        /// The view model
        /// </summary>
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            mainViewModel = new MainViewModel(loadPageInBrowser, executeJavaScriptCodeInBrowser, handleDisconnect);
            DataContext = mainViewModel;

            InitializeComponent();

            Top = Settings.Instance.WindowTop;
            Left = Settings.Instance.WindowLeft;
            Width = Settings.Instance.WindowWidth;
            Height = Settings.Instance.WindowHeight;
            if (Settings.Instance.WindowMaximized)
                WindowState = WindowState.Maximized;
            Topmost = Settings.Instance.AlwaysOnTop;
            logWindow.Topmost = Settings.Instance.AlwaysOnTop;
            BorderBrush = SystemParameters.WindowGlassBrush;
            
            connectControl.SetLogWindow(logWindow);
            Log.Instance.MessageAdded += Log_MessageAdded;

            webBrowser = new ChromiumWebBrowser(string.Empty);

            // RegisterJsObject should be called directly after you create an instance of ChromiumWebBrowser
            webBrowser.RegisterJsObject("mqCallback", mainViewModel.WebPreviewCallbackHandler);
            webBrowser.FrameLoadEnd += webBrowser_FrameLoadEnd;
#if !DEBUG
            webBrowser.IsBrowserInitializedChanged += webBrowser_IsBrowserInitializedChanged;
#endif

            ehBrowser.Child = webBrowser;
        }

        #region Window events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Instance.AutoConnect)
                mainViewModel.Connect();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Instance.WindowTop = Top;
            Settings.Instance.WindowLeft = Left;
            Settings.Instance.WindowWidth = Width;
            Settings.Instance.WindowHeight = Height;
            Settings.Instance.WindowMaximized = WindowState == WindowState.Maximized;
            Settings.Instance.SaveSettings();
            
            logWindow.Close();
            mainViewModel.Disconnect();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var heightToCalculateWith = Math.Min(Math.Max(400, Height), 600);
            var margin = (heightToCalculateWith - 400) * 0.5;
            connectControl.Margin = new Thickness(0, margin, 0, 0);
        }

        private void Log_MessageAdded(object sender, Log.MessageAddedEventArgs e)
        {
            if (e.LogEntry.Severity <= Settings.Instance.MinimalSeverityToShowInLog)
                this.InvokeIfRequired(_ => logWindow.Show());
        }

        #endregion Window events

        #region Web browser events

        private void webBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            // JS code can be executed from now on
            var webBrowser = sender as ChromiumWebBrowser;
            if (webBrowser != null)
            {
                webBrowser.IsBrowserInitializedChanged -= webBrowser_IsBrowserInitializedChanged;
                frame = webBrowser.GetMainFrame();

                // ask the preview tool to send its config
                var configRequestMessage = new PreviewConfigRequestMessage().SerializeToPostMessage();
                frame.ExecuteJavaScriptAsync(configRequestMessage);
            }
            else
                frame = null;
        }

        private void webBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (e.IsBrowserInitialized)
            {
                var webBrowser = sender as ChromiumWebBrowser;
                if (webBrowser != null)
                {
                    webBrowser.IsBrowserInitializedChanged -= webBrowser_IsBrowserInitializedChanged;
#if DEBUG
                    webBrowser.ShowDevTools();
#endif
                }
            }
        }

        #endregion

        #region Control events

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow(logWindow);
            settingsWindow.Topmost = Topmost;
            settingsWindow.ShowDialog();
            Topmost = Settings.Instance.AlwaysOnTop;
            logWindow.Topmost = Topmost;
        }

        #endregion Control events

        #region Private methods

        private void loadPageInBrowser(string url)
        {
            this.InvokeIfRequired(_ => webBrowser.Load(url));
        }

        private void executeJavaScriptCodeInBrowser(string code)
        {
            if (frame != null)
                frame.ExecuteJavaScriptAsync(code);
        }

        private void handleDisconnect()
        {
            this.InvokeIfRequired(_ =>
            {
                mainViewModel.ConnectViewModel.IsConnected = false;
                mainViewModel.NoContent = true;
                mainViewModel.WaitingForRegistration = false;
            });
        }

        #endregion Private methods
    }
}
