using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Windows;
using Windows.Media.Core;
using Windows.UI.Xaml.Controls;

namespace SonomaWallpaper
{
    /// <summary>
    /// Interaction logic for UwpVideoWindow.xaml
    /// </summary>
    public partial class UwpVideoWindow : Window
    {
        MediaPlayerElement _mediaPlayerElement;

        public UwpVideoWindow()
        {
            InitializeComponent();

            this.Topmost = true;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }

        public string Source { get; set; }
        public bool IsPlaying { get; set; }

        public void Play()
        {
            if (_mediaPlayerElement != null)
            {
                _mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(Source));
                _mediaPlayerElement.MediaPlayer.Play();
                IsPlaying = true;
            }
        }

        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            _mediaPlayerElement = (MediaPlayerElement)((WindowsXamlHost)sender).Child;
            if (_mediaPlayerElement != null)
            {
                _mediaPlayerElement.Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill;
                _mediaPlayerElement.Source = MediaSource.CreateFromUri(new Uri(Source));
                _mediaPlayerElement.AutoPlay = true;
                _mediaPlayerElement.MediaPlayer.IsMuted = true;
                _mediaPlayerElement.MediaPlayer.IsLoopingEnabled = true;
                _mediaPlayerElement.PointerReleased += MediaPlayerElement_PointerReleased;
                IsPlaying = true;
            }
        }

        private void MediaPlayerElement_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (_mediaPlayerElement != null)
            {
                _mediaPlayerElement.MediaPlayer.Pause();
                _mediaPlayerElement.MediaPlayer.Position = TimeSpan.Zero;
                IsPlaying = false;
            }

            this.Hide();
        }
    }
}
