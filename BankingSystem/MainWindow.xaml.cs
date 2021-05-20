using BankingSystem.BL;
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

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly Global global;
        public MainWindow()
        {
            InitializeComponent();
            global = new Global();
            _NavigationFrame.Navigate(new Login());
        }

       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Global.GetBankDB.ProcessAllTransactions();
                Global.GetBankDB.SaveToDisk();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
         
        }
    }
}
