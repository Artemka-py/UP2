using System;
using System.Threading;
using System.Windows;
using CryptLibraryING;
using HashDll;
using Microsoft.Win32;

namespace AistWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Mutex _instanse;
        private const string _app_name = "ИНЖПРОМТОРГ";


        public MainWindow()
        {
            try
            {
                Configuration_class configuration = new Configuration_class();
                configuration.SQL_Server_Configuration_get();
                Configuration_class.connection.Open();
                App.connect = true;
            }
            catch
            {
                Connection_Form conection = new Connection_Form();
                conection.ShowDialog();
            }
            finally
            {
                Configuration_class.connection.Close();
                switch (App.connect)
                {
                    case false:
                        MessageBox.Show("Ошибка подключения", "ИНЖПРОМТОРГ", MessageBoxButton.OK, MessageBoxImage.Error);
                        Environment.Exit(0);
                        break;
                    case true:
                        try
                        {
                            InitializeComponent();
                        }
                        catch { }
                        break;
                }
            }
        }

        private void btReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }

        private void btEnter_Click(object sender, RoutedEventArgs e)
        {
            string Login = tbLogin.Text;
            string Password = tbPassword.Password;
            
            Table_Class @class = new Table_Class($"select ID_Sotrudnika, Sotrudnika_Password from Sotrudniki where Sotrudnika_Login = '{Login}' ");

            try
            {
                if (@class.table.Rows[0][0] != DBNull.Value)
                {
                    HashClass hashClass = new HashClass();
                    bool Proverka = hashClass.VerifyHashedPassword(@class.table.Rows[0][1].ToString(), Password);
                    if (Proverka)
                    {
                        Table_Class tableClass = new Table_Class($"select dbo.Auth('{Login}','{@class.table.Rows[0][1]}')");
                        string Acess = tableClass.table.Rows[0][0].ToString();
                        App.intID = @class.table.Rows[0][0].ToString();
                        MessageBox.Show("Vse zbs", "ИНЖПРОМТОРГ", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Не правильно введен логин или пароль!!!", "ИНЖПРОМТОРГ", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        tbPassword.Password = "";
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Не правильно введен логин или пароль!!!", "ИНЖПРОМТОРГ", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    tbPassword.Password = "";
            }
            
            
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
