using PhotoLibrary.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace PhotoLibrary.ViewModel {
    public class PhotoGalleryViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string CurrentLocation;

        public PhotoGalleryViewModel(string location) {
            CurrentLocation = location;
            LoadPhotos();
        }

        public ObservableCollection<Photo> AllPhotos {
            get {
                return allPhotos;
            }
            set {
                allPhotos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllPhotos)));
            }
        }
        private ObservableCollection<Photo> allPhotos;


        private Photo selectedPhoto;
        public Photo SelectedPhoto {
            get {
                return selectedPhoto;
            }
            set {
                selectedPhoto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPhoto)));
            }
        }

        private void LoadPhotos() {
            AllPhotos = FileHelper.GetImagesInFolder(CurrentLocation).ToObservableCollection();
        }

    }
}


