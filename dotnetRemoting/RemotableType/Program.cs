using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotableType
{
    public class RemotableType : MarshalByRefObject
    {
        public string SayHello()
        {
            Console.WriteLine("RemotableType.SayHello() was called!");
            return "Hello, world";
        }
    }
}
