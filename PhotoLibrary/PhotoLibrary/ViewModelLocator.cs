using PhotoLibrary.ViewModel;
using PhotoLibrary.Helpers;
using System;

namespace PhotoLibrary {
    public class ViewModelLocator {
        private static IFileHelper fileHelper = new FileHelper();

        private static PhotoGalleryViewModel photoGalleryViewModel = new PhotoGalleryViewModel(fileHelper, Environment.CurrentDirectory);


        public static PhotoGalleryViewModel PhotoGalleryViewModel {
            get {
                return photoGalleryViewModel;
            }
        }
    }
}

