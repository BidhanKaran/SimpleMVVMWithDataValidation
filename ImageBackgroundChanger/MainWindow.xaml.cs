using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Color = System.Drawing.Color;

namespace ImageBackgroundChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _originalImagePath = string.Empty;
        private string _backgroundImagePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonProcess_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_originalImagePath) && !string.IsNullOrEmpty(_backgroundImagePath))
            {
                BitmapImage interMediateImage;
                FinalImage.Source = GrayScaleConverter(_originalImagePath, _backgroundImagePath, out interMediateImage);
                AfterRemovingGreen.Source = interMediateImage;
            }
            else
            {
                MessageBox.Show("Please select some image");
            }
        }

        private BitmapImage GrayScaleConverter(string mainImagepath, string backgroundPath, out BitmapImage interMediateImage)
        {
            var inputBitmap = new Bitmap(Image.FromFile(mainImagepath)); // Load the  image
            var backgroundBitmap = new Bitmap(Image.FromFile(backgroundPath));
            var intermediateBitMap = new Bitmap(inputBitmap.Width, inputBitmap.Height);
            var outputBitmap =  new Bitmap(backgroundBitmap, new System.Drawing.Size(inputBitmap.Width, inputBitmap.Height));
            // Iterate over all piels from top to bottom...
            for (int y = 0; y < outputBitmap.Height; y++)
            {
                // ...and from left to right
                for (int x = 0; x < outputBitmap.Width; x++)
                {
                    // Determine the pixel color
                    Color camColor = inputBitmap.GetPixel(x, y);

                    // Every component (red, green, and blue) can have a value from 0 to 255, so determine the extremes
                    byte max = Math.Max(Math.Max(camColor.R, camColor.G), camColor.B);
                    byte min = Math.Min(Math.Min(camColor.R, camColor.G), camColor.B);
                    bool replace = false;
                    if(BackgroundColor.SelectionBoxItem.ToString().Equals("Green") )
                    // Should the pixel be masked/replaced?
                     replace =
                        camColor.G != min // green is not the smallest value
                        && (camColor.G == max // green is the biggest value
                            || max - camColor.G < 8) // or at least almost the biggest value
                        && (max - min) > 96; // minimum difference between smallest/biggest value (avoid grays)

                    else if (BackgroundColor.SelectionBoxItem.ToString().Equals("Red"))
                        // Should the pixel be masked/replaced?
                        replace =
                            camColor.R != min // green is not the smallest value
                            && (camColor.R == max // green is the biggest value
                                || max - camColor.R < 8) // or at least almost the biggest value
                            && (max - min) > 96; // minimum difference between smallest/biggest value (avoid grays)

                   else if (BackgroundColor.SelectionBoxItem.ToString().Equals("Blue"))
                        // Should the pixel be masked/replaced?
                        replace =
                            camColor.B != min // green is not the smallest value
                            && (camColor.B == max // green is the biggest value
                                || max - camColor.B < 8) // or at least almost the biggest value
                            && (max - min) > 96; // minimum difference between smallest/biggest value (avoid grays)

                    if (!replace)
                    {
                        // Set the output pixel
                        outputBitmap.SetPixel(x, y, camColor);
                        intermediateBitMap.SetPixel(x, y, camColor);
                    }
                    else
                    {
                        camColor = Color.White;
                        intermediateBitMap.SetPixel(x,y,camColor);
                    }
                }
            }
            interMediateImage = Bitmap2BitmapImage(intermediateBitMap);
            return Bitmap2BitmapImage(outputBitmap);
        }

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        private void ButtonBrowseMain_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog {Title = "Main Image"};
            if (openFileDialog.ShowDialog() == true)
            {
                var fileInfo = new FileInfo(openFileDialog.FileName);
                _originalImagePath = fileInfo.FullName;
                mainImage.Text = _originalImagePath;
                RowImage.Source = new BitmapImage(new Uri(_originalImagePath));
            }
        }

        private void ButtonBrowseBackground_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog {Title = "Background Image"};
            if (openFileDialog.ShowDialog() == true)
            {
                var fileInfo = new FileInfo(openFileDialog.FileName);
                _backgroundImagePath = fileInfo.FullName;
                backgroundImage.Text = _backgroundImagePath;
                BackgroundImage.Source = new BitmapImage(new Uri(_backgroundImagePath));
            }
        }
    }
}
