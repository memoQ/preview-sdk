using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MemoQ.WebPreview.Log.LogEntry;

namespace MemoQ.WebPreview
{
    public class SettingsViewModel : ObservableViewModelBase, IDataErrorInfo
    {
        #region Fields

        private const string PipeNamePrefix = "\\\\.\\pipe\\";

        /// <summary>
        /// 
        /// </summary>
        public bool alwaysOnTop;

        /// <summary>
        /// 
        /// </summary>
        private string namedPipeAddress;

        /// <summary>
        /// 
        /// </summary>
        private string minimalSeverityToShowInLog;

        #endregion Fields

        #region Properties

        public bool AlwaysOnTop
        {
            get
            {
                return alwaysOnTop;
            }
            set
            {
                alwaysOnTop = value;
                OnPropertyChanged();
            }
        }

        public string NamedPipeAddress
        {
            get
            {
                return namedPipeAddress;
            }
            set
            {
                namedPipeAddress = value;
                OnPropertyChanged();
            }
        }

        public string MinimalSeverityToShowInLog
        {
            get
            {
                return minimalSeverityToShowInLog;
            }
            set
            {
                minimalSeverityToShowInLog = value;
                OnPropertyChanged();
            }
        }

        public bool IsValidNamedPipeAddress
        {
            get
            {
                return NamedPipeAddress.Length > 0 && PipeNamePrefix.Length + NamedPipeAddress.Length <= 256 && !NamedPipeAddress.Contains("\\"); ;
            }
        }

        public string Error
        {
            get { return "..."; }
        }

        /// <summary>
        /// Will be called for each and every property when ever its value is changed
        /// </summary>
        /// <param name="columnName">Name of the property whose value is changed</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        #endregion Properties

        #region Constructor

        public SettingsViewModel()
        {
            UpdateProperties();
        }

        #endregion Constructor

        #region Public methods

        public void UpdateProperties()
        {
            AlwaysOnTop = Settings.Instance.AlwaysOnTop;
            NamedPipeAddress = Settings.Instance.NamedPipeAddress;
            MinimalSeverityToShowInLog = Settings.Instance.MinimalSeverityToShowInLog.ToString();
        }

        #endregion Public methods

        #region Private methods

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "NamedPipeAddress":
                    if (!IsValidNamedPipeAddress)
                        validationMessage = "Named pipe service address is invalid.";
                    break;
            }

            return validationMessage;
        }

        #endregion Private methods
    }
}
