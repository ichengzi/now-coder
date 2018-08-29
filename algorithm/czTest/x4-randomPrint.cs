using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class x4_randomPrint
    {
        public static void Main1()
        {
            var a = new Int32();
            var ran = new Random();
            var nums1 = new int[] {1, 2, 3, 4, 5, 6};

            var nums = nums1.ToList();
            var count = nums.Count;
            for (int i = 0; i < count; i++)
            {
                var index = ran.Next(0,nums.Count-1);

                Console.WriteLine(nums[index]);

                nums.RemoveAt(index);
            }

            Console.Read();
        }

    }
}
