using System;
using System.Collections.Generic;

namespace _5_kyu_Josephus_Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JosSurvivor(7, 300));
        }

        public static int JosSurvivor(int n, int k)
        {
            LinkedList<int> l = new LinkedList<int>();
            int i = 1;
            int c = 0;
            LinkedListNode<int> node = null;


            while (true)
            {
                if (i <= n)
                {
                    l.AddLast(i);
                    
                }
                
                if ((i >= n) && (l.Count == 1)) return l.First.Value;

                i++;

                node = (node == null) ? l.First : (node.Next == null) ? l.First : node.Next;
                c++;
                if (c == k)
                {
                    LinkedListNode<int> node2 = (node.Previous == null) ? l.Last : node.Previous;
                    l.Remove(node);
                    node = node2;
                    c = 0;
                }
            }
        }
    }
}
