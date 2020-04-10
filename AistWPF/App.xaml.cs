using System;
using System.Threading;
using System.Windows;
using CryptLibraryING;
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace AistWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string intID = "";
        public static string FIOSotr = "";
        public static Int32 intDropStatis = 0;
        public static string strStatus = "Null";
        public static bool connect = false;
    }
}
