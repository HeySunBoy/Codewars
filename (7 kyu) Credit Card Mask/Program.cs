using System;

namespace Credit_Card_Mask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Maskify("456789"));
        }

        public static string Maskify(string cc)
        {
            //↓↓↓ Refactor Practice

            return cc.Length <= 4 ? cc : cc.Substring(cc.Length - 4, 4).PadLeft(cc.Length, '#');

            //↓↓↓ First Practice

            //if (cc.Length <= 4)
            //{
            //    return cc;
            //}
            //else
            //{
            //    return cc.Substring(cc.Length - 4, 4).PadLeft(cc.Length, '#');
            //}
        }
    }
}


