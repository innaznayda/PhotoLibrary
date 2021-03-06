﻿using PhotoLibrary.Models;
using PhotoLibrary.Helpers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PhotoLibrary.ViewModel {
    public class PhotoGalleryViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ShowSelectedPhotoCommand { get; set; }
        public ICommand HideSelectedPhotoCommand { get; set; }
        public ICommand GoNextPhotoCommand { get; set; }
        public ICommand GoPreviousPhotoCommand { get; set; }
        private string CurrentLocation;
        private IFileHelper FileHelper;
        private bool isSingleMode;
        public bool IsSingleMode {
            get {
                return isSingleMode;
            }
            set {
                isSingleMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSingleMode)));
            }
        }
        public bool IsGalleryMode => !IsSingleMode;

        public PhotoGalleryViewModel(IFileHelper fileHelper, string location) {
            CurrentLocation = location;
            FileHelper = fileHelper;
            ShowSelectedPhotoCommand = new CustomCommand(ShowPhoto, CanShowPhoto);
            HideSelectedPhotoCommand = new CustomCommand(HidePhoto, CanShowPhoto);
            GoNextPhotoCommand = new CustomCommand(GoNext, CanShowPhoto);
            GoPreviousPhotoCommand = new CustomCommand(GoPrevious, CanShowPhoto);
            LoadPhotos();
            
        }

        private void GoPrevious(object obj) {
            int index = AllPhotos.IndexOf(SelectedPhoto) - 1;
            if (index < 0) {
                return;
            }
            SelectedPhoto = AllPhotos[index];
        }

        private void GoNext(object obj) {
            int index = AllPhotos.IndexOf(SelectedPhoto) + 1;
            if (index > AllPhotos.Count - 1) {
                return;
            }
            SelectedPhoto = AllPhotos[index];

        }

        private bool CanShowPhoto(object obj) {
            if (SelectedPhoto != null)
                return true;
            return false;
        }

        private void ShowPhoto(object obj) {
            IsSingleMode = true;

        }
        private void HidePhoto(object obj) {
            SelectedPhoto = null;
            IsSingleMode = false;

        }

        public AsyncObservableCollection<Photo> AllPhotos {
            get {
                return allPhotos;
            }
            set {
                allPhotos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllPhotos)));
            }
        }
        private AsyncObservableCollection<Photo> allPhotos;

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

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}


