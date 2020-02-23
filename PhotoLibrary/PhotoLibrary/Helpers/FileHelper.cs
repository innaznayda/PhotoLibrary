using PhotoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoLibrary.Helpers {
    public class FileHelper  : IFileHelper {
        public List<Photo> GetImagesInFolder(string folderPath) {
            var result = new List<Photo>();

            if (!Directory.Exists(folderPath))
                return null;

            DirectoryInfo d = new DirectoryInfo(folderPath);
            foreach (var file in d.GetFiles("*.jpg")) {
                result.Add(new Photo(file.FullName));
            }

            return result;
        }

        public AsyncObservableCollection<string> CollectFilesInFolderAndFilter(string path) {
            var files = Directory.GetFiles(path, "*.*");

            return FilterFiles(files);
        }

        public AsyncObservableCollection<string> FilterFiles(string[] files) {
            return files
            .Where(s => s.EndsWith(".BMP", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".GIF", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".EXIF", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".JPG", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".PNG", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".TIFF", StringComparison.InvariantCultureIgnoreCase))
                     .ToObservableCollection();
        }

        public bool IsFolder(string path) {
            FileAttributes attr = File.GetAttributes(path);
            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            return false;
        }
    }
}
