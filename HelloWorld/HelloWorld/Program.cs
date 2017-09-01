using System;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            string s1 = Console.ReadLine();
            int a1 = Int32.Parse(s1);
            string s2 = Console.ReadLine();
            double a2 = Double.Parse(s2);
            int sum = a1 + (int)a2;
            Console.WriteLine(sum);

        }
    }
}
