using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    public delegate string MyDelegate(string name);

    class delegate_demo
    {
        /*
         * https://msdn.microsoft.com/en-us/library/system.delegate(v=vs.110).aspx
         * https://msdn.microsoft.com/en-us/library/2e08f6yc(v=vs.110).aspx
         */

        static void Main1(string[] args)
        {
            MyDelegate mydelegate = new MyDelegate(HelloPeople);
            IAsyncResult result = mydelegate.BeginInvoke("chengzi", TestCallback, "Callback Param");
            Console.WriteLine("========================");

            Console.ReadKey();
        }

        //线程函数
        public static string HelloPeople(string data)
        {
            Console.WriteLine("hello "+data+" from func internal");
            return "hello "+ data;
        }

        //异步回调函数
        public static void TestCallback(IAsyncResult res)
        {
            var result = (AsyncResult)res;
            var caller = (MyDelegate)result.AsyncDelegate;
            string resultstr = caller.EndInvoke(result);//EndIovoke获取函数的返回值

            Console.WriteLine(resultstr+" from func return value");
            Console.WriteLine(res.AsyncState);
        }
    }
}
