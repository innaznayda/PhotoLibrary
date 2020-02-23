using PhotoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhotoLibrary.View {
    /// <summary>
    /// Interaction logic for PhotoGalleryView.xaml
    /// </summary>
    public partial class PhotoGalleryView : Window {
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
            if (data.Length == 1 && IsFolder(data[0])) {
                files = CollectFilesInFolderAndFilter(data[0]);
            } else {
                files = FilterFiles(data);
            }
            foreach (string file in files) {
                (parent.ItemsSource as AsyncObservableCollection<Photo>).Add(new Photo(file));
            }
        }

        private AsyncObservableCollection<string> CollectFilesInFolderAndFilter(string path) {
            var files = Directory.GetFiles(path, "*.*");

            return FilterFiles(files);
        }

        private AsyncObservableCollection<string> FilterFiles(string[] files) {
            return files
            .Where(s => s.EndsWith(".BMP", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".GIF", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".EXIF", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".JPG", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".PNG", StringComparison.InvariantCultureIgnoreCase)
                     || s.EndsWith(".TIFF", StringComparison.InvariantCultureIgnoreCase))
                     .ToObservableCollection();
        }

        private bool IsFolder(string path) {
            FileAttributes attr = File.GetAttributes(path);
            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            return false;
        }


    }
}
