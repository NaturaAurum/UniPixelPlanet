using System.Globalization;
using UnityEngine;

namespace UniPixelPlanet.Runtime
{
    public static class ColorUtil
    {
        public static Color FromRGB(byte r, byte g, byte b)
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }

        public static Color FromRGB(string htmlString)
        {
            var argb = int.Parse(htmlString.Replace("#", ""), NumberStyles.HexNumber);
            var clr = System.Drawing.Color.FromArgb(argb);


            //ColorUtility.TryParseHtmlString( htmlString, out var color );
            return new Color32(clr.R, clr.G, clr.B, 0xff);
        }

        public static float GetRandomHueColorByRanges(System.Random rng, int[,] ranges)
        {
            var randMax = 0;
            for (var i = 0; i < ranges.GetLength(0); i++)
            {
                randMax += (ranges[i, 1] - ranges[i, 0]);
            }

            var r = rng.Next(0, randMax);

            var curPos = 0;
            for (var i = 0; i < ranges.GetLength(0); i++)
            {
                var curRange = (ranges[i, 1] - ranges[i, 0]);
                if (r > (curPos + curRange))
                {
                    curPos += curRange;
                    continue;
                }
                else
                {
                    var hueValue = r - curPos + ranges[i, 0];
                    return (float)hueValue / 360f;
                }
            }

            return 0f;
        }
    }
}