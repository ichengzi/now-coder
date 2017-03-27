using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace test
{
    // type parameter T in angle brackets
    public class GenericList<T> where T:struct, IComparable
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node head;
        public GenericList()
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main1()
        {
            // int is the type argument
            GenericList<int> list = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }
            System.Console.WriteLine("\nDone");
            //Console.WriteLine(f(5));//递归调用

            System.Console.Read();
            System.Console.Read();
            System.Console.Read();
        }

        static int f(int num)
        {
            if (num < 2)
                return num;
            else
                return f(num - 1) + f(num - 2);
        }
    }
}