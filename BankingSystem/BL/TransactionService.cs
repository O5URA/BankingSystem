using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.BL
{
    class TransactionService
    {
        public uint CreateTransaction(uint fromAccNo, uint toAccNo, uint amnt)
        {
            var transactionId = Global.TransactionAccess.CreateTransaction();
            Global.TransactionAccess.SetAmount(amnt);
            Global.TransactionAccess.SetSendr(fromAccNo);
            Global.TransactionAccess.SetRecvr(toAccNo);

            return transactionId;

        }

        internal List<uint> GetAllTransactions()
        {
            return Global.TransactionAccess.GetTransactions();
        }
        internal void SelectTransaction(uint transId)
        {
            Global.TransactionAccess.SelectTransaction(transId);
        }

        internal  uint GetAmount()
        {
            return Global.TransactionAccess.GetAmount();
        }

        internal uint GetFromAccount()
        {
            return Global.TransactionAccess.GetSendrAcct();
        }

        internal uint GetToAccount()
        {
            return Global.TransactionAccess.GetRecvrAcct();
        }
    }
}
