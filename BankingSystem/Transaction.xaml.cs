using BankingSystem.BL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Page
    {

        private readonly TransactionService transactionService;
        private readonly AccountService accountService;
        public List<uint> Accounts { get; private set; }

        public Transaction()
        {
            InitializeComponent();
            transactionService = new TransactionService();
            accountService = new AccountService();
            var accounts = accountService.GetAllAccounts(BankServer.CurrentUserId);
            Accounts = new List<uint>();
            Accounts.AddRange(accounts);
            cmb_accounts_from.ItemsSource = cmb_accounts_to.ItemsSource = Accounts;
            cmb_accounts_from.SelectedIndex = 0;
            cmb_accounts_to.SelectedIndex = 0;
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }


        private void txt_amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cmb_accounts_from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_balance_from.Content = string.Format(new CultureInfo("si-LK"), "{0 :N}", GetBalance(Convert.ToUInt32(cmb_accounts_from.SelectedItem)));
        }
        private void cmb_accounts_to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            lbl_balance_to.Content = string.Format(new CultureInfo("si-LK"), "{0 :N}", GetBalance(Convert.ToUInt32(cmb_accounts_to.SelectedItem)));
        }

        private uint GetBalance(uint accNo)
        {
            return accountService.GetBalance(Convert.ToUInt32(accNo));

        }

        private void btn_save_transaction_Click(object sender, RoutedEventArgs e)
        {
            var fromAccNo = Convert.ToUInt32(cmb_accounts_from.SelectedItem);
            var toAccNo = Convert.ToUInt32(cmb_accounts_to.SelectedItem);
            var amnt = txt_amount.Text != "" ? Convert.ToUInt32(txt_amount.Text) : 0;
            try
            {

                if (amnt > 0)
                {
                    var transId = transactionService.CreateTransaction(fromAccNo, toAccNo, amnt);
                    MessageBox.Show("Transaction Added successfully. Trans ID: " + transId);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }

            txt_amount.Text = "";
        }

        private void btn_transHistory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("TransactionHistory.xaml", UriKind.Relative));

        }

        private void txt_amount_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
