using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SonomaWallpaper
{
    public class DownloadStateToVisibilityConverter : IValueConverter
    {
        public DownloadState State { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return State == ((DownloadState)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
