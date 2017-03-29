using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class ref_demo
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("1");

            // ================================================================
            // 未使用ref时，传递引用参数时，是在  栈中  新建了一个  堆对象  的引用
            //test(sb);
            //&sb
            //0x0617eec4
            //    sb: 0x02a2116c
            //&sb
            //0x0617ee74 //栈中的新指针实例
            //    sb: 0x02a2116c
            //&sb
            //0x0617ee74
            //    sb: 0x02a41904
            //&sb
            //0x0617eec4
            //    sb: 0x02a2116c
            //Console.WriteLine(sb.ToString());
            // out: 1

            // ================================================================
            // 使用ref是，传递引用参数时，传递的是指针的指针，并没有在栈中新建  指向 堆对象 的指针实例
            //test(ref sb);
            //&sb
            //0x0589ed74
            //    sb: 0x02ba116c
            //&sb
            //0x0589ed74 //指针的指针
            //    sb: 0x02ba116c
            //&sb
            //0x0589ed74
            //    sb: 0x02bc1904
            //&sb
            //0x0589ed74
            //    sb: 0x02bc1904
            Console.WriteLine(sb.ToString());
            // out: 2

            //====================================================
            //var str = "1";
            //test(ref str);
            //Console.WriteLine(str);
            // out: 2


            Console.Read();
        }

        static void test(ref StringBuilder sb)
        {
            sb = new StringBuilder("2");
        }

        static void test(StringBuilder sb)
        {
            sb = new StringBuilder("2");
        }

        static void test(ref string sb)
        {
            sb = "2";
        }

        static void test(string sb)
        {
            sb = "2";
        }
    }
}
