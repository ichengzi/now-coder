using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace czTest
{
    class MutiThread_demo
    {
        public static void Main1()
        {
            //==============使用Thread
            Thread t1 = new Thread(new ThreadStart(TestMethod));
            Thread t2 = new Thread(new ParameterizedThreadStart(TestMethod));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Start();
            t2.Start("hello");//t1, t2 都是异步执行的
            Console.WriteLine("===============01--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑================");

            
            //================使用ThreadPool
            for (int i = 0; i < 2; i++)
            {
                //将工作项加入到线程池队列中，这里可以传递一个线程参数
                ThreadPool.QueueUserWorkItem(TestMethod, "Hello");
            }
            Console.WriteLine("===============02--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑================");

            
            //================使用Task
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            t.Start();
            t.Wait();
            Console.WriteLine(t.Result);

            var ext = Task.Delay(1000).ContinueWith(task =>Console.WriteLine(t.Result));
            Console.WriteLine("===============03--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑================");

            Console.ReadKey();
        }

        public static void TestMethod()
        {
            Console.WriteLine("不带参数的线程函数");
        }

        public static void TestMethod(object data)
        {
            Thread.Sleep(20);
            string datastr = data as string;
            var thStr = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("带参数的线程函数，参数为：{0} \t\t {1}", datastr??"参数为null",thStr);
        }

        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; --n)
                checked { sum += n; } //结果太大，抛出异常
            return sum;
        }
    }
}
