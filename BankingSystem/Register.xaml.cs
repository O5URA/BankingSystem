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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private readonly Auth _authService;
        public Register()
        {
            InitializeComponent();
            if (_authService == null)
                _authService = new Auth();
        }

        private void btn_createAccount_Click(object sender, RoutedEventArgs e)
        {
           var userId =  _authService.CreateAccount(txt_fname.Text, txt_lname.Text);
            Global.CurrentUserId = userId;
            MessageBox.Show("Account Created Successfully. Your user ID is " + userId + ". Use this ID to login your account");
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txt_fname.Focus();
        }
    }
}
