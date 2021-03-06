using BankDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BankingSystem.BL
{
    
    public class Auth
    {

  
        public uint CreateAccount(string fname, string lname)
        {
            var userId = BankServer.UserAccess.CreateUser();
            BankServer.UserAccess.SetUserName(fname, lname);
            return userId;
        }

        public bool Login(uint userId)
        {
            try
            {
                var users = BankServer.UserAccess.GetUsers();
                if (users.Contains(userId))
                {
                    BankServer.UserAccess.SelectUser(userId);
                    BankServer.CurrentUserId = userId;
                    return true;
                }
                else
                {
                    return false;
                }

               
            }
            catch (Exception ee)
            {

                throw ee;
            }         
        }

        public string GetCurrentUser()
        {
            try
            {
                string fname; string lname;
                BankServer.UserAccess.GetUserName(out fname, out lname);
                return fname + " " + lname;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        
    }
}
