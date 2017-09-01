using System;

namespace calculate
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("四則運算 Part II");

            do
            {
                Console.WriteLine("運算: 1) +, 2) -, 3)*, 4) /, -1)Quit:");
                int option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case -1:
                        Console.WriteLine("Quit.");
                        return ;
                    case 1:
                        CalAdd(inputFunc("1"), inputFunc("2"));
                        break;
                    case 2:
                        CalSub(inputFunc("1"), inputFunc("2"));
                        break;
                    case 3:
                        CalMul(inputFunc("1"), inputFunc("2"));
                        break;
                    case 4:
                        CalDiv(inputFunc("1"), inputFunc("2"));
                        break;
                    default:
                        Console.WriteLine("Input Error.");
                        break;
                }
            } while (true);
        }
        public static int inputFunc(String str)
        {
            Console.WriteLine("integer " + str + ":");
            return Int32.Parse(Console.ReadLine());
        }
        public static void CalAdd(int a, int b)
        {
            Console.WriteLine("Answer: " + (a + b));
        }
        public static void CalSub(int a, int b)
        {
            Console.WriteLine("Answer: " + (a - b));
        }
        public static void CalMul(int a, int b)
        {
            Console.WriteLine("Answer: " + (a * b));
        }
        public static void CalDiv(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Input Error.");
                return;
            }

            Console.WriteLine("Answer: " + (a / b));
        }
    }
}
