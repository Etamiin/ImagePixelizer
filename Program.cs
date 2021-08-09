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
            var targetImagePath = @"Sample/achievement.png";
            var outputDirPath = @"Sample";
            var outputName = @"achievement_icon.png";

            Pixelizer.TransformAndSave(targetImagePath, PixelImageLevel.Two, outputDirPath, outputName);

            //Get transformed Bitmap object and do stuff with it
            //var output = Pixelizer.TransformBitmap("Sample/SampleImage.jpg", PixelImageLevel.Two);

            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }
}
