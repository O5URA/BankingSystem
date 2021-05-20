using BankingSystem.BL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly Auth _authService;

        public Login()
        {
            InitializeComponent();
            if (_authService == null)
                _authService = new Auth();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_userId.Text)){
                try
                {
                    if (_authService.Login(Convert.ToUInt32(txt_userId.Text)))
                    {
                        this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

                    }
                    else
                    {
                        MessageBox.Show("Invalid User ID");
                        txt_userId.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            else
            {
                MessageBox.Show("Please enter user ID");
                txt_userId.Focus();
            }


        }

        private void txt_userId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txt_userId.Focus();
        }
    }
}
