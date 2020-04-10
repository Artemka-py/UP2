using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using CryptLibraryING;

namespace AistWPF
{
    /// <summary>
    /// Логика взаимодействия для Connection_Form.xaml
    /// </summary>
    public partial class Connection_Form : Window
    {
        public Connection_Form()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Configuration_class configuration = new Configuration_class();
            configuration.ds = cbServers.SelectedItem.ToString();
            configuration.connection_checked += Configuration_connection_checked;
            Thread threadBases = new Thread(configuration.SQL_Data_Base_Checking);
            threadBases.Start();
        }

        private void Configuration_connection_checked(bool obj)
        {
            switch (obj)
            {
                case true:
                    MessageBox.Show("Проверка выполнена!");
                    Action action = () =>
                    {
                        Configuration_class configuration1 = new Configuration_class();
                        configuration1.Data_Base_Collection += Configuration_Data_Base_Collection;
                        Thread threadBases = new Thread(configuration1.SQL_Data_Base_Collection);
                        threadBases.Start();
                    };
                    Dispatcher.Invoke(action);
                    break;
                case false:
                    Configuration_class configuration = new Configuration_class();
                    configuration.server_Collection += Configuration_server_Collection;
                    Thread threadServers = new Thread(configuration.SQL_Server_Enumurator);
                    threadServers.Start();
                    break;
            }
        }

        private void Configuration_server_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                    cbServers.Items.Add(string.Format(@"{0}\{1}", r[0], r[1]));
                }
                cbServers.IsEnabled = true;
                btChecked.IsEnabled = true;
            };
            Dispatcher.Invoke(action);
        }

        private void Configuration_Data_Base_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                    cbDatabases.Items.Add(r[0]);
                }
                cbDatabases.IsEnabled = true;
                btChecked.IsEnabled = true;
            };
            Dispatcher.Invoke(action);
        }

        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            switch (cbDatabases.Text == "")
            {
                case true:
                    MessageBox.Show("Не выбрана нужная БД", "Продажа товара", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbDatabases.Focus();
                    break;
                case false:
                    Configuration_class configuration_Class = new Configuration_class();
                    configuration_Class.SQL_Server_Configuration_Set(cbServers.Text, cbDatabases.Text);
                    App.connect = true;
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                    break;
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Configuration_class configuration = new Configuration_class();
            configuration.server_Collection += Configuration_server_Collection;
            Thread threadServers = new Thread(configuration.SQL_Server_Enumurator);
            threadServers.Start();
        }

        private void btChecked_Click(object sender, RoutedEventArgs e)
        {
            System.Data.SqlClient.SqlConnection sql = new System.Data.SqlClient.SqlConnection(string.Format("Data Source = {0}; " +
            "Initial Catalog = {1}; Integrated Security = true;", 
                cbServers.Text, cbDatabases.Text));
            try
            {
                sql.Open();
                btConnect.IsEnabled = true;
            }
            catch
            {

            }
            finally
            {
                sql.Close();
            }
        }
    }
}
