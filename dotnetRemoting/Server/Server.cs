using System;
using System.Runtime.Remoting.Channels; //To support and handle Channel and channel sinks
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http; //For HTTP channel
using System.Runtime.Remoting.Channels.Tcp; //For HTTP channel
using System.IO;

namespace ServerApp
{
    //Service class
    public class Service : MarshalByRefObject
    {
        private int count=0;

        public int GetMax(int num1, int num2)
        {
            var max = Math.Max(num1, num2);
            Console.WriteLine("max of {0} and {1}: {2}", num1, num2, max);
            Console.WriteLine("call count: {0}",++count);
            return max;
        }
    }

    //Server Class
    public class Server
    {
        public static void Main()
        {
            //HttpChannel channel = new HttpChannel(8001); //Create a new channel
            TcpChannel channel = new TcpChannel(8001); //Create a new channel
            ChannelServices.RegisterChannel(channel,false); //Register channel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Service), "Service", WellKnownObjectMode.Singleton);
            Console.WriteLine("Server ON at port number:8001");
            Console.WriteLine("Please press enter to stop the server.");

            var data = channel.ChannelData as ChannelDataStore;
            foreach (var uri in data.ChannelUris)
            {
                Console.WriteLine("Chanel URI {0}",uri);
            }

            // Parse the channel's URI.
            //string[] urls = channel.GetUrlsForUri("Service");
            //if (urls.Length > 0)
            //{
            //    string objectUrl = urls[0];
            //    string objectUri;
            //    string channelUri = channel.Parse(objectUrl, out objectUri);
            //    Console.WriteLine("The object URL is {0}.", objectUrl);
            //    Console.WriteLine("The object URI is {0}.", objectUri);
            //    Console.WriteLine("The channel URI is {0}.", channelUri);
            //}
            

            Console.ReadLine();
        }
    }
}