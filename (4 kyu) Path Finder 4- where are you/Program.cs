using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;


namespace _4_kyu__Path_Finder_4__where_are_you
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(PathFinder.iAmHere("RLrl"));
            Console.WriteLine(PathFinder.iAmHere("r5L2l4"));
            Console.WriteLine(PathFinder.iAmHere("r5L2l4"));
            Console.WriteLine(PathFinder.iAmHere("10r5r0"));
            Console.WriteLine(PathFinder.iAmHere("10r5r0"));
            Console.WriteLine(PathFinder.iAmHere("229LLr314lrrrl439lLrRLrrRrRllrRl347LrR"));
            Console.WriteLine(PathFinder.iAmHere("RL708rRllL670RRrL"));
            Console.Read();
        }
    }

    public class PathFinder
    {

        // 0:N 1:E 2:S 3:W
        static int direction_index = 3;
        static Point objPoint = new Point(0, 0);

        public static Point iAmHere(string path)
        {
            path = path.Replace("L", " L ");
            path = path.Replace("l", " l ");
            path = path.Replace("R", " R ");
            path = path.Replace("r", " r ");

            string[] path_array = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string objPath in path_array)
            {
                if ("LR".IndexOf(objPath) > -1)
                {
                    direction_index += 2;
                }
                else if ("l".IndexOf(objPath) > -1)
                {
                    direction_index -= 1;
                }
                else if ("r".IndexOf(objPath) > -1)
                {
                    direction_index += 1;
                }
                else
                {
                    if (direction_index == 0)
                    {
                        objPoint.Y += Convert.ToInt32(objPath);
                    }
                    else if (direction_index == 1)
                    {
                        objPoint.X += Convert.ToInt32(objPath);
                    }
                    else if (direction_index == 2)
                    {
                        objPoint.Y -= Convert.ToInt32(objPath);
                    }
                    else if (direction_index == 3)
                    {
                        objPoint.X -= Convert.ToInt32(objPath);
                    }
                }

                if (direction_index > 3)
                {
                    direction_index = direction_index - 4;
                }
                else if (direction_index < 0)
                {
                    direction_index = 4 + direction_index;
                }
            }

            return objPoint;
        }
    }
}
