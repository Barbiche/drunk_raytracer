using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pre.PpmVisualizer;

namespace PpmVisualizer
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MemoryStream _ms;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadFrame()
        {
            var bitmap      = PpmReader.ReadBitmapFromPPM("raytrace.ppm");
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            _ms = new MemoryStream();
            bitmap.Save(_ms, ImageFormat.Bmp);
            _ms.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = _ms;
            bitmapImage.EndInit();
            /*LoadFrame(bitmapImage);*/

            Image.BeginInit();
            Image.Width  = bitmap.Width;
            Image.Height = bitmap.Height;
            Image.Source = bitmapImage;
            Image.EndInit();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(ReadFrame));
        }

        private void Image_Unloaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { _ms.Dispose(); }));
        }
    }
}