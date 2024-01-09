using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SonomaWallpaper
{
    public enum DownloadState
    {
        none,
        downloading,
        downloaded
    }

    public class WallpaperCategory
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<WallpaperAsset> assets { get; set; }
    }

    public class WallpaperAsset : INotifyPropertyChanged
    {
        WebClient _webClient;
        string _tempfile;
        private double _progress;
        private bool _isSelected;
        internal DownloadState _downloadState;

        public string id { get; set; }
        public string name { get; set; }
        public string previewImage { get; set; }
        public string downloadURL { get; set; }
        public string filePath { get; set; }
        public DownloadState downloadState
        {
            get => _downloadState;
            set
            {
                _downloadState = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public double progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }
        public bool isSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public async void Download()
        {
            downloadState = DownloadState.downloading;

            _webClient = new WebClient();
            _tempfile = Path.GetTempFileName();
            _webClient.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
            {
                if (e.Cancelled || e.Error != null)
                    return;

                filePath = FolderHelper.GetFilePathForURL(downloadURL, FolderHelper.DownloadPath);
                downloadState = DownloadState.downloaded;
                File.Move(_tempfile, filePath);
            };
            _webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
            {
                progress = e.ProgressPercentage;
            };
            try
            {
                await _webClient.DownloadFileTaskAsync(downloadURL, _tempfile);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.RequestCanceled)
                    return;

                downloadState = DownloadState.none;
                progress = 0;

                MessageBox.Show(I18nWpf.GetString("LNetworkErrorTip"), Constants.ProjectName);
            }
        }

        public async void CancelDownload()
        {
            _webClient.CancelAsync();

            downloadState = DownloadState.none;
            progress = 0;

            await Task.Delay(200);
            File.Delete(_tempfile);
        }

        public void OpenFolder()
        {
            Process.Start("explorer.exe", $"/select, \"{filePath}\"");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
