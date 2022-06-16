using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    internal class ThemeColor
    {
        public static List<string> ColorList = new List<string>() { "#2CAFD0",
                                                                    "#4078B4",
                                                                    "#2C4053",
                                                                    "#2D475E",
                                                                    "#2D4F6B",
                                                                    "#306A93",
                                                                    "#3177A8",
                                                                    "#3286BF",
                                                                    "#3494D5",};
        public static Color ChangeColorBrighness(Color color, double correctionfactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionfactor < 0)
            {
                correctionfactor = 1 + correctionfactor;
                red *= correctionfactor;
                green *= correctionfactor;
                blue *= correctionfactor;
            }

            else
            {
                red = (255 - red) * correctionfactor + red;
                green = (255 - green) * correctionfactor + green;
                blue = (255 - blue) * correctionfactor + blue;
            }

            return Color.FromArgb(color.A, ((byte)red), ((byte)green), ((byte)blue));
        }

        internal static Color ChangeColorBrighness()
        {
            throw new NotImplementedException();
        }
    }
}

