using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__Path_Finder_2__shortest_path
{
    class Program
    {
        static void Main(string[] args)
        {

            string a = ".W.\n" +
                    ".W.\n" +
                    "...",

                b = ".W.\n" +
                    ".W.\n" +
                    "W..",

                c = "......\n" +
                    "......\n" +
                    "......\n" +
                    "......\n" +
                    "......\n" +
                    "......",

                d = "......\n" +
                    "......\n" +
                    "......\n" +
                    "......\n" +
                    ".....W\n" +
                    "....W.";


            StringBuilder sb = new StringBuilder();


            for (int t = 1; t <= 500; t++)
            {
                sb.Clear();

                for (int i = 0; i < t; i++)
                {
                    if (i != 0)
                    {
                        sb.Append("\n");
                    }
                    for (int j = 0; j < t; j++)
                    {
                        sb.Append(".");
                    }
                }

                DateTime dt = DateTime.Now;

                Console.WriteLine(Finder.PathFinder(sb.ToString()));
                Console.WriteLine("T:" + new TimeSpan(DateTime.Now.Ticks - dt.Ticks).TotalMilliseconds);

                dt = DateTime.Now;

                Console.WriteLine(Finder2.PathFinder(sb.ToString()));
                Console.WriteLine("T:" + new TimeSpan(DateTime.Now.Ticks - dt.Ticks).TotalMilliseconds);

                Console.WriteLine("----------------");
            }
            Console.Read();
        }
    }


    public class Finder
    {

        public class Node
        {
            public int i;
            public int j;
        }

        static int bound = 0;
        static string[] maze_array = null;
        static Queue<Node> path = null;

        public static int PathFinder(string maze)
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

            path.Enqueue(null);

            int w = 0;

            while (path.Count > 0)
            {
                objNode = path.Dequeue();

                if (objNode == null)
                {
                    w++;
                    if (path.Count != 0)
                    {
                        path.Enqueue(null);
                        continue;
                    }
                }
                else
                {
                    if (GetNextNode(objNode.i, objNode.j - 1) == true) return w;
                    if (GetNextNode(objNode.i, objNode.j + 1) == true) return w;
                    if (GetNextNode(objNode.i - 1, objNode.j) == true) return w;
                    if (GetNextNode(objNode.i + 1, objNode.j) == true) return w;
                }
            }

            return -1;
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



    public class Finder2
    {
        public static int PathFinder(string maze)
        {
            var isOpen = maze.Split('\n').Select(a => a.Select(b => b == '.').ToArray()).ToArray();
            var stepsNeeded = isOpen.Select(a => a.Select(b => 999).ToArray()).ToArray();
            Flood(0, 0, isOpen, stepsNeeded, 0);
            return stepsNeeded.Last().Last() < 999 ? stepsNeeded.Last().Last() : -1;
        }

        private static void Flood(int x, int y, bool[][] isOpen, int[][] stepsNeeded, int step)
        {
            if (isOpen[x][y] && stepsNeeded[x][y] > step)
            {
                stepsNeeded[x][y] = step;
                if (x > 0) Flood(x - 1, y, isOpen, stepsNeeded, step + 1);
                if (y > 0) Flood(x, y - 1, isOpen, stepsNeeded, step + 1);
                if (x < isOpen.GetLength(0) - 1) Flood(x + 1, y, isOpen, stepsNeeded, step + 1);
                if (y < isOpen.GetLength(0) - 1) Flood(x, y + 1, isOpen, stepsNeeded, step + 1);
            }
        }
    }
}
