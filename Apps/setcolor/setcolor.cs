using System;

namespace ArtOS.Apps.setcolor
{
    public class SetColor
    {
        public static void Run()
        {
            Console.Write("Enter color (1-15): ");

            if (int.TryParse(Console.ReadLine(), out int c))
            {
                if (c >= 1 && c <= 15)
                {
                    Kernel.CurrentColor = (ConsoleColor)c;
                    Console.ForegroundColor = Kernel.CurrentColor;
                    Console.WriteLine("Color changed!");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}