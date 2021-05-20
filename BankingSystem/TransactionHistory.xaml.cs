using BankingSystem.BL;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Page
    {
        private readonly TransactionService transactionService;
        public TransactionHistory()
        {
            InitializeComponent();
            transactionService = new TransactionService();
            var trans = transactionService.GetAllTransactions();
            lst_trans.ItemsSource = trans;
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        private void btn_transHistory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Transaction.xaml", UriKind.Relative));
        }

        private void lst_trans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            var transId = Convert.ToUInt32(lst_trans.SelectedItem);
            transactionService.SelectTransaction(transId);
            var amount = transactionService.GetAmount();
            var fromAccount = transactionService.GetFromAccount();
            var toAccount = transactionService.GetToAccount();

            txt_fromAcc.Text = fromAccount.ToString();
            txt_toAcc.Text = toAccount.ToString();
            txt_amount.Text = string.Format(new CultureInfo("si-LK"), "{0 :N}", amount);

        }
    }
}
