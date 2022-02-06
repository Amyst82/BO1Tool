using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace bo1tool
{
    public static class UIColors
    {
        public static SolidColorBrush defaultHightligght;
        public static SolidColorBrush getBrush()
        {
            return defaultHightligght;
        }

        public static string getStyleColorString(MainWindow main)
        {
            SolidColorBrush styleBrush = (SolidColorBrush)main.Resources["DefaultColor"];
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(styleBrush.Color.A, styleBrush.Color.R, styleBrush.Color.G, styleBrush.Color.B);
            return ColorTranslator.ToHtml(myColor);
        }
        public static string getThemeColorString(MainWindow main)
        {
            SolidColorBrush styleBrush = (SolidColorBrush)main.Resources["DefaultColor"];
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(styleBrush.Color.A, styleBrush.Color.R, styleBrush.Color.G, styleBrush.Color.B);
            return ColorTranslator.ToHtml(myColor);
        }

        public static string getTheme(MainWindow main)
        {
            SolidColorBrush theme = (SolidColorBrush)main.Resources["DefaultBackground"];
            if (theme.Color == (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF5F5F5"))
            {
                return "Light";
            }
            else if (theme.Color == (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF161524"))
            {
                return "Dark";
            }
            //if (theme.Color == (Color)ColorConverter.ConvertFromString("#FFF5F5F5"))
            //{
            //    return "Light";
            //}
            return "Dark";
        }

        private static Color getThemeColor(string themeString)
        {
            Color clr = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF0E0F1A");
            if (themeString == "Light")
            {
                clr = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF5F5F5");
            }
            else if(themeString =="Dark")
            {
                clr = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF161524");//("#FF0E0F1A");
            }
            else if(themeString == "fncTheme")
            {
                clr = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF141414");
            }
            return clr;
        }
        private static void setThemeOpacity(MainWindow main, string themeString)
        {
            Color opacityColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#19616191");
            Color opacityColor2 = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF202335");

            if (themeString == "Light")
            {
                opacityColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#19313131");
                opacityColor2 = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF");
            }
            else if (themeString == "Dark")
            {
                opacityColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#19616191");
                opacityColor2 = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF202335");
            }
            else if (themeString == "fncTheme")
            {
                opacityColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#19212121");
                opacityColor2 = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF707070");

                SolidColorBrush styleBrush = new SolidColorBrush(Colors.White);
                main.Resources["DefaultAccentColor"] = styleBrush;
            }
            SolidColorBrush themeOpacityBrush = new SolidColorBrush(opacityColor);
            SolidColorBrush themeOpacityBrush2 = new SolidColorBrush(opacityColor2);
            main.Resources["DefaultBackgroundOpacity"] = themeOpacityBrush;
            main.Resources["BackgroundOpaque"] = themeOpacityBrush2;
        }
        public static void changeStyleColorFromString(MainWindow main, string styleString)
        {
            Color Color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(styleString);
            changeStyleColor(main, Color);
        }
        public static void changeStyleColor(MainWindow main, Color color)
        {
            int r = (int)color.R + 80;
            int g = (int)color.G + 80;
            int b = (int)color.B + 80;
            if (r > 255) 
                r = 255;
            if (g > 255)
                g = 255;
            if (b > 255)
                b = 255;

            Color styleHighlight = Color.FromArgb(255, (byte)r, (byte)g, (byte)b);

            SolidColorBrush styleBrush = new SolidColorBrush(color);
            main.Resources["DefaultColor"] = styleBrush;

            SolidColorBrush styleBrush2 = new SolidColorBrush(styleHighlight);
            main.Resources["DefaultHighlightColor"] = styleBrush2;
        }
        public static void changeThemeColor(MainWindow main, string themeString)
        {
            Color color = getThemeColor(themeString);
            SolidColorBrush themeBrush = new SolidColorBrush(color);
            main.Resources["DefaultBackground"] = themeBrush;
            main.Resources["DefaultBackgroundOpaque"] = themeBrush;
            setThemeOpacity(main, themeString);
        }

    }//
}
