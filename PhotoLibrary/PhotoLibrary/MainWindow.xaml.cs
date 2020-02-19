using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoLibrary {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public string DisplayedImagePath {
            get { return @"C:\Users\Public\Pictures\deal.png"; }
        }

        // Image Source [BitmapImage]
        private BitmapImage _displayImage;
        public BitmapImage DisplayImage {
            get { return _displayImage; }
            set { _displayImage = value; }
        }

        private void GetImageFromFilePath(string filePath) {
            Bitmap bitmap = FileController.GetBitmap(filePath);
            DisplayImage = FileController.GetBitmapImage(bitmap);
        }

        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            GetImageFromFilePath(DisplayedImagePath);
        }
    }
}
