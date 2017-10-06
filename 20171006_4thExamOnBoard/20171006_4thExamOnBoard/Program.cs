using System;

namespace _4thExamOnBoard
{
    class MainClass
    {

        static NQueue[] nqArr = new NQueue[26];

        public static void Main(string[] args)
        {
            for (int i = 0; i < 26; i++)
            {
                nqArr[i] = new NQueue();
            }
            // Begin
            Insert();
            // option
            do
            {
                Console.WriteLine("1)Insert. 2)Get a word. 3)Output. 4)Quit: ");
                string option = Console.ReadLine();
                switch(option)
                {
					case "1":
                        Insert();
						break;
					case "2":
                        GetWord();
						break;
					case "3":
                        Output();
						break;
					case "4":
                        Console.WriteLine("Bye~");
                        return;
                    default:
                        Console.WriteLine("Error, input is invalid.");
                        break;
                }
            } while (true);
            //Test();
        }
		public static void Insert()
		{
			do
			{
				Console.Write("Input a string (-1 to end): ");
				string scan = Console.ReadLine();
				if (scan == "-1")
					break;
				if (IsValidInput(scan))
				{
					char[] chArr = scan.ToCharArray();
					int index = (int)chArr[0];
					if (IsHeadUpperCase(scan))
					{
						index -= 65;
					}
					else
					{
						index -= 97;
					}
					nqArr[index].Push(scan);
				}
			} while (true);
		}
		public static void GetWord()
		{
            Console.WriteLine("Initial: ");
            string scan = Console.ReadLine();
            if(IsValidInput(scan))
            {
                char[] chArr = scan.ToCharArray();
                int index = (int)chArr[0];
				if (IsHeadUpperCase(scan))
				{
					index -= 65;
				}
				else
                {
                    index -= 97;
                }
                if(!nqArr[index].IsEmpty())
                {
					string word = nqArr[index].RandomGet();
					Console.WriteLine("WORD: " + word);
                    //Console.WriteLine("l: " + nqArr[index].GetLength());
				}
                else
                    Console.WriteLine(" -- Error: this NQueue is Empty.");
            }
            else
            {
                Console.WriteLine("Error. input invalid.");
            }

		}
		public static void Output()
		{
			for (int i = 0; i < 26; i++)
			{
				if (!nqArr[i].IsEmpty())
				{
					char ch = (char)(i + 65);
					Console.WriteLine(ch + ":");
					nqArr[i].Output();
				}
			}
		}
        public static bool IsHeadUpperCase(string str)
        {
            char[] chArr = str.ToCharArray();
            if ((int)chArr[0] >= 65 && (int)chArr[0] <= 90)
                return true;
            else
                return false;
        }
        public static bool IsValidInput(string str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (((int)chArr[i] >= 65 && (int)chArr[i] <= 90)||((int)chArr[i] >= 97 && (int)chArr[i] <= 122))
                {
                    //Console.WriteLine("is eng");
                }
                else
                {
                    //Console.WriteLine("error.");
                    return false;
                }
            }
            return true;
        }
        public static void Test()
        {
            char cA = 'A';
			Console.WriteLine("A: " + (int)cA);
			char cZ = 'Z';
			Console.WriteLine("Z: " + (int)cZ);
			char ca = 'a';
			Console.WriteLine("a: " + (int)ca);
			char cz = 'z';
			Console.WriteLine("z: " + (int)cz);
            string str = "aDpbe";
            char[] chArr = str.ToCharArray();
            Console.WriteLine((int)chArr[0]);
            Console.WriteLine(IsValidInput(str));
            Console.WriteLine(IsValidInput("AER58id"));

			//Random rnd = new Random();
			//NQueue nqA = new NQueue();
			//nqA.Push("aa");
			//nqA.Push("ab");
			//nqA.Push("ac");
			//nqA.Push("ad");
			//nqA.Output();
			//for (int i = 0; i < 5; i++)
			//{
			//	Console.WriteLine("pop: " + nqA.Pop() + ", l: " + nqA.GetLength());
			//	nqA.Output();

			//}
			//for (int i = 0; i < 5; i++)
			//{
			//	nqA.Push("aa");
			//	Console.WriteLine("push: aa" + ", l: " + nqA.GetLength());
			//	nqA.Output();
			//}
		}
    }
}
