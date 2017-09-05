using System;
using System.IO;

namespace _CSharp_FileManager
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //test();

            // begin
            //Trader trader = new Trader("TestFile.csv");
            Trader trader = new Trader("20110315.csv");
            do
            {
                Console.WriteLine("input Stock Code:");
                string scan = Console.ReadLine();
                Console.WriteLine("input output File Name:");
                string scanFileName = Console.ReadLine();
                string[] arrSplit = scanFileName.Split('.');

                if (arrSplit.Length == 1)
                {
                        scanFileName += ".csv";
                }
				else if (arrSplit.Length > 2 || arrSplit.Length == 0)
				{
					Console.WriteLine("Error: File Name illegal.");
                    continue;
				}
                    trader.SetDestinationFileName(scanFileName);
                    if (trader.SearchStock(scan, scanFileName))
                        Console.WriteLine("is done.");
                    else
                        Console.WriteLine("Fail.");
            } while (true);
        }
        public static void test()
        {
            Trader trader = new Trader("TestFile.csv");

            do
            {
                Console.WriteLine("input index:");
                string scan = Console.ReadLine();
                try
                {
                    int index = Int32.Parse(scan);
                    if (index == -1)
                    {
                        break;
                    }
                    if (index < -1)
                    {
                        Console.WriteLine("Error: index < 0");
                        continue;
                    }

                    string printStr = trader.GetStockDataByIndex(index);
                    if (printStr == null)
                    {
                        Console.WriteLine("Error: index is not exist.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(printStr);
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Input Format.");
                }
            } while (true);




            // get Current Directory
            //Console.WriteLine(System.Environment.CurrentDirectory);

            //File Manager
            //string sourceFile = "TestFile.csv";
            //string targetFile = "target.csv";

            //Stock[] arrStock = new Stock[100];
            //string title;

            //try
            //{
            //    // in
            //    FileStream fromStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            //    StreamReader fileReader = new StreamReader(fromStream);
            //    // out
            //    FileStream toStream = new FileStream(targetFile, FileMode.Create, FileAccess.Write);
            //    StreamWriter fileWriter = new StreamWriter(toStream);

            //    String loadInStr;
            //    int dataCount = 0;
            //    title = fileReader.ReadLine();

            //    while ((loadInStr = fileReader.ReadLine()) != null)
            //    {
            //        //Console.WriteLine(loadInStr);
            //        //fileWriter.WriteLine(loadInStr);
            //        string[] arrToSplit = loadInStr.Split(',');

            //        if (dataCount == arrStock.Length)
            //            arrStock = Resize(arrStock);
            //        arrStock[dataCount++] = new Stock(arrToSplit);


            //    }
            //    fileReader.Close();
            //    fileWriter.Close();
            //    fromStream.Close();
            //    toStream.Close();

            //    // print
            //    Console.WriteLine(title);
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine(arrStock[i].getString());
            //    }
            //    Console.WriteLine("Data count: " + dataCount);
            //    //Byte[] buffer = new Byte[500];  //準備暫存的資料陣列
            //    //            int count;
            //    //while ((count = fromStream.Read(buffer, 0, buffer.Length)) > 0) //從資料串流讀取資料
            //    //toStream.Write(buffer, 0, count);   //寫入資料串流

            //}
            //catch
            //{
            //    Console.WriteLine("Error: FileCopy '{0}' to '{1}'", sourceFile, targetFile);
            //}




        }
        public static Stock[] Resize(Stock[] arr)
        {
            Stock[] copy = new Stock[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
                copy[i] = arr[i];
            return copy;
        }

    }
}
