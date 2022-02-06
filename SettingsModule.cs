using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace bo1tool
{
    public class toolSets : json<toolSets>
    {
        public string Theme { get; set; }
        public string StyleColor { get; set; }
    }
    public static class toolSettings
    {
        public static void saveSets(MainWindow main)
        {
            toolSets ds = new toolSets();
            ds.Theme = UIColors.getTheme(main);
            ds.StyleColor = UIColors.getStyleColorString(main);
            ds.Save(@"C:\Users\sergi\source\repos\Amyst82\BO1Tool\bin\Debug\settings.cache");
        }
        public static void loadSets(MainWindow main)
        {
            toolSets ds = toolSets.Load(@"C:\Users\sergi\source\repos\Amyst82\BO1Tool\bin\Debug\settings.cache");
            UIColors.changeStyleColorFromString(main, ds.StyleColor);
            UIColors.changeThemeColor(main, ds.Theme);
        }
    }
}
