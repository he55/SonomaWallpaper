using System;
using System.IO;
using System.Linq;

namespace SonomaWallpaper
{
    public class FolderHelper
    {
        public static string DownloadPath { get; private set; }
        public static string ImageCachePath { get; private set; }

        public static void CreateFolder()
        {
            DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.ProjectName);
            ImageCachePath = Helper.GetPathForStartupFolder("images");

            if (!Directory.Exists(ImageCachePath))
                ImageCachePath = Helper.GetPathForUserAppDataFolder("images");

            if (!Directory.Exists(DownloadPath))
                Directory.CreateDirectory(DownloadPath);

            if (!Directory.Exists(ImageCachePath))
                Directory.CreateDirectory(ImageCachePath);
        }

        public static string GetFilePathForURL(string url, string dir)
        {
            string fileName = new Uri(url).Segments.Last();
            return Path.Combine(dir, fileName);
        }
    }
}
