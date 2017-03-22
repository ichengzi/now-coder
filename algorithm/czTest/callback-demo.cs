using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{

    public delegate bool CallBack(int hwnd, int lParam);

    public class EnumReportApp
    {
        [DllImport("user32")]
        public static extern int EnumWindows(CallBack x, int y);

        [DllImport("user32")]
        public static extern int EnumWindows(Func<int, int, bool> action, int y);

        public static void Main1()
        {
            CallBack myCallBack = new CallBack(EnumReportApp.Report);
            EnumWindows(myCallBack, 1024);
            // 1024这个参数经EnumWindows这个函数输入，
            // 再经EnumWindows传送到callback中，
            // callBack就可以处理
            // callBack返回值，传送到EnumWindows中，false结束枚举窗口
            // 代码执行桟，重新回到Main函数中

            /*
             * 无法封送泛型类型 
            */
            //EnumWindows(new Func<int,int,bool>((hwnd,param) => 
            //{
            //    Console.Write("Window handle is ");
            //    Console.WriteLine(hwnd + "\t\t\t\t\t\t" + param);
            //    if (hwnd > 100000)
            //        return false;
            //    return true;
            //}),1023);
            Console.Read();
        }

        public static bool Report(int hwnd, int lParam)
        {
            Console.Write("Window handle is ");
            Console.WriteLine(hwnd + "\t\t\t\t\t\t" + lParam);
            if (hwnd > 100000)
                return false;
            return true;
        }
    }
}
