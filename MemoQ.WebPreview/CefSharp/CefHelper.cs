using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview.CefSharp
{
    internal static class CefHelper
    {
        public static void LoadCefDllsAndInit()
        {
            AppDomain.CurrentDomain.AssemblyResolve += handleCurrentDomainAssemblyResolve;
            loadAll(Environment.Is64BitProcess);
            initCef();
        }

        private static Assembly handleCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var domain = (AppDomain)sender;

            foreach (var assembly in domain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                    return assembly;
            }

            return null;
        }

        private static void loadAll(bool Is64BitProcess)
        {
            loadAssembly("CefSharp.Core.dll", Is64BitProcess);
            loadAssembly("CefSharp.dll", Is64BitProcess);
            loadAssembly("CefSharp.WinForms.dll", Is64BitProcess);
        }

        private static Assembly loadAssembly(string assemblyName, bool Is64BitProcess)
        {
            string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Is64BitProcess ? "x64" : "x86",
                                                   assemblyName);

            return File.Exists(archSpecificPath)
                       ? Assembly.LoadFile(archSpecificPath)
                       : null;
        }

        private static void initCef()
        {
            Cef.ExecuteProcess();
            CefSettings settings = new CefSettings();
            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");
            settings.FocusedNodeChangedEnabled = true;

            if (!Cef.IsInitialized)  //Cef should only initialized once
                Cef.Initialize(settings, false, null);

            Cef.EnableHighDPISupport();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
        }
    }
}
