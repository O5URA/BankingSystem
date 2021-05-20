using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BankingSystem.BL
{
    class AccountService
    {
        public uint CreateAccount()
        {
            var accountNo = Global.AccountAccess.CreateAccount(Global.CurrentUserId);
            MessageBox.Show("New Account Created Successfully. Account Number : " + accountNo);
            return accountNo;
        }

        public void Deposit(uint accountNo, uint amount)
        {
            Global.AccountAccess.SelectAccount(accountNo);
            Global.AccountAccess.Deposit(amount);
        }

        public void SelectAccount(uint accountNo)
        {
            Global.AccountAccess.SelectAccount(accountNo);
        }

        public uint GetBalance(uint accountNo)
        {
            Global.AccountAccess.SelectAccount(accountNo);
            return Global.AccountAccess.GetBalance();
        }

        internal void Withdraw(uint accNo, uint amnt)
        {
            Global.AccountAccess.SelectAccount(accNo);
            Global.AccountAccess.Withdraw(amnt);
        }

        internal List<uint> GetAllAccounts(uint currentUserId)
        {
            return Global.AccountAccess.GetAccountIDsByUser(Global.CurrentUserId);
        }
    }
}
