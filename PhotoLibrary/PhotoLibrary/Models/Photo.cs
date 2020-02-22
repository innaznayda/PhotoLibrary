using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace PhotoLibrary.Models {
    public class Photo {
        public Uri ImageUri { get; private set; }

        public string Label { get; set; }

        public Photo(string location) {
            if (File.Exists(location)) {
                ImageUri = new Uri(location);
            }
            Label = location;
        }
    }
}
