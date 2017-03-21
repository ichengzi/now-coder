using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace test
{
    // type parameter T in angle brackets
    public class GenericList<T>
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
        //static void Main()
        //{
        //    // int is the type argument
        //    GenericList<int> list = new GenericList<int>();

        //    for (int x = 0; x < 10; x++)
        //    {
        //        list.AddHead(x);
        //    }

        //    foreach (int i in list)
        //    { 
        //        System.Console.Write(i + " ");
        //    }
        //    System.Console.WriteLine("\nDone");

        //    System.Console.Read();
        //    System.Console.Read();
        //    System.Console.Read();
        //}

        static void Main()
        {
            ArrayList list = new ArrayList();
            list.Add(5);
            list.Add(7);
            Example(list);
        }

        static void Example(ArrayList list)
        {
            list.AddRange(list);

            list.Add("aaa");
            list.Add("ccz");

            new List<int>().BinarySearch(2);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
    } 
}