using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_kyu__6_By_6_Skyscrapers
{
    class Program
    {
        static void Main(string[] args)
        {
            var clues = new[] { 0, 3, 0, 5, 3, 4,
                            0, 0, 0, 0, 0, 1,
                            0, 3, 0, 3, 2, 3,
                            3, 2, 0, 3, 1, 0};

            var expected = new[]{new []{ 5, 2, 6, 1, 4, 3 },
                             new []{ 6, 4, 3, 2, 5, 1 },
                             new []{ 3, 1, 5, 4, 6, 2 },
                             new []{ 2, 6, 1, 5, 3, 4 },
                             new []{ 4, 3, 2, 6, 1, 5 },
                             new []{ 1, 5, 4, 3, 2, 6 }};


            var actual = Skyscrapers.SolvePuzzle(clues);

            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    if (expected[i][j] != actual[i][j])
                    {
                        Console.WriteLine("err!!");
                    }
                }
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }

    public static class print
    {
        public static void PrintPuzzle(int[][] Puzzle, int i, int j)
        {
            Console.Clear();

            for (int x = 0; x < Puzzle.Length; x++)
            {
                for (int y = 0; y < Puzzle.Length; y++)
                {
                    if ((x == i) && (y == j))
                    {
                        Console.Write("[" + Puzzle[x][y] + "]");
                    }
                    else
                    {
                        Console.Write(" " + Puzzle[x][y] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class Skyscrapers
    {
        public class BuildInfo
        {
            public int i { get; set; }
            public int j { get; set; }
            public Queue<int> PossibleBuild { get; set; }

        }

        public static int[][] SolvePuzzle(int[] clues)
        {
            int[][] Puzzle = new int[8][];

            int i = 0;
            int j = 0;

            Stack<BuildInfo> BuildLog = new Stack<BuildInfo>();

            for (i = 0; i < Puzzle.Length; i++)
            {
                Puzzle[i] = new int[8];
            }

            for (int iclues = 0; iclues < clues.Length; iclues++)
            {
                if (iclues < 6)
                {
                    i = 0;
                    j++;
                }
                else if (iclues < 12)
                {
                    i++;
                    j = 7;
                }
                else if (iclues < 18)
                {
                    i = 7;
                    j = 18 - iclues;
                }
                else
                {
                    i = 24 - iclues;
                    j = 0;
                }

                Puzzle[i][j] = clues[iclues];

                FillDefaultBuilds(Puzzle, i, j, clues[iclues], BuildLog);
            }



            BuildInfo buildinfo;

            BuildLog.Push(GetMinPossibleBuild(Puzzle));

            while (true)
            {

                buildinfo = BuildLog.Peek();

                if (buildinfo.PossibleBuild.Count > 0)
                {

                    Puzzle[buildinfo.i][buildinfo.j] = buildinfo.PossibleBuild.Dequeue();
                    //if build ok.
                    if (IsPutBuildOK(Puzzle, buildinfo.i, buildinfo.j))
                    {
                        if (BuildLog.Count == 36)
                        {
                            int[][] ResultPuzzle = new int[6][];
                            for (int x = 1; x < Puzzle.Length - 1; x++)
                            {
                                ResultPuzzle[x - 1] = new int[6];

                                for (int y = 1; y < Puzzle.Length - 1; y++)
                                {
                                    ResultPuzzle[x - 1][y - 1] = Puzzle[x][y];
                                }
                            }
                            return ResultPuzzle;
                        }
                        BuildLog.Push(GetMinPossibleBuild(Puzzle));
                    }
                    else
                    {
                        Puzzle[buildinfo.i][buildinfo.j] = 0;
                    }
                }
                else
                {
                    Puzzle[buildinfo.i][buildinfo.j] = 0;
                    BuildLog.Pop();
                }
            }
        }

        public static void FillDefaultBuilds(int[][] Puzzle, int i, int j, int clues, Stack<BuildInfo> BuildLog)
        {
            if (clues != 1 && clues != 6)
            {
                return;
            }

            int n = clues;

            int iP = i;
            int jP = j;


            while (--clues >= 0)
            {
                //Down
                if (i == 0)
                {
                    iP++;
                }
                //Left
                else if (j == 7)
                {
                    jP--;
                }
                //Up
                else if (i == 7)
                {
                    iP--;
                }
                //Right
                else if (j == 0)
                {
                    jP++;
                }

                if ((Puzzle[iP][jP]) == 0)
                {
                    BuildLog.Push(new BuildInfo() { i = iP, j = jP });
                }

                Puzzle[iP][jP] = 6 - n + 1;
                n--;
            }
        }

        public static BuildInfo GetMinPossibleBuild(int[][] Puzzle)
        {

            int minPuzzlePossiblePathCount = 6;
            int[] minPossibleBuild = new int[6];
            int mini = 0;
            int minj = 0;

            for (int i = 1; i < Puzzle.Length - 1; i++)
            {
                for (int j = 1; j < Puzzle[j].Length - 1; j++)
                {
                    if (Puzzle[i][j] == 0)
                    {
                        int[] PossibleBuild = GetPossibleBuild(Puzzle, i, j);

                        int minPossiblePathCount = PossibleBuild.Count(o => o != -1);

                        if (minPossiblePathCount < minPuzzlePossiblePathCount)
                        {
                            minPuzzlePossiblePathCount = minPossiblePathCount;
                            minPossibleBuild = PossibleBuild;
                            mini = i;
                            minj = j;
                        }
                    }
                }
            }

            return new BuildInfo()
            {
                i = mini,
                j = minj,
                PossibleBuild = new Queue<int>(minPossibleBuild.Where(n => n != -1).ToList()),
            };
        }

        public static int[] GetPossibleBuild(int[][] Puzzle, int i, int j)
        {
            int[] PossibleBuild = Enumerable.Range(0, 7).ToArray();
            //(1)
            //Remove Exist Build
            for (int x = 1; x < Puzzle.Length - 1; x++)
            {
                PossibleBuild[Puzzle[x][j]] = -1;
                PossibleBuild[Puzzle[i][x]] = -1;
            }
            //(2)
            int CanMaxBuildNum = 6;
            //top
            if (Puzzle[0][j] != 0)
            {
                CanMaxBuildNum = Math.Min(CanMaxBuildNum, (6 - Puzzle[0][j]) + Math.Abs(i - 0));
            }
            //left
            if (Puzzle[i][0] != 0)
            {
                CanMaxBuildNum = Math.Min(CanMaxBuildNum, (6 - Puzzle[i][0]) + Math.Abs(j - 0));
            }
            //down
            if (Puzzle[7][j] != 0)
            {
                CanMaxBuildNum = Math.Min(CanMaxBuildNum, (6 - Puzzle[7][j]) + Math.Abs(i - 7));
            }
            //right
            if (Puzzle[i][7] != 0)
            {
                CanMaxBuildNum = Math.Min(CanMaxBuildNum, (6 - Puzzle[i][7]) + Math.Abs(j - 7));
            }

            while (CanMaxBuildNum < 6)
            {
                PossibleBuild[++CanMaxBuildNum] = -1;
            }

            return PossibleBuild;
        }

        public static bool IsPutBuildOK(int[][] Puzzle, int i, int j)
        {
            //up to down
            bool bol1 = (IsRowColumnBuildOK(Puzzle, 0, j, 1, 0));
            //down to up
            bool bol2 = (IsRowColumnBuildOK(Puzzle, 7, j, -1, 0));
            //left to right
            bool bol3 = (IsRowColumnBuildOK(Puzzle, i, 0, 0, 1));
            //right to left
            bool bol4 = (IsRowColumnBuildOK(Puzzle, i, 7, 0, -1));

            return (bol1 && bol2 && bol3 && bol4);
        }

        public static bool IsRowColumnBuildOK(int[][] Puzzle, int i, int j, int add_i, int add_j)
        {

            int clue = Puzzle[i][j];

            if (clue != 0)
            {
                int MaxBuild = 0;
                int MaxBuildCount = 0;
                for (int x = 1; x <= 6; x++)
                {
                    i = i + add_i;
                    j = j + add_j;

                    if (Puzzle[i][j] == 0)
                    {
                        return true;
                    }
                    if (Puzzle[i][j] > MaxBuild)
                    {
                        MaxBuild = Puzzle[i][j];
                        MaxBuildCount++;
                    }
                    if (MaxBuildCount > clue)
                    {
                        return false;
                    }
                    if (MaxBuild == 6)
                    {
                        return MaxBuildCount == clue;
                    }
                }

            }
            return true;
        }
    }
}