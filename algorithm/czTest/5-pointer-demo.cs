using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class pointer_demo
    {
        public static void Main1()
        {
            //// Normal pointer to an object.  
            //int[] a = new int[5] { 10, 20, 30, 40, 50 };
            //// Must be in unsafe code to use interior pointers.  
            //unsafe
            //{
            //    // Must pin object on heap so that it doesn't move while using interior pointers.  
            //    fixed (int* p = &a[0])
            //    {
            //        // p is pinned as well as object, so create another pointer to show incrementing it.  
            //        int* p2 = p;
            //        Console.WriteLine(*p2);
            //        // Incrementing p2 bumps the pointer by four bytes due to its type ...  
            //        p2 += 1;
            //        Console.WriteLine(*p2);
            //        p2 += 1;
            //        Console.WriteLine(*p2);
            //        Console.WriteLine("--------");
            //        Console.WriteLine(*p);
            //        // Deferencing p and incrementing changes the value of a[0] ...  
            //        *p += 1;
            //        Console.WriteLine(*p);
            //        *p += 1;
            //        Console.WriteLine(*p);


            //        var xx = DateTime.Now;
            //        DateTime* date = &xx;
            //        Console.WriteLine(date->Millisecond);
            //    }
            //}

            //Console.WriteLine("--------");
            //Console.WriteLine(a[0]);
            //Console.ReadLine();

            // Output:  
            //10  
            //20  
            //30  
            //--------  
            //10  
            //11  
            //12  
            //--------  
            //12  

            uint xxx = 5;
            int yy = (int)xxx;

            int b =0, c = 0;
            uint a = b == c ? 0U : 1U;

        }
    }
}
