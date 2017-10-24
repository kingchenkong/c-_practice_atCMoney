using System;
using System.IO;

namespace ExamOnBoard_SecondGreatExam
{
    class MainClass
    {
        static HashTable ht = new HashTable(10, 5);

        public static void Main(string[] args)
        {
            //Test();
            //HashTable ht = new HashTable();
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
                        Console.WriteLine("Error: Main-Switch.scanOp error.");
                        break;
                }
            } while (true);

        }
        public static void Insert()
        {
            Console.WriteLine("File Name:");
            string fileName = Console.ReadLine();
            // IO
            FileStream fromStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fromStream);
            string readStr;
            char[] arrCh = { ',', '.' };
            int count = 1;
            while ((readStr = sr.ReadLine()) != null)
            {
                if (readStr == "")
                    continue;
                Console.WriteLine(readStr);
                string[] arrSp = readStr.Split(' ');
                for (int i = 0; i < arrSp.Length; i++)
                {
                    string[] arrSp2 = arrSp[i].Split(arrCh);
                    Console.WriteLine(count + ": " + arrSp[i] + ", " + arrSp2[0]);
                    int key = HashTable.GetHashKey(arrSp2[0]);
                    Console.WriteLine("\t hashNum => " + key + ", " + ht.HashFunc(key));
                    if (!ht.Insert(arrSp2[0]))
                    {
                        OverFlow(arrSp2[0]);
                        //break;
                    }
                    //int comp = string.Compare(arrSp[i], "SCENE", true);
                    //Console.WriteLine(arrSp[i] + "-" + "SCENE" +":" + i + ", " + comp);
                    //int comp = string.Compare("oceNe", "SCENE", true);
                    //Console.WriteLine("oceNe" + "-" + "SCENE" +":" + i + ", " + comp);
                    count++;
                }
                //if (count > 100)
                    //break;
            }
            // Close
            sr.Close();
            fromStream.Close();
        }
        public static void Search()
        {
            Console.WriteLine("Query: ");
            string scanStr = Console.ReadLine();
            ht.Search(scanStr);
        }
        public static void OverFlow(string str)
        {
            Console.WriteLine("OverFlow !! Do resizing…");
            HashTable tempHT = new HashTable(ht.GetBucket() * 2, 5);
            Console.WriteLine("The size of hash table goes to " + tempHT.GetBucket() + " from  " + ht.GetBucket() + ".");
            Console.WriteLine("Rehashing…");
            for (int i = 0; i < ht.GetBucket(); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Data tempData = ht.GetData(i, j);
                    for (int k = 0; k < tempData.apearCount; k++)
                        if (!tempHT.Insert(tempData.word))
                            Console.WriteLine("Error: Rehashing error.");
                }
            }
            tempHT.Insert(str); // when overflow
            Console.WriteLine("Done!");
            ht = tempHT;

        }
        public static void Test()
        {
            //
            //string str = "ASCENEZ";
            //char[] arrC = str.ToCharArray();
            //for (int i = 0; i < arrC.Length; i++)
            //{
            //    int numAscii = (int)arrC[i];
            //    if(numAscii >= 65 && numAscii <= 90)
            //    {
            //        // is upper case
            //        arrC[i] = (char)(numAscii + 32);
            //    }
            //    Console.WriteLine(arrC[i] + " => " + (int)arrC[i]);
            //}
            //int numToHash = 0;
            //for (int i = 0; i < arrC.Length; i++)
            //{
            //    numToHash += (int)arrC[i];
            //    Console.WriteLine("num = " + numToHash + ", " + arrC[i]);
            //}



            //
            //HashTable hashTable = new HashTable();
            //for (int i = 0; i < 10; i++)
            //{
            //	for (int j = 0; j < 5; j++)
            //	{
            //		hashTable.SetData("index " + "(" + i + "," + j + ")", i, j);
            //	}
            //}
            //Console.WriteLine("------------");
            //for (int i = 0; i < 10; i++)
            //{
            //	for (int j = 0; j < 5; j++)
            //	{
            //		Data temp = hashTable.GetData(i, j);
            //		Console.WriteLine(temp.word + ", appear:" + temp.apearCount);
            //	}
            //}
            //for (int j = 0; j < 5; j++)
            //{
            //	hashTable.SetData("index (1,1)", 1, 1);
            //	Console.WriteLine(hashTable.GetData(1, 1).word + ", appear:" + hashTable.GetData(1, 1).apearCount);
            //}
            //Console.WriteLine("------End------");
        }
    }
}
