using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace RemotingApp
{
    [STAThread]
    class Program
    {
        public class ClientApp
        {
            TcpChannel ch = new TcpChannel();  
            remoteclass.xx obj = new remoteclass.xx();
            public static void Main(string[] args)
            {
                ChannelServices.RegisterChannel(ch);  
                obj = (remoteclass.xx)Activator.GetObject(typeof(remoteclass.xx),
                               "tcp://localhost:8085/rahul");
                int x = 1;
                int y = 2;
                Console.WriteLine((obj.sum(x, y)).ToString());
            }
        }
    }
}
