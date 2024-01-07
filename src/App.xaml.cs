using System;
using System.Windows;

namespace SonomaWallpaper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length == 0)
            {
                IntPtr hwnd = NativeMethods.FindWindow(null, Constants.MainWindowTitle);
                if (hwnd != IntPtr.Zero)
                {
                    const int SW_RESTORE = 9;
                    NativeMethods.ShowWindow(hwnd, SW_RESTORE);
                    NativeMethods.SetForegroundWindow(hwnd);

                    Environment.Exit(0);
                    return;
                }
            }

            if (Settings.Load().Language == "zh_CN")
                Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/i18n/zh_CN.xaml") });
        }
    }
}
