using BankingSystem.BL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly Auth _authService;

        public MainPage()
        {
            InitializeComponent();
            if (_authService == null)
                _authService = new Auth();
            lbl_userId.Content = _authService.GetCurrentUser();
        }

        private void btn_deposit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Deposit.xaml", UriKind.Relative));
        }

        private void btn_withdraw_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Withdraw.xaml", UriKind.Relative));

        }

        private void btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Transaction.xaml", UriKind.Relative));
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BankServer.GetBankDB.ProcessAllTransactions();
                BankServer.GetBankDB.SaveToDisk();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}
