using System;
using System.Runtime.Remoting;

namespace ServerApp
{

    public class Server 
    {
        private BankDB bankDB;

        public Server()
        {
            bankDB = new BankDB;
        }

        [STAThread]
        public static void Main()
        {
          
        }
    }
}

