using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_kyu__Select_median
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            Warrior[] input = new Warrior[]{
                                            new Warrior(1),
                                            new Warrior(2),
                                            new Warrior(3),
                                            new Warrior(4),
                                            new Warrior(5)
                                          };

            Kata.SelectMedian(input);
            Console.WriteLine(Warrior.CompareCount);
            Console.Read();
        }
    }

    public class Warrior : IWarrior
    {
        private int m_internal;

        public static int CompareCount { get; private set; }

        public Warrior(int rank = 0)
        {
            m_internal = rank;
        }

        public bool IsBetter(IWarrior other)
        {
            ++CompareCount;
            if (other == null || !(other is Warrior)) return false;
            return m_internal >= (other as Warrior).m_internal;
        }

        public static void ResetCompareCount()
        {
            CompareCount = 0;
        }
    }

    public interface IWarrior
    {
        // a.IsBetter(b) returns true if and only if
        // warrior a is no worse than warrior b, i.e. a>=b
        bool IsBetter(IWarrior other);
    }

    public static class Kata
    {
        // warriors is IWarrior[5]
        public static IWarrior SelectMedian(IWarrior[] warriors)
        {
            // Left better than Right
            // A >= B
            IWarrior[] Group_1 = SortWarrior(warriors[0], warriors[1]);
            // C >= D
            IWarrior[] Group_2 = SortWarrior(warriors[2], warriors[3]);

            // (1) A >= B >= C >= D , A >= D , So Drop A.
            // (2) B >= E, C >= D
            if (Group_1[0].IsBetter(Group_2[0]))
            {
                Group_1 = SortWarrior(warriors[4], Group_1[1]);
            }
            else
            {
                Group_2 = SortWarrior(warriors[4], Group_2[1]);
            }

            // (1) B >= C >= D , B >= E
            // (2) IF C >= E ? Return C : Return E;
            if (Group_1[0].IsBetter(Group_2[0]))
            {
                return Group_1[1].IsBetter(Group_2[0]) ? Group_1[1] : Group_2[0];
            }
            else
            {
                return Group_1[0].IsBetter(Group_2[1]) ? Group_1[0] : Group_2[1];
            }
        }

        public static IWarrior[] SortWarrior(IWarrior warrior1, IWarrior warrior2)
        {
            if (warrior1.IsBetter(warrior2))
            {
                return new IWarrior[] { warrior1, warrior2 };
            }
            else
            {
                return new IWarrior[] { warrior2, warrior1 };
            }
        }
    }
}
