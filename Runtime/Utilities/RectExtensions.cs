using System;
using System.Collections.Generic;
using UnityEngine;

namespace EqualReality.Utilities
{
    public static class RectExtensions
    {
        public static Rect Inset(this Rect r, float amount, float vertical = Single.NaN)
        {
            if (float.IsNaN(vertical)) vertical = amount;
            return new Rect(r.x + amount, r.y + vertical, r.width - 2 * amount, r.height - 2 * vertical);
        }

        public static Rect Top(this Rect r, float height)
        {
            return new Rect(r.x, r.y, r.width, height);
        }

        public static Rect TopRemains(this Rect r, float height)
        {
            return new Rect(r.x, r.y + height, r.width, r.height - height);
        }

        public static Rect Bottom(this Rect r, float height)
        {
            return new Rect(r.x, r.y + r.height - height, r.width, height);
        }

        public static Rect BottomRemains(this Rect r, float height)
        {
            return new Rect(r.x, r.y, r.width, r.height - height);
        }

        public static Rect Left(this Rect r, float width)
        {
            return new Rect(r.x, r.y, width, r.height);
        }

        public static Rect Left(this Rect r, GUIStyle style)
        {
            return new Rect(r.x, r.y + style.margin.top, style.fixedWidth + style.margin.right,
                r.height - style.margin.top - style.margin.bottom);
        }

        public static Rect Center(this Rect r, float width)
        {
            return new Rect(r.x + r.width/2 - width/2, r.y, width, r.height);
        }

        public static Rect Middle(this Rect r, float height)
        {
            return new Rect(r.x, r.y + r.height/2 - height/2, r.width, height);
        }

        public static Rect LeftRemains(this Rect r, float width)
        {
            return new Rect(r.x + width, r.y, r.width - width, r.height);
        }

        public static Rect LeftRemains(this Rect r, GUIStyle style)
        {
            return new Rect(r.x + style.fixedWidth + style.margin.right, r.y,
                r.width - (style.fixedWidth + style.margin.right), r.height);
        }

        public static Rect Right(this Rect r, float width)
        {
            return new Rect(r.x + r.width - width, r.y, width, r.height);
        }

        public static Rect Right(this Rect r, GUIStyle style)
        {
            return new Rect(r.x + r.width - (style.fixedWidth + style.margin.right), r.y + style.margin.top,
                style.fixedWidth + style.margin.right,
                r.height - style.margin.top - style.margin.bottom);
        }

        public static Rect RightRemains(this Rect r, float width)
        {
            return new Rect(r.x, r.y, r.width - width, r.height);
        }

        public static Rect RightRemains(this Rect r, GUIStyle style)
        {
            return new Rect(r.x, r.y + style.margin.top,
                r.width - (style.fixedWidth + style.margin.right),
                r.height);
        }

        public static List<Rect> Slice(this Rect r, int slices, float spacing = 0)
        {
            var ret = new List<Rect>();
            var dx = (r.width - spacing * (slices - 1)) / slices;
            for (var i = 0; i != slices; ++i)
            {
                ret.Add(new Rect(
                    r.x + i * (dx + spacing), r.y,
                    dx, r.height
                ));
            }

            return ret;
        }

        public static List<Rect> SliceWithMaxWidth(this Rect r, int slices, float MaxWidth, bool floatright = false, float spacing = 0)
        {
            var ret = new List<Rect>();
            var dx = Mathf.Min((r.width - spacing * (slices - 1)) / slices, MaxWidth);
            var left = floatright ? r.x + r.width - slices * (dx + spacing) : r.x;
            for (var i = 0; i != slices; ++i)
            {
                ret.Add(new Rect(
                    left + i * (dx + spacing), 
                    r.y,
                    dx, r.height
                ));
            }

            return ret;
        }

        public static List<Rect> SliceVertical(this Rect r, int slices)
        {
            var ret = new List<Rect>();
            var dy = r.height / slices;
            for (var i = 0; i != slices; ++i)
            {
                ret.Add(new Rect(
                    r.x, r.y + i * dy,
                    r.width, dy
                ));
            }

            return ret;
        }

        public static Rect Clone(this Rect r)
        {
            return new Rect(r.x, r.y, r.width, r.height);
        }
    }
}