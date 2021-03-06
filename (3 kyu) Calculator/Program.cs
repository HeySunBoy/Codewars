using System;
using System.Collections.Generic;
using System.Data;

namespace _3_kyu_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("b" + Evaluate("123.45*(678.90 / (-2.5+ 11.5)-(80 -19) *33.25) / 20 + 11").ToString());
        }

        public static double Evaluate(string expression)
        {
            DataTable d = new DataTable();
            return Convert.ToDouble(d.Compute(expression, "").ToString());
        }

        public static double Evaluate2(string expression)
        {
            expression = expression.Replace(" ", "");
            expression = expression.Replace("(", " ( ");
            expression = expression.Replace(")", " ) ");
            expression = expression.Replace("+", " + ");
            expression = expression.Replace("-", " - ");
            expression = expression.Replace("*", " * ");
            expression = expression.Replace("/", " / ");

            string[] operatorlist = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int i = 0;

            Stack<string> s = new Stack<string>();

            string num_a, num_b;
            string _operator;

            while (i < operatorlist.Length)
            {
                s.Push(operatorlist[i]);
                                
                if ("*/".Contains(s.Peek()))
                {
                    i++;
                    s.Push(operatorlist[i]);

                    num_b = s.Pop();
                    _operator = s.Pop();
                    num_a = s.Pop();

                    s.Push(DoCalc(num_a, _operator, num_b).ToString());
                }
                else if (")".Contains(s.Peek()))
                {
                    s.Pop();
                    while (true)
                    {
                        num_b = s.Pop();
                        _operator = s.Pop();
                        num_a = s.Pop();

                        if (_operator == "(")
                        {
                            s.Push(num_a);
                            s.Push(num_b);
                            break;
                        }
                        else
                        {
                            s.Push(DoCalc(num_a, _operator, num_b).ToString());
                        }
                    }
                }else if ("-".Contains(s.Peek()))
                {
                    i++;
                    s.Push(operatorlist[i]);

                    num_b = s.Pop();
                    _operator = s.Pop();
                    num_a = s.Pop();

                    if ("+-*/()".Contains(num_a))
                    {
                        s.Push(num_a);
                        s.Push(DoCalc("0", _operator, num_b).ToString());
                    }
                    else
                    {
                        s.Push(DoCalc(num_a, _operator, num_b).ToString());
                    }
                }
                i++;
            }

            while (s.Count > 1)
            {
                num_b = s.Pop();
                _operator = s.Pop();
                num_a = s.Pop();

                s.Push(DoCalc(num_a, _operator, num_b).ToString());
            }
            return Convert.ToDouble(s.Pop());
        }

        public static double DoCalc(string num_a, string _operator, string num_b)
        {

            double d_num_a = Convert.ToDouble(num_a);
            double d_num_b = Convert.ToDouble(num_b);

            if (_operator == "*")
            {
                return d_num_a * d_num_b;
            }
            else if (_operator == "/")
            {
                return d_num_a / d_num_b;
            }
            else if (_operator == "+")
            {
                return d_num_a + d_num_b;
            }
            else if (_operator == "-")
            {
                return d_num_a - d_num_b;
            }
            return 0.0;
        }

    }
}
