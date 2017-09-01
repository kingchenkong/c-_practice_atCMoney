using System;

namespace _DrawStar
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("size:");
                int size = Int32.Parse(Console.ReadLine());
                if (size == -1)
                    break;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size - i - 1; j++)
                        Console.Write(" ");
                    Console.Write("*");
                    for (int k = size - i; k < size; k++)
                        Console.Write("**");
                    Console.WriteLine();
                }
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                        Console.Write(" ");
                    Console.Write("*");
                    for (int k = 1; k < size - i - 1; k++)
                        Console.Write("**");
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
