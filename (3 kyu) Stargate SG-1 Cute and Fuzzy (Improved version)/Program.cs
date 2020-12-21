using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_kyu__Stargate_SG_1_Cute_and_Fuzzy__Improved_version_
{
    class Program
    {
        static void Main(string[] args)
        {
            var existingWires = ".S.\n" +
"...\n" +
".G.";

            Console.WriteLine(SG1.WireDHD(existingWires));
        }

        public class SG1
        {

            static string[,] map;
            static string[,] map_copy;

            public static string WireDHD(string existingWires)
            {

                string[] arr_row = existingWires.Split('\n');

                int iRowBound, iColBound;
                iRowBound = arr_row.Length;
                iColBound = arr_row[0].Length;

                map = new string[iRowBound, iColBound];
                map_copy = new string[iRowBound, iColBound];

                Queue<string> path = new Queue<string>();
                path.Enqueue("|");

                int iS = 0;
                int jS = 0;

                for (int i = 0; i < iRowBound; i++)
                {
                    for (int j = 0; j < iColBound; j++)
                    {
                        map[i, j] = arr_row[i].Substring(j, 1);
                        if (map[i, j] == "S")
                        {
                            path.Enqueue(i.ToString() + "," + j.ToString());
                            iS = i;
                            jS = j;
                        }
                    }
                }
                Array.Copy(map, map_copy, map.Length);
                map_copy[iS, jS] = "-1,-1,0";

                while (path.Count > 0)
                {
                    if (path.Peek() == "|")
                    {
                        path.Dequeue();
                        if (path.Count == 0)
                        {
                            return "Oh for crying out loud...";
                        }
                        else
                        {
                            path.Enqueue("|");
                        }
                    }

                    int iRow, iCol;

                    iRow = Convert.ToInt32(path.Peek().Split(',')[0]);
                    iCol = Convert.ToInt32(path.Peek().Split(',')[1]);

                    path.Dequeue();

                    double w = Convert.ToDouble(map_copy[iRow, iCol].Split(',')[2]);


                    //goal
                    if (map[iRow, iCol] == "G")
                    {
                        string strResult = SetP(iRow, iCol);
                        return strResult;
                    }

                    //move
                    foreach (int iNextRow in Enumerable.Range(iRow - 1, 3))
                    {
                        foreach (int INextCol in Enumerable.Range(iCol - 1, 3))
                        {
                            if ((iNextRow == iRow) && (INextCol == iCol))
                            {
                                continue;
                            }

                            FindPath(iRow, iCol, w, iNextRow, INextCol, iRowBound, iColBound, path);
                        }
                    }
                }

                return "Oh for crying out loud...";
            }

            public static void FindPath(int iRow, int iCol, double intNodeW, int iNextRow, int iNextCol, int iRowBound, int iColBound, Queue<string> path)
            {
                if ((iNextRow >= 0) && (iNextRow < iRowBound) && (iNextCol >= 0) && (iNextCol < iColBound))
                {
                    string strNextNode = map_copy[iNextRow, iNextCol];

                    if (strNextNode != "X")
                    {

                        double addW;

                        if ((iNextRow == iRow) || (iNextCol == iCol))
                        {
                            addW = 1;
                        }
                        else
                        {
                            addW = Math.Sqrt(2);
                        }


                        bool flag = false;

                        if ((strNextNode == ".") || (strNextNode == "G"))
                        {
                            flag = true;
                        }
                        else
                        {
                            double nextw = Convert.ToDouble(map_copy[iNextRow, iNextCol].Split(',')[2]);

                            if (intNodeW + addW < nextw)
                            {
                                flag = true;
                            }

                        }

                        if (flag)
                        {
                            map_copy[iNextRow, iNextCol] = iRow + "," + iCol + "," + (intNodeW + addW).ToString();
                            string strNextPath = iNextRow.ToString() + "," + iNextCol.ToString();
                            if (Array.IndexOf(path.ToArray(), strNextPath) == -1)
                            {
                                path.Enqueue(strNextPath);
                            }
                        }
                    }
                }
            }

            public static string SetP(int iRow, int iCol)
            {
                int intPreRow, intPreCol;

                while (true)
                {
                    intPreRow = Convert.ToInt32(map_copy[iRow, iCol].Split(',')[0]);
                    intPreCol = Convert.ToInt32(map_copy[iRow, iCol].Split(',')[1]);
                    if (map[intPreRow, intPreCol] == "S")
                    {
                        break;
                    }
                    map[intPreRow, intPreCol] = "P";
                    iRow = intPreRow;
                    iCol = intPreCol;
                }

                string strResult = string.Empty;

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        strResult += map[i, j];
                    }
                    strResult += "\n";
                }

                return strResult.Trim('\n');
            }
        }
    }
}
