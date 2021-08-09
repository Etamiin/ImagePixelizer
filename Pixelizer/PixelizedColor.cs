using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImagePixelizer
{
    internal sealed class PixelizedColor
    {
        private uint _totalPixels;
        private uint _totalAlpha;
        private uint _totalRed;
        private uint _totalGreen;
        private uint _totalBlue;

        internal void AddPixel(Color pixel)
        {
            _totalPixels++;
            _totalAlpha += pixel.A;
            _totalRed += pixel.R;
            _totalGreen += pixel.G;
            _totalBlue += pixel.B;
        }

        internal Color GetColor()
        {
            if (_totalPixels == 0)
                return Color.Transparent;

            return Color.FromArgb(
                (int)(_totalAlpha / _totalPixels),
                (int)(_totalRed / _totalPixels),
                (int)(_totalGreen / _totalPixels),
                (int)(_totalBlue / _totalPixels));
        }
    }
}
