using PhotoLibrary.ViewModel;
using System;

namespace PhotoLibrary {
    public class ViewModelLocator {

        private static PhotoGalleryViewModel photoGalleryViewModel = new PhotoGalleryViewModel(Environment.CurrentDirectory);


        public static PhotoGalleryViewModel PhotoGalleryViewModel {
            get {
                return photoGalleryViewModel;
            }
        }
    }
}

