using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace czTest
{
    class IncrementOperator_demo
    {
        public static void Main()
        {
            int i = 0;
            show(i++); //0,先传值，再自增
            show(++i); //2
            show(i); //2

            show1(age: 22);

            var nums = new int[] {1, 2, 3, 4};

            var stu = new stu();
            Console.WriteLine(stu.Name);

            showLast7777dayFiles();

            var pros = "zz".GetType().GetProperties();
            foreach (var pro in pros)
            {
                Console.WriteLine(pro.Name);
            }

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

        static void showLast7777dayFiles()
        {
            String myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var query =
                from pathname in Directory.GetFiles(myDocuments)
                let LastWriteTime = File.GetLastWriteTime(pathname)
                where LastWriteTime > (DateTime.Now - TimeSpan.FromDays(7777))
                orderby LastWriteTime 
                select new {Path = pathname, LastWriteTime}; // Set of anonymous type objects
            
                foreach (var file in query)
                    Console.WriteLine("LastWriteTime={0}, Path={1}", file.LastWriteTime, file.Path);
        }
    }



    public class stu
    {
        public string Name {
            get { return "chengzi"; }
        }
    }
}
