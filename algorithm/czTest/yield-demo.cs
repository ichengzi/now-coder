using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class czList : IEnumerable
    {
        private int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public IEnumerator GetEnumerator()
        {
            yield return "Hello";
            yield return "World";
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    yield return array[i];
                else
                    yield break;

            }
        }
    }

    class demo
    {
        static void Main1()
        {
            var data = new czList();
            foreach (var item in data)
            {
                Console.WriteLine(item);//这里的item识别出来是object
            }
            //out:Hello
            //out:World
            //out:1
            //out:2
            //out:3
            //out:4
            //out:5

            var zz = new List<int>() { 1, 2, 3 };
            foreach (var item in zz)
            {
                Console.WriteLine(item);//这里已经识别出来int
            }

            Console.Read();
            Console.Read();
        }
    }
}
