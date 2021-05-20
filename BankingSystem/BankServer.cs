using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class BankServer
    {
        private BankDB.BankDB bankDB;
        public static BankDB.UserAccessInterface UserAccess { get; set; }
        public static BankDB.AccountAccessInterface AccountAccess { get; set; }
        public static BankDB.TransactionAccessInterface TransactionAccess { get; set; }
        public static BankDB.BankDB GetBankDB { get; set; }
        public static uint CurrentUserId { get; set; }

        public BankServer()
        {
            bankDB = new BankDB.BankDB();
            GetBankDB = bankDB;
            UserAccess = bankDB.GetUserAccess();
            AccountAccess = bankDB.GetAccountInterface();
            TransactionAccess = bankDB.GetTransactionInterface();
            
        }



        
       

    }
}
