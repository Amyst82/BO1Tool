using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace bo1tool
{
    public static class UIColors
    {
        private static Color getThemeColor(string themeString)
        {
            Color clr = (Color)ColorConverter.ConvertFromString("#FF0E0F1A");
            if (themeString == "Light")
            {
                clr = (Color)ColorConverter.ConvertFromString("#FFF5F5F5");
            }
            else if(themeString =="Dark")
            {
                clr = (Color)ColorConverter.ConvertFromString("#FF0E0F1A");
            }
            else if(themeString == "fncTheme")
            {
                clr = (Color)ColorConverter.ConvertFromString("#FF141414");
            }
            return clr;
        }
        private static void setThemeOpacity(string themeString)
        {
            //byte r = (byte)(color.R + (byte)50);
            Color opacityColor = (Color)ColorConverter.ConvertFromString("#19616191");
            SolidColorBrush themeOpacityBrush = new SolidColorBrush(opacityColor);
            if (themeString == "Light")
            {
                opacityColor = (Color)ColorConverter.ConvertFromString("#19919191");
            }
            else if (themeString == "Dark")
            {
                opacityColor = (Color)ColorConverter.ConvertFromString("#19616191");
            }
            else if (themeString == "fncTheme")
            {
                opacityColor = (Color)ColorConverter.ConvertFromString("#19919191");
            }
            Application.Current.Resources["DefaultBackgroundOpacity"] = themeOpacityBrush;
        }
        public static void changeThemeColor(MainWindow main, string themeString)
        {
            Color color = getThemeColor(themeString);
            SolidColorBrush themeBrush = new SolidColorBrush(color);
            main.Resources["DefaultBackground"] = themeBrush;
            main.Resources["DefaultBackgroundOpaque"] = themeBrush;
            setThemeOpacity(themeString);
        }

    }//
}
