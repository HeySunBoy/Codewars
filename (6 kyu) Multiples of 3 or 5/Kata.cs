using System;

public static class Kata
{
    public static int Solution(int value)
    {
        int result = 0;
        if (value <= 0)
        {
        }
        else
        {
            int max = value - 1;
            int count3 = max / 3;
            int count5 = max / 5;
            int count15 = max / 15;
            return Sum(3, count3) + Sum(5, count5) - Sum(15, count15);
        }
        return result;
    }

    private static int Sum(int a1, int n)
    {
        return (a1 + (a1 * n)) * n / 2;
    }
}