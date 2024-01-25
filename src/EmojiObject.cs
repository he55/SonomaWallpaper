using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmojiViewer
{
    public class EmojiObject
    {
        public string cldr { get; set; }
        public string fromVersion { get; set; }
        public string glyph { get; set; }
        public string group { get; set; }
        public string[] keywords { get; set; }
        public string[] mappedToEmoticons { get; set; }
        public string tts { get; set; }
        public string unicode { get; set; }
    }

    public class EmojiAsset : INotifyPropertyChanged
    {
        private bool _isSelected;
        private List<AssetItem> _items;

        public EmojiObject emoji { get; set; }
        public List<AssetItem> items
        {
            get
            {
                if (_items == null)
                    _items = AssetItemHelper.MakeItems(id);
                return _items;
            }
        }
        public string id { get; set; }
        public string name { get; set; }
        public string previewImage { get; set; }
        public string filePath { get; set; }
        public bool isSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class EmojiCategory
    {
        public string title { get; set; }
        public List<EmojiAsset> assets { get; set; }
    }

    public class AssetSubitem
    {
        public string name { get; set; }
        public string source { get; set; }
    }

    public class AssetItem
    {
        public string name { get; set; }
        public List<AssetSubitem> subitems { get; set; }
    }

    public class AssetItemHelper
    {
        public static List<AssetItem> MakeItems(string path)
        {
            List<AssetItem> items = new List<AssetItem>();
            string imageDir = Path.Combine(path, "3D");
            if (Directory.Exists(imageDir))
            {
                items.Add(new AssetItem
                {
                    name = "Default",
                    subitems = MakeSubitems(path)
                });
                return items;
            }

            string[] dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                string name = Path.GetFileName(dir);
                items.Add(new AssetItem
                {
                    name = name,
                    subitems = MakeSubitems(dir)
                });
            }
            return items;
        }

        static List<AssetSubitem> MakeSubitems(string path)
        {
            List<AssetSubitem> items = new List<AssetSubitem>();
            string[] dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir);
                string image = files.FirstOrDefault(x => x.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || x.EndsWith(".svg", StringComparison.OrdinalIgnoreCase));
                if (image == null)
                    continue;

                string name = Path.GetFileName(dir);
                items.Add(new AssetSubitem
                {
                    name = name,
                    source = image,
                });
            }
            return items;
        }
    }
}
