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
    /// Interaction logic for Deposit.xaml
    /// </summary>
    public partial class Deposit : Page
    {
        private readonly AccountService accountSercive;
        public List<uint> Accounts { get; set; }

        public Deposit()
        {
            InitializeComponent();
            accountSercive = new AccountService();
            var accounts = accountSercive.GetAllAccounts(Global.CurrentUserId);
            Accounts = new List<uint>();
            Accounts.AddRange(accounts);
            cmb_accounts.ItemsSource = Accounts;
            cmb_accounts.SelectedIndex = 0;

        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

        }

        private void btn_newAccount_Click(object sender, RoutedEventArgs e)
        {
            var accountNo = accountSercive.CreateAccount();
            Accounts.Add(accountNo);
            cmb_accounts.SelectionChanged -= cmb_accounts_SelectionChanged;
            cmb_accounts.ItemsSource = null;
            cmb_accounts.SelectionChanged += cmb_accounts_SelectionChanged;
            cmb_accounts.ItemsSource = Accounts;
            cmb_accounts.SelectedItem = accountNo;

        }

        private void btn_save_deposit_Click(object sender, RoutedEventArgs e)
        {
            var accNo = Convert.ToUInt32(cmb_accounts.SelectedItem);
            var amnt = txt_amount.Text != "" ? Convert.ToUInt32(txt_amount.Text) : 0;
            try
            {
                if (amnt > 0)
                {
                    accountSercive.Deposit(accNo, amnt);
                    MessageBox.Show("Amount Successfully added.");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }

            txt_amount.Text = "";
            var balance = accountSercive.GetBalance(accNo);
            lbl_balance.Content = String.Format(new CultureInfo("si-LK"), "{0 :N}", balance);
        }

        private void txt_amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cmb_accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //accountSercive.SelectAccount(Convert.ToUInt32(cmb_accounts.SelectedItem));
            var balance = accountSercive.GetBalance(Convert.ToUInt32(cmb_accounts.SelectedItem));
            lbl_balance.Content = String.Format(new CultureInfo("si-LK"), "{0 :N}", balance);
        }
    }
}
