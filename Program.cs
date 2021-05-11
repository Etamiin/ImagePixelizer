using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePixelizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example usage

            //You can add levels on the PixelImageLevel enum object with different value for less or more pixelization
            //The more the value is low, the less it will be pixelized

            //103x139 PNG Image take 100-150ms to be transformed
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.VeryUltra, "Sample", "transformedImageVeryUltraLevel.png");
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Ultra, "Sample", "transformedImageUltraLevel.png");
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.VeryHigh, "Sample", "transformedImageVeryHighLevel.png");
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.High, "Sample", "transformedImageHighLevel.png");
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Normal, "Sample", "transformedImageNormalLevel.png");
            Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Low, "Sample", "transformedImageLowLevel.png");

            //1150x699 JPG Image take 5-10 seconds to be transformed
            Pixelizer.TransformAndSave("Sample/Landscape.jpg", PixelImageLevel.VeryUltra, "Sample", "TransformedLandscape.png");

            //Get transformed Bitmap object and do stuff with it
            var output = Pixelizer.TransformBitmap("Sample/SampleImage.jpg", PixelImageLevel.Normal);
            
            Console.WriteLine("Transformed.");
            Console.ReadLine();
        }
    }
}
