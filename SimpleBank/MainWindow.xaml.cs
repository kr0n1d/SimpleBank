using Homework_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Bank bank;
        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
            tbConsole.Text = bank.Logs.ToString();
            this.listCLients.ItemsSource = bank.listOfClients;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            CreationClient creation = new CreationClient(this);
            creation.Show();
        }

        private void btnNextDay_Click(object sender, RoutedEventArgs e)
        {
            var dateNow = bank.AddDay();
            listCLients.Items.Refresh();
            bank.Logs.Append($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}]: Изменение времени на {bank.dateNow.ToShortDateString()}.\n");
            tbConsole.Text = bank.Logs.ToString();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void ClickRemove(object sender, RoutedEventArgs e)
        {
            var client = listCLients.SelectedItem as Client;
            bank.listOfClients.Remove(client);
            bank.Logs.Append($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}]: Удаление клиента {client.FullName}.\n");
            tbConsole.Text = bank.Logs.ToString();
        }
    }
}
