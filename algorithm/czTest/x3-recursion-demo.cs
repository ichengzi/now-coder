using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class x3_recursion_demo
    {
        // 数字规律，输出第20个数
        // 1,1,2,3,5,8,13.................
        //
        public static void Main1()
        {
            var xx = Func(Tuple.Create<int,int>(1,1));

            Console.WriteLine(xx);

            var yy = Func2(1,1);
            Console.WriteLine(yy);
            Console.Read();

        }

        private static int count = 2;
        private static int count2 = 2;
        public static Tuple<int, int> Func(Tuple<int, int> nums)
        {
            if (count < 20)
            {
                count++;
                var tmp = Tuple.Create<int, int>(nums.Item2, nums.Item1 + nums.Item2);
                Console.Write(count+":\t");
                Console.WriteLine(tmp.Item2);
                return Func(tmp);
            }
            return nums;
        }


        public static int Func2(int num1, int num2)
        {
            if (count2 < 20)
            {
                count2++;
                Console.WriteLine(num1+num2);
                return Func2(num2,num1+num2);
            }
            return num2;
        }
    }


}
