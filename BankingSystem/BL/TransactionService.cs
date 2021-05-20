using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.BL
{
    class TransactionService
    {
        public uint CreateTransaction(uint fromAccNo, uint toAccNo, uint amnt)
        {
            var transactionId = BankServer.TransactionAccess.CreateTransaction();
            BankServer.TransactionAccess.SetAmount(amnt);
            BankServer.TransactionAccess.SetSendr(fromAccNo);
            BankServer.TransactionAccess.SetRecvr(toAccNo);

            return transactionId;

        }

        internal List<uint> GetAllTransactions()
        {
            return BankServer.TransactionAccess.GetTransactions();
        }
        internal void SelectTransaction(uint transId)
        {
            BankServer.TransactionAccess.SelectTransaction(transId);
        }

        internal  uint GetAmount()
        {
            return BankServer.TransactionAccess.GetAmount();
        }

        internal uint GetFromAccount()
        {
            return BankServer.TransactionAccess.GetSendrAcct();
        }

        internal uint GetToAccount()
        {
            return BankServer.TransactionAccess.GetRecvrAcct();
        }
    }
}
