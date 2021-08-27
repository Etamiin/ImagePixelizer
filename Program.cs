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
            while (true)
            {
                try
                {
                    var targetImagePath = AskFor("Enter image path (ex: 'Sample/icon.png')");
                    var outputDirPath = AskFor("Enter output folder path (ex: 'Sample')");
                    var outputName = AskFor("Enter output name (ex: 'new_icon.png')");
                    var pixelizationLevel = int.Parse(AskFor("Enter your pixelization level (ex: '2')"));

                    Pixelizer.TransformAndSave(targetImagePath, (PixelImageLevel)pixelizationLevel, outputDirPath, outputName);

                    Console.WriteLine("Pixelization ended.");
                    Console.WriteLine("Enter key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error: { ex }");
                }
            }

            //Get transformed Bitmap object and do stuff with it
            //var output = Pixelizer.TransformBitmap("Sample/SampleImage.jpg", PixelImageLevel.Two);
        }

        private static string AskFor(string content)
        {
            Console.WriteLine(content);
            return Console.ReadLine();
        }
    }
}
