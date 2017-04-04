using System;
using System.Runtime.Remoting.Channels; //To support and handle Channel and channel sinks
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http; //For HTTP channel
using System.Runtime.Remoting.Channels.Tcp; //For HTTP channel
using System.IO;
using ServerApp;

namespace RemotingApp
{
    public class ClientApp
    {
        public static void Main(string[] args)
        {
            //HttpChannel channel = new HttpChannel(8002); //Create a new channel
            TcpChannel channel = new TcpChannel(8002); //Register the channel
            //Create Service class object
            //Service svc = (Service)Activator.GetObject(typeof(Service), "http://Localhost:8001/Service"); //Localhost can be replaced by 
            Service svc = (Service)Activator.GetObject(typeof(Service), "tcp://Localhost:8001/Service"); //Localhost can be replaced by 
            //Pass Message
            Console.WriteLine(svc.GetMax(10, 20));
            Console.WriteLine(svc.GetMax(1, 20));
            Console.WriteLine(svc.GetMax(22, 20));

            Console.Read();
        }
    }
}