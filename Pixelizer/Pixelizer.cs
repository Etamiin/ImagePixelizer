using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ImagePixelizer
{
    public static class Pixelizer
    {
        public static void TransformAndSave(string imagePath, PixelImageLevel level, string outputFolderPath, string outputFileName)
        {
            if (!File.Exists(imagePath))
                throw new FileNotFoundException();

            TransformAndSave((Bitmap)Image.FromFile(imagePath), level, outputFolderPath, outputFileName);
        }
        public static void TransformAndSave(Bitmap input, PixelImageLevel level, string outputFolderPath, string outputFileName)
        {
            var output = TransformBitmap(input, level);
            if (output == null)
                return;

            output.Save(Path.Combine(outputFolderPath, outputFileName));
        }
        public static Bitmap TransformBitmap(string imagePath, PixelImageLevel level)
        {
            if (!File.Exists(imagePath))
                throw new FileNotFoundException();

            return TransformBitmap((Bitmap)Image.FromFile(imagePath), level);
        }
        public static Bitmap TransformBitmap(Bitmap input, PixelImageLevel level)
        {
            var mSize = (byte)level;
            var colors = new Color[input.Width, input.Height];
            var realSize = new Size();
            var maximumY = 0;

            for (var x = 0; x < input.Width; x += mSize)
            {
                for (var y = 0; y < input.Height; y += mSize)
                {
                    var col = GetGeneralPixelColor(x, y, mSize);

                    colors[realSize.Width, realSize.Height] = col;
                    realSize.Height++;
                }

                if (realSize.Height > maximumY)
                    maximumY = realSize.Height;

                realSize.Width++;
                realSize.Height = 0;
            }

            var output = new Bitmap(input.Width, input.Height);

            for (var x = 0; x < realSize.Width; x++)
            {
                for (var y = 0; y < maximumY; y++)
                    SetGeneralPixelColor(x * mSize, y * mSize, mSize, colors[x, y]);
            }

            return output;

            Color GetGeneralPixelColor(int x, int y, int maxSize)
            {
                var pColor = new PixelizedColor();

                for (var inX = x - maxSize; inX < x + maxSize; inX++)
                {
                    for (var inY = y - maxSize; inY < y + maxSize; inY++)
                    {
                        if (inX < 0 || inY < 0 || inX >= input.Width || inY >= input.Height)
                            continue;

                        var color = input.GetPixel(inX, inY);
                        pColor.AddPixel(color);
                    }
                }

                return pColor.GetColor();
            }
            void SetGeneralPixelColor(int x, int y, int maxSize, Color color)
            {
                for (var inX = x - maxSize; inX < x + maxSize; inX++)
                {
                    for (var inY = y - maxSize; inY < y + maxSize; inY++)
                    {
                        if (inX < 0 || inY < 0 || inX >= input.Width || inY >= input.Height)
                            continue;

                        output.SetPixel(inX, inY, color);
                    }
                }
            }
        }
    }
}
