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
            if (Settings.Load().Language == "zh_CN")
                Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/i18n/zh_CN.xaml") });
        }
    }
}
