using System;

namespace _BinaryTrees
{
    class MainClass
    {
        // static 
        static BinaryTree contacts = new BinaryTree();

        public static void Main(string[] args)
        {
            do
            {
                PrintMenu();
                string op = Console.ReadLine();
                switch (op)
                {
                    case "i":
                        Insert();
                        break;
                    case "d":
                        Delete();
                        break;
                    case "f":
                        Search();
                        break;
                    case "l":
                        Output();
                        break;
                    case "q":
                        Console.WriteLine("Bye~");
                        return;
                    default:
                        Console.WriteLine("Error: input illegal.");
                        break;
                }

            } while (true);
        }
        public static void Insert()
        {
            Console.WriteLine("input name: ");
            string scanName = Console.ReadLine();
            Console.WriteLine("input phone: ");
            string scanPhone = Console.ReadLine();
            if (!contacts.InsertNodeLoop(scanName, scanPhone))
                Console.WriteLine("name is duplicate.");

        }
        public static void Delete()
        {
			Console.WriteLine("input name: ");
			string scanName = Console.ReadLine();
            contacts.DeleteRecusive(contacts.GetRoot(), null, scanName);
        }
        public static void Search()
        {
			Console.WriteLine("input name: ");
			string scanName = Console.ReadLine();
            TreeNode temp;
            if((temp = contacts.SearchNodeRecusive(contacts.GetRoot(), scanName)) == null)
                Console.WriteLine("No match name.");
            else
            {
                Console.WriteLine("name: " + temp.GetData()[0]);
                Console.WriteLine("phone: " + temp.GetData()[1]);
            }
        }
        public static void Output()
        {
            contacts.PrintInorder(contacts.GetRoot());
        }
        public static void PrintMenu()
        {
            Console.WriteLine(" --- menu --- ");
            Console.WriteLine("i) 新增 姓名, 電話");
            Console.WriteLine("d) 刪除 姓名");
            Console.WriteLine("f) 搜尋 姓名");
            Console.WriteLine("l) 印出 所有節點內容");
            Console.WriteLine("q) 離開 程式");
        }
    }
}
