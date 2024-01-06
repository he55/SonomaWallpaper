using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SonomaWallpaper
{
    public class EntriesObject
    {
        public int initialAssetCount { get; set; }
        public Category[] categories { get; set; }
        public int version { get; set; }
        public string localizationVersion { get; set; }
        public Asset[] assets { get; set; }
    }

    public class Category
    {
        public string previewImage { get; set; }
        public Category[] subcategories { get; set; }
        public string id { get; set; }
        public int preferredOrder { get; set; }
        public string representativeAssetID { get; set; }
        public string localizedNameKey { get; set; }
        public string localizedDescriptionKey { get; set; }
    }

    public class Asset
    {
        public string[] subcategories { get; set; }
        public bool showInTopLevel { get; set; }
        public string shotID { get; set; }
        public string previewImage { get; set; }
        public Dictionary<string, string> pointsOfInterest { get; set; }
        public string localizedNameKey { get; set; }
        public bool includeInShuffle { get; set; }
        public string accessibilityLabel { get; set; }
        [DataMember(Name = "url-4K-SDR-240FPS")]
        public string url4KSDR240FPS { get; set; }
        public string id { get; set; }
        public int preferredOrder { get; set; }
        public string[] categories { get; set; }
        public string group { get; set; }
    }
}
