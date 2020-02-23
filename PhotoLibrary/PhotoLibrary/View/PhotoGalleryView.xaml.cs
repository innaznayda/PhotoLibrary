using PhotoLibrary.Models;
using PhotoLibrary.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhotoLibrary.View {
    /// <summary>
    /// Interaction logic for PhotoGalleryView.xaml
    /// </summary>
    public partial class PhotoGalleryView : Window {
        IFileHelper FileHelper = new FileHelper();

        public PhotoGalleryView() {
            InitializeComponent();
            Image right = new Image();
            right.Source = new BitmapImage(new Uri(@"..\Icons\right.ico", UriKind.Relative));
            Right.Content = right;
            Image left = new Image();
            left.Source = new BitmapImage(new Uri(@"..\Icons\left.ico", UriKind.Relative));
            Left.Content = left;
            
        }

        private void PhotoGallery_Drop(object sender, DragEventArgs e) {
            ListBox parent = (ListBox)sender;
            var data = ((string[])e.Data.GetData(DataFormats.FileDrop, false));
            var files = new AsyncObservableCollection<string>();
            if (data.Length == 1 && FileHelper.IsFolder(data[0])) {
                files = FileHelper.CollectFilesInFolderAndFilter(data[0]);
            } else {
                files = FileHelper.FilterFiles(data);
            }
            foreach (string file in files) {
                (parent.ItemsSource as AsyncObservableCollection<Photo>).Add(new Photo(file));
            }
        }

        


    }
}
