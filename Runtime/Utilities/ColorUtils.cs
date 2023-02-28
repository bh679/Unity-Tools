using UnityEngine;
using System.Collections;

namespace EqualReality.Utilities
{
    public static class ColorUtils {

        public static Color withAlpha(this Color c, float a)
        {
            return new Color(c.r, c.g, c.b, a);
        }

        public static Color clone(this Color c)
        {
            return new Color(c.r, c.g, c.b, c.a);
        }

        public static Color toGrey(this float g) {
            Color c = Color.black;
            c.r = g;
            c.g = g;
            c.b = g;
            return c;
        }

        public static bool isWhite(this Color c)
        {
            return (c.a == 1 && c.r == 1 && c.b == 1 && c.g == 1);
        }

        private static string ColorToHex(Color32 color)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
            return hex;
        }

        public static string toHex(this Color32 color)
        {
            return ColorToHex(color);
        }

        public static string toHex(this Color color)
        {
            return ColorToHex(color);
        }

        public static Color fromHex(string hex)
        {
            byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r,g,b, 255);
        }
    }
}