using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace remoteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("App.config", false);
            Console.WriteLine("Listening for requests. Press enter to exit...");
            Console.Read();
        }
    }

    
}
