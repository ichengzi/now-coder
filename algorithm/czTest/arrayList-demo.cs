using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class arrayList_demo
    {
        static void Example(ArrayList list)
        {
            list.AddRange(list);

            list.Add("aaa");
            list.Add("ccz");

            new List<int>().BinarySearch(2);

            foreach (var i in list)
            {
                Console.Write(i.GetType().Name);
                Console.WriteLine(i);//i 是 object类型
            }

            Console.Read();
        }

        static void Main1()
        {
            ArrayList list = new ArrayList();
            list.Add(5);
            list.Add(7);
            Example(list);

            Console.Read();
            Console.Read();
        }
    }
}
