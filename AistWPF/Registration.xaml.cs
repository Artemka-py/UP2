using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CryptLibraryING;
using HashDll;

namespace AistWPF
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            
        }

        private void btStag_Click(object sender, RoutedEventArgs e)
        {
            Table_Class tableClass = new Table_Class($"SELECT dbo.Proverka_Procenta({tbStajer.Text})");
            if (Convert.ToInt32(tableClass.table.Rows[0][0]) == 100)
            {
                tbStajer.IsEnabled = false;
                List<TextBox> tb = new List<TextBox>() { tbFam, tbIm, tbOtch, tbdate_Rojd, tbSer_Pas, tbNum_Pas, tbLogin };
                Table_Class dtStagirovka = new Table_Class("SELECT Stajirovka.First_Name_Stajera, Stajirovka.Middle_Name_Stajera, " +
                                                           "Stajirovka.Last_Name_Stajera, Stajirovka.Pasport_Series_Stajera, Stajirovka.Pasport_Number_Stajera " +
                                                           "FROM dbo.Stajirovka " +
                                                           $"WHERE ID_Stajirovka = {tbStajer.Text}");
                int i = 0;
                foreach (TextBox textBox in tb)
                {
                    textBox.IsEnabled = true;
                }

                foreach (TextBox textBox in tb.GetRange(0, 6))
                {
                    if (textBox.Name != tbdate_Rojd.Name)
                    {
                        textBox.Text = dtStagirovka.table.Rows[0][i].ToString();
                        i++;
                    }
                }

                tbPassword.IsEnabled = true;
                tbConfPassword.IsEnabled = true;
                btReg.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Вы не полностью прошли стажировку!!!", "ИНЖПРОМТОРГ", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Visibility = Visibility.Collapsed;
            }

        }

        private void btReg_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> tb = new List<TextBox>() { tbFam, tbIm, tbOtch, tbdate_Rojd, tbSer_Pas, tbNum_Pas, tbLogin };
            ArrayList field = new ArrayList() { DBNull.Value};
            Procedure_CLass procedureCLass = new Procedure_CLass();
            foreach (TextBox textBox in tb)
            {
                field.Add(textBox.Text);
            }
            HashClass hashClass = new HashClass();
            if (tbPassword.Password == tbConfPassword.Password)
                field.Add(hashClass.HashPassword(tbPassword.Password));
            else
            {
                MessageBox.Show("Не совпадают пароли!!!", "ИНЖПРОМТОРГ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            field.Add(DBNull.Value);
            field.Add(DBNull.Value);

            procedureCLass.procedure_Execution("Sotrudniki_IU", field);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
