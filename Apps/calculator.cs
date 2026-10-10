using System;
using System.Collections.Generic;
using System.Globalization;

namespace ArtOS.Apps.calc
{
    internal class calculator
    {
        public void Run()
        {
            Console.WriteLine("=== ArtOS Calculator (Own Parser) ===");
            Console.WriteLine("Support: + - * / ^ and brackets");
            Console.WriteLine("exit - exit calculator");
            Console.WriteLine();

            while (true)
            {
                Console.Write("calc>");
                string input = Console.ReadLine();

                if (input == null)
                    continue;

                if (input.ToLower() == "exit")
                    break;

                try
                {
                    double result = Evaluate(input);
                    Console.WriteLine("= " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
        }

        private double Evaluate(string expression)
        {
            var output = new Stack<double>();
            var operators = new Stack<char>();

            expression = expression.Replace(" ", "");

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                // Число
                if (char.IsDigit(c) || c == '.')
                {
                    string number = "";
                    while (i < expression.Length &&
                          (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number += expression[i];
                        i++;
                    }
                    i--;

                    output.Push(double.Parse(number, CultureInfo.InvariantCulture));
                }
                // Відкрита дужка
                else if (c == '(')
                {
                    operators.Push(c);
                }
                // Закрита дужка
                else if (c == ')')
                {
                    while (operators.Peek() != '(')
                        Process(output, operators.Pop());

                    operators.Pop();
                }
                // Оператор
                else if (IsOperator(c))
                {
                    // Унарний мінус
                    if (c == '-' && (i == 0 || expression[i - 1] == '('))
                    {
                        output.Push(0);
                    }

                    while (operators.Count > 0 &&
                           Precedence(operators.Peek()) >= Precedence(c))
                    {
                        Process(output, operators.Pop());
                    }

                    operators.Push(c);
                }
            }

            while (operators.Count > 0)
                Process(output, operators.Pop());

            return output.Pop();
        }

        private void Process(Stack<double> values, char op)
        {
            double b = values.Pop();
            double a = values.Pop();

            switch (op)
            {
                case '+': values.Push(a + b); break;
                case '-': values.Push(a - b); break;
                case '*': values.Push(a * b); break;
                case '/':
                    if (b == 0)
                        throw new Exception("Division by zero");
                    values.Push(a / b);
                    break;
                case '^': values.Push(Math.Pow(a, b)); break;
            }
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        private int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }
    }
}