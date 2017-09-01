using System;

namespace _Practice_Prim
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("請輸入 正整數");
                int i1 = Int32.Parse(Console.ReadLine());
                if (i1 == -1)
                {
                    Console.WriteLine("Quit.");
                    return;
                }
                else if (i1 < 2)
                {
                    Console.WriteLine("not Prime.");
                }
                else if (i1 == 2)
                {
                    Console.WriteLine("is Prime.");
                }
                else
                {
                    process(i1);
                }
            } while (true);
        }
        public static void process(int int1)
        {
            //int count = 0;
            for (int i = 2; i <= int1 / 2; i++)
            {
                if (int1 % i == 0)
                {
                    Console.WriteLine("not Prime.");
                    return;
                }
            }
            Console.WriteLine("is Prime.");
        }
    }
}
