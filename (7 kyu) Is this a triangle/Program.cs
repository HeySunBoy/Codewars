using System;

namespace Is_this_a_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsTriangle(0, 1, 1));
        }
        public static bool IsTriangle(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
