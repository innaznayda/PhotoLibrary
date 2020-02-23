using PhotoLibrary.Models;
using System.Collections.Generic;

namespace PhotoLibrary.Helpers {
    public interface IFileHelper {
        List<Photo> GetImagesInFolder(string path);
    }
}