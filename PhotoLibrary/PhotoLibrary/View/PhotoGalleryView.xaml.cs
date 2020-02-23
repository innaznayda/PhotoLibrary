using PhotoLibrary.Models;
using System;
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
            foreach (string file in data) {
                (parent.ItemsSource as AsyncObservableCollection<Photo>).Add(new Photo(file));
            }
        }
    }
}
