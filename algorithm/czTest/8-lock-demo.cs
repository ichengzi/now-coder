﻿using System;
using System.IO;
using System.Text;

namespace IP
{
    class IP
    {
        /*
         * 当对同一个资源进行读写的时候，我们要使该资源在同一时刻只能被一个线程操作，以确保每个操作都是有效即时的，也即保证其操作的原子性.
         * 
         * 通常使用方式，用一个私有的引用变量来做锁定标识： readonly object @lock = new object();
         */
        // lock(objectA){codeB} 看似简单，实际上有三个意思，这对于适当地使用它至关重要：
        // 1. objectA被lock了吗？没有则由我来lock，否则一直等待，直至objectA被释放。
        // 2. lock以后在执行codeB的期间其他线程不能调用codeB，也不能使用objectA。
        // 3. 执行完codeB之后释放objectA，并且codeB可以被其他线程访问。

        private static void Main1(string[] args)
        {
            var a = new Int32();
            var b = default(Int32);
            var c = a == b;

            IP.EnableFileWatch = true;
            IP.Load("17monipdb.dat");

            var s1 = IP.Find("8.8.8.8");
            var s2 = IP.Find("255.255.255.255");
            var s3 = IP.Find("114.114.114.114");
            Console.WriteLine(string.Join("\n", s1));
            Console.WriteLine(string.Join("\n", s2));
            Console.WriteLine(string.Join("\n", s3));
            Console.ReadKey(true);
        }

        public static bool EnableFileWatch = false;

        private static int offset;
        private static uint[] index = new uint[256];
        private static byte[] dataBuffer;
        private static byte[] indexBuffer;
        private static long lastModifyTime = 0L;
        private static string ipFile;
        private static readonly object @lock = new object();

        public static void Load(string filename)
        {
            ipFile = new FileInfo(filename).FullName;
            Load();
            if (EnableFileWatch)
            {
                Watch();
            }
        }

        public static string[] Find(string ip)
        {
            lock (@lock)
            {
                var ips = ip.Split('.');
                var ip_prefix_value = int.Parse(ips[0]);
                long ip2long_value = BytesToLong(byte.Parse(ips[0]), byte.Parse(ips[1]), byte.Parse(ips[2]),
                    byte.Parse(ips[3]));
                var start = index[ip_prefix_value];
                var max_comp_len = offset - 1028;
                long index_offset = -1;
                var index_length = -1;
                byte b = 0;
                for (start = start * 8 + 1024; start < max_comp_len; start += 8)
                {
                    if (
                        BytesToLong(indexBuffer[start + 0], indexBuffer[start + 1], indexBuffer[start + 2],
                            indexBuffer[start + 3]) >= ip2long_value)
                    {
                        index_offset = BytesToLong(b, indexBuffer[start + 6], indexBuffer[start + 5],
                            indexBuffer[start + 4]);
                        index_length = 0xFF & indexBuffer[start + 7];
                        break;
                    }
                }
                var areaBytes = new byte[index_length];
                Array.Copy(dataBuffer, offset + (int)index_offset - 1024, areaBytes, 0, index_length);
                return Encoding.UTF8.GetString(areaBytes).Split('\t');
            }
        }

        private static void Watch()
        {
            var file = new FileInfo(ipFile);
            if (file.DirectoryName == null) return;
            var watcher = new FileSystemWatcher(file.DirectoryName, file.Name) { NotifyFilter = NotifyFilters.LastWrite };
            watcher.Changed += (s, e) =>
            {
                var time = File.GetLastWriteTime(ipFile).Ticks;
                if (time > lastModifyTime)
                {
                    Load();
                }
            };
            watcher.EnableRaisingEvents = true;
        }

        private static void Load()
        {
            lock (@lock)
            {
                var file = new FileInfo(ipFile);
                lastModifyTime = file.LastWriteTime.Ticks;
                try
                {
                    dataBuffer = new byte[file.Length];
                    using (var fin = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        fin.Read(dataBuffer, 0, dataBuffer.Length);
                    }

                    var indexLength = BytesToLong(dataBuffer[0], dataBuffer[1], dataBuffer[2], dataBuffer[3]);
                    indexBuffer = new byte[indexLength];
                    Array.Copy(dataBuffer, 4, indexBuffer, 0, indexLength);
                    offset = (int)indexLength;

                    for (var loop = 0; loop < 256; loop++)
                    {
                        index[loop] = BytesToLong(indexBuffer[loop * 4 + 3], indexBuffer[loop * 4 + 2],
                            indexBuffer[loop * 4 + 1],
                            indexBuffer[loop * 4]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static uint BytesToLong(byte a, byte b, byte c, byte d)
        {
            return ((uint)a << 24) | ((uint)b << 16) | ((uint)c << 8) | d;
        }
    }
}