using System;

namespace _chCSharp_practice1
{
    class MainClass
    {
        public static String[] arrStr = new String[10];
        public static int dataCount = 0;
        public static double sumAtArrStr = 0.0;
        public static String scanStr = "";
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("a) Add, b) Output, c)Quit: ");
                string scanOption = Console.ReadLine();
                if (scanOption == "a")
                {
                    OptionAdd();
                }
                if (scanOption == "b")
                {
                    //TestOutput();
                    OptionOutput();
                }
                if (scanOption == "c")
                {
                    Console.WriteLine("Quit.");
                    return;
                }
            } while (true);
        }
        public static void OptionAdd()
        {
            Console.WriteLine("Input a sentence: ");
            scanStr = Console.ReadLine();
            // process
            char[] haveDot = { ' ', ',', ':', '\t', '\n', '.' };
            char[] delimiterChars = { ' ', ',', ':', '\t', '\n' };
            string[] words = scanStr.Split(delimiterChars);
            int blankCount = 0;
            double sum = 0;
            //
            for (int i = 0; i < words.Length; i++)
            {
                double doubleNum;
                if (Double.TryParse(words[i], out doubleNum))
                {
                    sum += doubleNum;
                    words[i] = "";
                }
            }
            String strCom = "";
            foreach (string s in words)
            {
                strCom += (" " + s);
            }
            //
            words = strCom.Split(haveDot);
            for (int i = 0; i < words.Length; i++)
            {
                int num;
                if (Int32.TryParse(words[i], out num))
                {
                    sum += num;
                    words[i] = "";
                }
                if (words[i] == "")
                {
                    blankCount += 1;
                    for (int j = i; j < words.Length - 1; j++)
                    {
                        words[j] = words[j + 1];

                    }
                }
            }
            // Delete duplicated
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                    {
                        words[j] = "";
                    }
                }
            }
            //
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    arrStr[dataCount++] = words[i];
                    if (dataCount == arrStr.Length)
                        Resize();
                }
            }
            sumAtArrStr += sum;
            InsertionSort();
            DeleteDuplicated();
        }
        public static void OptionOutput()
        {
            PrintArr(arrStr);
            Console.WriteLine("sum = " + sumAtArrStr);
        }
        public static void PrintArr(String[] words)
        {
            foreach (string s in words)
            {
                if (s != "" && s != null)
                    System.Console.WriteLine(s);
            }
        }
        public static void Resize()
        {
            String[] copy = new String[arrStr.Length * 2];
            for (int i = 0; i < arrStr.Length; i++)
            {
                copy[i] = arrStr[i];
            }
            arrStr = copy;
        }
        public static void InsertionSort()
        {
            for (int i = 1; i < dataCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (String.Compare(arrStr[i], arrStr[j], true) < 0)
                    {
                        String temp = arrStr[i];
                        for (int k = i; k > j; k--)
                        {
                            arrStr[k] = arrStr[k - 1];
                        }
                        arrStr[j] = temp;
                    }
                }
            }
        }
        public static void DeleteDuplicated()
        {
            for (int i = 0; i < dataCount; i++)
            {
                for (int j = i + 1; j < dataCount; j++)
                {
                    if (arrStr[i] == arrStr[j])
                    {
                        arrStr[j] = "";
                    }
                }
            }
            for (int i = 0; i < dataCount; i++)
			{
                if (arrStr[i] == "")
				{
                    for (int j = i; j < dataCount - 1; j++)
					{
                        arrStr[j] = arrStr[j + 1];

					}
				}
                //dataCount--;
			}
        }
        public static void TestOutput()
        {
            Console.WriteLine("sum:");

            char[] haveDot = { ' ', ',', ':', '\t', '\n', '.' };
            char[] delimiterChars = { ' ', ',', ':', '\t', '\n' };
            string text = "the UN Security Council has a discuss at 10 a.m. ET. 1.5";

            Console.WriteLine("-----------------------");

            System.Console.WriteLine("Original text: '{0}'", text);
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("{0} words in text:", words.Length);
            PrintArr(words);

            Console.WriteLine("-----------------------");
            int blankCount = 0;
            double sum = 0;

            for (int i = 0; i < words.Length; i++)
            {
                double doubleNum;
                if (Double.TryParse(words[i], out doubleNum))
                {
                    sum += doubleNum;
                    words[i] = "";
                }
            }
            PrintArr(words);

            String strCom = "";
            foreach (string s in words)
            {
                strCom += (" " + s);
            }

            Console.WriteLine(strCom);
            words = strCom.Split(haveDot);
            Console.WriteLine("--------0000---------------");

            for (int i = 0; i < words.Length; i++)
            {
                int num;
                if (Int32.TryParse(words[i], out num))
                {
                    sum += num;
                    words[i] = "";
                }
                if (words[i] == "")
                {
                    blankCount += 1;
                    for (int j = i; j < words.Length - 1; j++)
                    {
                        words[j] = words[j + 1];

                    }
                }
            }
            PrintArr(words);

            Console.WriteLine("-------------1111----------");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    arrStr[dataCount++] = words[i];
                    if (dataCount == arrStr.Length)
                        Resize();
                }
            }

            Console.WriteLine("-----------------------");

            PrintArr(arrStr);
            sumAtArrStr += sum;
            Console.WriteLine("text.Length = " + text.Length);
            Console.WriteLine("blankCount = " + blankCount);
            Console.WriteLine("sum = " + sum);
            Console.WriteLine("sumAtArrStr = " + sumAtArrStr);

            Console.WriteLine("----------end-------------");
            InsertionSort();
            PrintArr(arrStr);

        }
    }
}
