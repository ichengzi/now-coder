using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class IncrementOperator_demo
    {
        public static void Main1()
        {
            int i = 0;
            show(i++);//0,先传值，再自增
            show(++i);//2
            show(i);//2

            show1(age: 22);

            var nums = new int[] { 1, 2, 3, 4 };
            Console.ReadKey();
        }

        static void show(int num)
        {
            Console.WriteLine(num);
        }

        //=================================

        static void show1(string name = "xx", int age = 0)
        {
            Console.WriteLine("{0},{1}", name, age);
        }
    }
}
