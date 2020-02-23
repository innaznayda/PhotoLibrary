using PhotoLibrary.Models;
using System.Collections.Generic;

namespace PhotoLibrary.Helpers {
    public interface IFileHelper {
        List<Photo> GetImagesInFolder(string path);

        AsyncObservableCollection<string> CollectFilesInFolderAndFilter(string path);

        AsyncObservableCollection<string> FilterFiles(string[] files);

        bool IsFolder(string path);
    }
}