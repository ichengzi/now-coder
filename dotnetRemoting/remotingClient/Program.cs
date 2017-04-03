using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace remotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("App.config");
            RemotableType.RemotableType remoteObject = new RemotableType.RemotableType();
            Console.WriteLine(remoteObject.SayHello());
            Console.Read();
        }
    }
}
