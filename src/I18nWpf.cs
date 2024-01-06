using System.Windows;

namespace SonomaWallpaper
{
    public static class I18nWpf
    {
        public static string GetString(string key)
        {
            return (string)Application.Current.Resources[key];
        }
    }
}
