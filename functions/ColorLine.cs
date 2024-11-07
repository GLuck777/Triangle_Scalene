using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Triangle_Scalene.functions
{
    static public class ColorLine
    {
            private const string format  = "\x1b";
            // Text
            public static readonly string Text_Bold           = format + "[1m";
            public static readonly string Text_Italic         = format + "[3m";
            public static readonly string Text_Underline      = format + "[4m";
            public static readonly string Text_Blink          = format + "[5m";
            public static readonly string Text_Reversed       = format + "[7m";
            public static readonly string Text_Hiddens        = format + "[8m";
            public static readonly string Text_Strikethrough  = format + "[9m";
            // Color
            public static readonly string Color_Black    = format + "[38;2;0;0;0m"; // ANSI CODE with RGB
            public static readonly string Color_Red      = format + "[38;2;255;0;0m";
            public static readonly string Color_Green    = format + "[38;2;0;255;0m";
            public static readonly string Color_Yellow   = format + "[38;2;255;255;0m";
            public static readonly string Color_Orange   = format + "[38;2;255;136;0m";
            public static readonly string Color_Blue     = format + "[38;2;0;0;255m";
            public static readonly string Color_Magenta  = format + "[38;2;120;0;76m";
            public static readonly string Color_Cyan     = format + "[38;2;0;162;211m";
            public static readonly string Color_White    = format + "[38;2;255;255;255m";
            // Reset
            public static readonly string ResetAll            = format + "[m";
            public static readonly string ResetBold           = format + "[22m";
            public static readonly string ResetItalic         = format + "[23m";
            public static readonly string ResetUnderline      = format + "[24m";
            public static readonly string ResetReversed       = format + "[27m";
            public static readonly string ResetHiddens        = format + "[28m";
            public static readonly string ResetStrikethrough  = format + "[29m";
    }
}