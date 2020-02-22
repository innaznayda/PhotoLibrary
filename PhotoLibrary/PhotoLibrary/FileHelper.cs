using PhotoLibrary.Models;
using System.Collections.Generic;
using System.IO;

namespace PhotoLibrary {
    static class FileHelper {
        public static List<Photo> GetImagesInFolder(string folderPath) {
            var result = new List<Photo>();

            if (!Directory.Exists(folderPath))
                return null;

            DirectoryInfo d = new DirectoryInfo(folderPath);
            foreach (var file in d.GetFiles("*.jpg")) {
                result.Add(new Photo(file.FullName));
            }

            return result;
        }
    }
}
