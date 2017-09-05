using System;

namespace _practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int number;
            int value = 10;
            bool result = Int32.TryParse("123 ", out number);
            if (result)
                Console.WriteLine("Converted {0} to {1}.", value, number);
            else
                Console.WriteLine("Error");

            Console.WriteLine("----------------------------");
            Console.WriteLine("{0:C}", 2.5);
            Console.Write("{0:C}\n", -2.5);
            Console.Write("{0:D5}\n", 25);
            Console.Write("{0:E}\n", 250000);
            Console.Write("{0:F2}\n", 25);
            Console.Write("{0:F0}\n", 25);
            Console.Write("{0:G}\n", 2.5);
            Console.Write("{0:N}\n", 2500000);
            Console.Write("{0:X}\n", 250);
			Console.Write("{0:X}\n", 0xffff); 
            Console.WriteLine("----------------------------");
            
		}
    }
}
