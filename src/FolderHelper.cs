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
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DownloadPath = Path.Combine(myDocuments, Constants.ProjectName);

            string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ImageCachePath = Path.Combine(applicationData, Constants.ProjectName, "images");

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
