using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    /* what happened when call new */
    class happendWhenCallNew
    {
        public static void Main()
        {
            var a = new A3();
            Console.Read();
            // out put:
            //A1 come
            //A2 come
            //A3 come
            // 调用顺序，从object到派生到派生，直到最终类自己的构造函数
        }
    }

    public class A1
    {
        public A1()
        {
            Console.WriteLine("A1 come");
        }
    }

    public class A2:A1
    {
        public A2()
        {
            Console.WriteLine("A2 come");
        }
    }

    public class A3 : A2
    {
        public A3()
        {
            Console.WriteLine("A3 come");
        }
    }
}
