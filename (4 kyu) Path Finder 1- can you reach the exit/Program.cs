using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__Path_Finder_1__can_you_reach_the_exit
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            Random r = new Random();

            for (int i = 0; i < 1000; i++)
            {
                if (i != 0)
                {
                    sb.Append("\n");
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (r.Next(0, 100) >= -1)
                    {
                        sb.Append(".");
                    }
                    else
                    {
                        sb.Append("W");
                    }
                }
            }

            DateTime d;

            d = DateTime.Now;
            Console.WriteLine(Finder.PathFinder(sb.ToString()));
            Console.WriteLine(new TimeSpan(DateTime.Now.Ticks - d.Ticks).TotalSeconds);

            d = DateTime.Now;
            Console.WriteLine(Finder_Text_Split.PathFinder(sb.ToString()));
            Console.WriteLine(new TimeSpan(DateTime.Now.Ticks - d.Ticks).TotalSeconds);

            Console.ReadKey();
        }

        //Object-Oriented
        public class Node
        {
            public int i;
            public int j;
        }
        public class Finder
        {

            static int bound = 0;
            static string[] maze_array = null;
            static Queue<Node> path = null;

            public static bool PathFinder(string maze)
            {
                maze_array = maze.Split('\n');
                bound = maze_array.Length;

                Node objNode;

                path = new Queue<Node>();

                path.Enqueue(new Node()
                {
                    i = -1,
                    j = 0,
                });

                while (path.Count > 0)
                {
                    objNode = path.Dequeue();
                    if (GetNextNode(objNode.i, objNode.j - 1) == true) return true;
                    if (GetNextNode(objNode.i, objNode.j + 1) == true) return true;
                    if (GetNextNode(objNode.i - 1, objNode.j) == true) return true;
                    if (GetNextNode(objNode.i + 1, objNode.j) == true) return true;
                }

                return false;
            }

            public static Boolean GetNextNode(int i, int j)
            {
                if ((i < 0) || (i >= bound))
                {
                    return false;
                }
                if ((j < 0) || (j >= bound))
                {
                    return false;
                }

                char[] ch = maze_array[i].ToCharArray();

                if (i == bound - 1 && j == bound - 1)
                {
                    return true;
                }

                if ((ch[j] == 'P') || ch[j] == 'W')
                {
                    return false;
                }

                ch[j] = 'P';
                maze_array[i] = new string(ch);

                path.Enqueue(new Node()
                {
                    i = i,
                    j = j,
                });

                return false;
            }
        }
        //Slower
        public class Finder_Text_Split
        {

            static int bound = 0;
            static string[] maze_array = null;
            static Queue<string> path = null;

            public static bool PathFinder(string maze)
            {
                maze_array = maze.Split('\n');
                bound = maze_array.Length;

                string objNode;
                int i, j;

                path = new Queue<string>();

                path.Enqueue("-1,0");

                while (path.Count > 0)
                {
                    objNode = path.Dequeue();
                    i = Convert.ToInt32(objNode.Split(',')[0]);
                    j = Convert.ToInt32(objNode.Split(',')[1]);

                    if (GetNextNode(i, j - 1) == true) return true;
                    if (GetNextNode(i, j + 1) == true) return true;
                    if (GetNextNode(i - 1, j) == true) return true;
                    if (GetNextNode(i + 1, j) == true) return true;
                }

                return false;
            }

            public static Boolean GetNextNode(int i, int j)
            {
                if ((i < 0) || (i >= bound))
                {
                    return false;
                }
                if ((j < 0) || (j >= bound))
                {
                    return false;
                }

                char[] ch = maze_array[i].ToCharArray();

                if (i == bound - 1 && j == bound - 1)
                {
                    return true;
                }

                if ((ch[j] == 'P') || ch[j] == 'W')
                {
                    return false;
                }

                ch[j] = 'P';
                maze_array[i] = new string(ch);

                path.Enqueue(i + "," + j);

                return false;
            }
        }

    }
}
