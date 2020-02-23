using PhotoLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PhotoLibrary.View {
    /// <summary>
    /// Interaction logic for PhotoGalleryView.xaml
    /// </summary>
    public partial class PhotoGalleryView : Window {
        public PhotoGalleryView() {
            InitializeComponent();
        }

        private void ListBox_Drop(object sender, DragEventArgs e) {
            ListBox parent = (ListBox)sender;
            string data = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            (parent.ItemsSource as ObservableCollection<Photo>).Add(new Photo(data));
        }
        
    }
}
