using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_kyu__Make_a_spiral
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = 20;
            Print.PrintSpiralize(Spiralizor.Spiralize(input));
            Console.Read();
        }

        public class CheckNodeList
        {
            public int[,] CheckNode = new int[3, 2];
        }

        public class Spiralizor
        {
            static int bound;

            public static int[,] Spiralize(int size)
            {
                bound = size;
                int[,] r = new int[size, size];

                Queue<CheckNodeList> ForwardList = new Queue<CheckNodeList>();
                //Right
                ForwardList.Enqueue(new CheckNodeList()
                {
                    CheckNode = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 } }
                });
                //Down
                ForwardList.Enqueue(new CheckNodeList()
                {
                    CheckNode = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 } }
                });
                //Left
                ForwardList.Enqueue(new CheckNodeList()
                {
                    CheckNode = new int[,] { { 1, 0 }, { 0, -1 }, { -1, 0 } }
                });
                //Up
                ForwardList.Enqueue(new CheckNodeList()
                {
                    CheckNode = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 } }
                });


                int now_i = 0;
                int now_j = 0;
                bool check_fail_flag = false;
                int fail_count = 0;

                while (true)
                {

                    if (fail_count > 1)
                    {
                        r[now_i, now_j] = 1;
                        break;
                    }

                    check_fail_flag = false;

                    int[,] CheckNode = ForwardList.Peek().CheckNode;

                    int nexti = now_i + CheckNode[1, 0];
                    int nextj = now_j + CheckNode[1, 1];

                    if (InRange(nexti, nextj))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int nexti_checki = nexti + CheckNode[i, 0];
                            int nextj_cehckj = nextj + CheckNode[i, 1];

                            if (InRange(nexti_checki, nextj_cehckj))
                            {
                                if (r[nexti_checki, nextj_cehckj] == 1)
                                {
                                    check_fail_flag = true;
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {
                        check_fail_flag = true;
                    }


                    if (check_fail_flag)
                    {
                        ForwardList.Enqueue(ForwardList.Dequeue());
                        fail_count++;
                    }
                    else
                    {
                        r[now_i, now_j] = 1;

                        now_i = nexti;
                        now_j = nextj;

                        fail_count = 0;
                    }

                }

                return r;

            }

            public static bool InRange(int i, int j)
            {
                if ((i < 0) || (j < 0))
                {
                    return false;
                }
                if ((i >= bound) || (j >= bound))
                {
                    return false;
                }
                return true;
            }

        }

        public class Print
        {
            public static void PrintSpiralize(int[,] result)
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        Console.Write(result[i, j]);
                    }
                    Console.WriteLine("");
                }
            }
        }




    }



}
