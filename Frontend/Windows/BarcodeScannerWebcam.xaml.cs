using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using ZXing.Windows.Compatibility;
using ZXing;

namespace Frontend.Windows
{
    /// <summary>
    /// Interaction logic for BarcodeScannerWebcam.xaml
    /// </summary>
    public partial class BarcodeScannerWebcam : Window
    {
        private VideoCapture _capture;
        private ZXing.Windows.Compatibility.BarcodeReader _barcodeReader;

        public BarcodeScannerWebcam()
        {
            InitializeComponent();
            InitializeWebCam(); 
            _barcodeReader = new ZXing.Windows.Compatibility.BarcodeReader()
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true, // Versuche, mehr Zeit in die Decodierung zu investieren
                    PossibleFormats = new List<ZXing.BarcodeFormat>
            {
                ZXing.BarcodeFormat.CODE_128, // Füge andere Formate hinzu, falls benötigt
                ZXing.BarcodeFormat.QR_CODE
            }
                }
            };
        }

        private void InitializeWebCam()
        {
            _capture = new VideoCapture(0); // 0 für die Standard-Webcam

            // Event, das aufgerufen wird, wenn ein neues Bild verfügbar ist
            _capture.ImageGrabbed += ProcessFrame;
            _capture.Start();
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            using (var frame = new Mat())
            {
                _capture.Retrieve(frame);


                // Convert the frame to Bitmap
                var image = frame.ToImage<Bgr, byte>();
                Bitmap bitmap = image.ToBitmap();
                Bitmap bitmap2 = new Bitmap(@"C:\KitchenIO\Frontend\demo.png");
                Bitmap bitmap3 = new Bitmap(@"C:\KitchenIO\FRontend\tetImage.jpg");


                // Decode the barcode
                var result = _barcodeReader.Decode(bitmap2);

                if (result != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        // Display barcode result in the UI
                        barcodeTextBlock.Text = result.Text; // Ensure 'barcodeTextBlock' is a TextBlock control
                    });
                }


                // Update the UI with the current frame
                Dispatcher.Invoke(() =>
                {
                    videoImage.Source = BitmapToImageSource(bitmap);
                });
            }
        }

        private BitmapSource BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var bitmapSource = BitmapSource.Create(bitmap.Width, bitmap.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null, bitmapData.Scan0, bitmapData.Stride * bitmap.Height,
                bitmapData.Stride);
            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_capture != null && _capture.IsOpened)
            {
                _capture.Stop();
                _capture.Dispose();
            }
            base.OnClosed(e);
        }
    }
}
