using System;

namespace _HashTable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1) Insert. 2) Search. -1) Quit: ");
                string scanOp = Console.ReadLine();
                switch (scanOp)
                {
                    case "-1":
                        Console.WriteLine("Bye~");
                        return;
                    case "1":
                        Insert();
                        break;
                    case "2":
                        Search();
                        break;
                    default:
                        Console.WriteLine("Error: scanOp setting error.");
                        break;
                }
            } while (true);
        }
        public static void Insert()
        {

        }
        public static void Search()
        {

        }
    }
}
