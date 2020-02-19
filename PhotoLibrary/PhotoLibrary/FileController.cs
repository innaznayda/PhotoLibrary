using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace PhotoLibrary {
    static class FileController {
        static public string GetFileName(string filePath) {
            if (!File.Exists(filePath))
                return null;

            return Path.GetFileName(filePath);
        }

        static public Bitmap GetBitmap(string filePath) {
            if (!File.Exists(filePath))
                return null;
            Bitmap resultBitmap;

            using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                using (MemoryStream ms = new MemoryStream(bytes)) {
                    resultBitmap = Bitmap.FromStream(ms) as Bitmap;
                }
            }
            return resultBitmap;
        }

        static public BitmapImage GetBitmapImage(Bitmap bitmap) {
            BitmapImage resultBitmapImage;
            Bitmap tempBitmap = new Bitmap(bitmap);
            if (tempBitmap == null)
                return null;
            using (MemoryStream memory = new MemoryStream()) {
                tempBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                resultBitmapImage = new BitmapImage();
                resultBitmapImage.BeginInit();
                resultBitmapImage.StreamSource = memory;
                resultBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                resultBitmapImage.EndInit();
                resultBitmapImage.Freeze();
            }
            return resultBitmapImage;
        }


    }
}
