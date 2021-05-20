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
            var accountNo = BankServer.AccountAccess.CreateAccount(BankServer.CurrentUserId);
            MessageBox.Show("New Account Created Successfully. Account Number : " + accountNo);
            return accountNo;
        }

        public void Deposit(uint accountNo, uint amount)
        {
            BankServer.AccountAccess.SelectAccount(accountNo);
            BankServer.AccountAccess.Deposit(amount);
        }

        public void SelectAccount(uint accountNo)
        {
            BankServer.AccountAccess.SelectAccount(accountNo);
        }

        public uint GetBalance(uint accountNo)
        {
            BankServer.AccountAccess.SelectAccount(accountNo);
            return BankServer.AccountAccess.GetBalance();
        }

        internal void Withdraw(uint accNo, uint amnt)
        {
            BankServer.AccountAccess.SelectAccount(accNo);
            BankServer.AccountAccess.Withdraw(amnt);
        }

        internal List<uint> GetAllAccounts(uint currentUserId)
        {
            return BankServer.AccountAccess.GetAccountIDsByUser(BankServer.CurrentUserId);
        }
    }
}
