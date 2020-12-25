using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Homework_13;

namespace SimpleBank
{
    /// <summary>
    /// Логика взаимодействия для CreationClient.xaml
    /// </summary>
    public partial class CreationClient : Window
    {
        private MainWindow mainWindow;
        public CreationClient(MainWindow w)
        {
            InitializeComponent();
            mainWindow = w;
        }

        private void CLickOk(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbFullName.Text))
            {
                MessageBox.Show(" Поле \"Полное имя\" не должно быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(tbSalary.Text))
            {
                MessageBox.Show("Поле \"Начальный капитал\" не должно быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (decimal.TryParse(tbSalary.Text, out decimal startCapital))
            {
                bool capitalization = rWIth.IsChecked.Value;
                string name = tbFullName.Text;
                if (rPhiz.IsChecked.Value)
                {
                    mainWindow.bank.AddClient(new Individual(name, capitalization, startCapital));
                }
                else if (rVIP.IsChecked.Value)
                {
                    mainWindow.bank.AddClient(new VIP(name, capitalization, startCapital));
                }
                else
                {
                    mainWindow.bank.AddClient(new LegalEntity(name, capitalization, startCapital));
                }
                mainWindow.tbConsole.Text = mainWindow.bank.Logs.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле \"Начальный капитал\" должно быть из цифр!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
