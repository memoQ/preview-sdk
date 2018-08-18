using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using static MemoQ.WebPreview.Log.LogEntry;
using static MemoQ.WebPreview.MainViewModel;

namespace MemoQ.WebPreview
{
    public class Settings
    {
        #region Singleton
        private static readonly Lazy<Settings> lazyInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Instance { get { return lazyInstance.Value; } }

        private Settings()
        {
            ResetSettings();
        }
        #endregion Singleton

        private const string Tag_Root = "MemoQWebPreviewSettings";
        private const string Tag_NamedPipeAddress = "NamedPipeAddress";
        private const string Tag_AutoConnect = "AutoConnect";
        private const string Tag_MinimalSeverityToShowInLog = "MinimalSeverityToShowInLog";
        private const string Tag_Window = "Window";
        private const string Tag_Top = "Top";
        private const string Tag_Left = "Left";
        private const string Tag_Width = "Width";
        private const string Tag_Height = "Height";
        private const string Tag_Maximized = "Maximized";
        private const string Tag_AlwaysOnTop = "AlwaysOnTop";

        private readonly string SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, "settings.xml");

        public string NamedPipeAddress { get; set; }
        public bool AutoConnect { get; set; }
        public SeverityOption MinimalSeverityToShowInLog { get; set; }
        public double WindowTop { get; set; }
        public double WindowLeft { get; set; }
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
        public bool WindowMaximized { get; set; }
        public bool AlwaysOnTop { get; set; }
        
        
        public void ResetSettings()
        {
            NamedPipeAddress = "MQ_PREVIEW_PIPE";
            AutoConnect = true;
            MinimalSeverityToShowInLog = SeverityOption.Warning;
            WindowTop = 0;
            WindowLeft = 0;
            WindowWidth = 654;
            WindowHeight = 520;
            WindowMaximized = false;
            AlwaysOnTop = false;
        }

        public void LoadSettings()
        {
            try
            {
                var xDocument = XDocument.Load(SettingsPath);
                var root = xDocument.Element(Tag_Root);
                NamedPipeAddress = root.Element(Tag_NamedPipeAddress).Value;
                AutoConnect = bool.Parse(root.Element(Tag_AutoConnect).Value);
                MinimalSeverityToShowInLog = (SeverityOption)Enum.Parse(typeof(SeverityOption), root.Element(Tag_MinimalSeverityToShowInLog).Value);

                var xWindows = root.Element(Tag_Window);
                WindowTop = double.Parse(xWindows.Element(Tag_Top).Value);
                WindowLeft = double.Parse(xWindows.Element(Tag_Left).Value);
                WindowWidth = double.Parse(xWindows.Element(Tag_Width).Value);
                WindowHeight = double.Parse(xWindows.Element(Tag_Height).Value);
                WindowMaximized = bool.Parse(xWindows.Element(Tag_Maximized).Value);
                AlwaysOnTop = bool.Parse(xWindows.Element(Tag_AlwaysOnTop).Value);
            }
            catch (IOException)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath));
                SaveSettings();
            }
            catch
            {
                if (DialogResult.OK == MessageBox.Show($"The settings file is corrupt.{Environment.NewLine}{Environment.NewLine}Press \"OK\" to reset the settings file or \"Cancel\" to exit", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error))
                {
                    ResetSettings();
                }
                else
                {
                    Environment.Exit(ExitCodes.SettingsFileCorrupt);
                }
            }
        }

        public void SaveSettings()
        {
            new XDocument(
                new XElement(Tag_Root,
                    new XElement(Tag_NamedPipeAddress, NamedPipeAddress),
                    new XElement(Tag_AutoConnect, AutoConnect.ToString()),
                    new XElement(Tag_MinimalSeverityToShowInLog, MinimalSeverityToShowInLog.ToString()),
                    new XElement(Tag_Window,
                        new XElement(Tag_Top, WindowTop.ToString()),
                        new XElement(Tag_Left, WindowLeft.ToString()),
                        new XElement(Tag_Width, WindowWidth.ToString()),
                        new XElement(Tag_Height, WindowHeight.ToString()),
                        new XElement(Tag_Maximized, WindowMaximized.ToString()),
                        new XElement(Tag_AlwaysOnTop, AlwaysOnTop.ToString())))
            ).Save(SettingsPath);
        }
    }
}
