//請利用鏈結串列實作以下內容：
//使用鏈結串列儲存學生的學號以及英數兩科的成績（成績範圍必須介於0 ~100之間）
//提供選項可以做新增、刪除學生與列印結果。
//新增成績時，如果輸入的學號重複，請印出錯誤訊息並要求使用者重新輸入。
//列印時，請將學生依照平均分數的高低由大到小排列。
//排列與刪除請利用鏈結串列的Insert與Delete方式進行。(使用其餘方式以0分計)

//程式執行範例如下（使用者輸入的部分以粗體字標註）：

//請計算出每位學生的名次，名次以平均分數排列。程式執行範例如下（使用者輸入的部分以粗體字標註）：
//Insert new data(SN/ENGLISH/MATH): 1 100 83 
//Insert new data(SN/ENGLISH/MATH): 2 100 90 
//Insert new data(SN/ENGLISH/MATH): 6 10 100 
//Insert new data(SN/ENGLISH/MATH): 8 70 100 
//Insert new data(SN/ENGLISH/MATH): -1 -1 -1 

//Option: 1) Add. 2) Output. 3) Delete -1) Quit: 1
//Insert new data(SN/ENGLISH/MATH): 7 80 100 
//Insert new data(SN/ENGLISH /MATH): -1 -1 -1

//Option: 1) Add. 2) Output. 3) Delete -1) Quit: 2

//SN ENG.MATH.AVG.
//----------------------------------------------------------
//2       100      90     95      
//1       100      83     91      
//7       80       100        90      
//8       70       100        85      
//6       10       100        55      

//Option: 1) Add. 2) Output. 3) Delete -1) Quit: -1
//Bye!

using System;
using System.IO;
using _CH_DS_LinkedList_Practice_Score.Properties;

namespace _CH_DS_LinkedList_Practice_Score
{
    class MainClass
    {
        static LinkedList list = new LinkedList();
        public static void Main(string[] args)
        {
            InsertNewData();
            do
            {
                Console.Write("\nOption: 1) Add. 2) Output. 3) Delete -1) Quit: ");
                string scan = Console.ReadLine();
                switch (scan)
                {
                    case "1":
                        InsertNewData();
                        break;
                    case "2":
                        OutputData();
                        break;
                    case "3":
                        if (DeleteData())
                        {
                            Console.WriteLine("Delete Success.");
                        }
                        else
                        {
                            Console.WriteLine("Delete Fail.");
                        }
                        break;
                    case "-1":
                        return;
                    default:
                        Console.WriteLine("Error: Option input error.");
                        break;
                }

            } while (true);
        }
        public static bool DeleteData()
        {
            if (list.IsEmpty())
            {
                Console.WriteLine("is Empty.");
                return false;
            }
            Console.WriteLine("input stuNo to delete: ");
            try
            {
                string scan = Console.ReadLine();
                int op = Int32.Parse(scan);
                if (list.DeleteByStuNo(op))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        public static void OutputData()
        {
            Node node;
            int i = 0;
            // console
            //Console.WriteLine("SN\tENG.\tMATH.\tAVG.");
            //Console.WriteLine("----------------------------------------------------------");
            //while ((node = list.GetNodeByIndex(i)) != null)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}", node.GetData()[0], node.GetData()[1], node.GetData()[2], node.GetAv());
            //    i++;
            //}
            // file
            try
            {
                FileStream toStream = new FileStream("score.txt", FileMode.Create, FileAccess.Write);
                StreamWriter fileWriter = new StreamWriter(toStream);
                fileWriter.WriteLine("SN\tENG.\tMATH.\tAVG.");
                fileWriter.WriteLine("----------------------------------------------------------");
				while ((node = list.GetNodeByIndex(i)) != null)
				{
					fileWriter.WriteLine("{0}\t{1}\t{2}\t{3}", node.GetData()[0], node.GetData()[1], node.GetData()[2], node.GetAv());
					i++;
				}
                fileWriter.Flush();
                fileWriter.Close();
                toStream.Close();
            }
            catch
            {
                Console.WriteLine("Error: [ToFile] output issue.");
            }
        }
        public static void InsertNewData()
        {
            do
            {
                Console.WriteLine("\nInsert new data(SN / ENGLISH / MATH): ");
                string scan = Console.ReadLine();
                string[] scanSplit = scan.Split(' ');
                int length = 3;

                // .Length < 3
                if (scanSplit.Length < length)
                {
                    Console.WriteLine("Error: Input format invalid.");
                    continue;
                }
                int exitCount = 0;
                int[] data = new int[length];
                for (int i = 0; i < length; i++)
                {
                    if (scanSplit[i] == "-1")
                        exitCount++;
                    try
                    {
                        data[i] = Int32.Parse(scanSplit[i]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e);
                        data[0] = 0;
                        data[1] = -1;
                        data[2] = -1;
                        break;
                    }
                }


                // check exitCount, score is valid
                if (exitCount == 3)
                    break;
                else if (data[1] < 0 || data[1] > 100 || data[2] < 0 || data[2] > 100)
                    Console.WriteLine("Error: score can't assign >100 or <0");
                //else if (data[0] == -1)
                //    Console.WriteLine("Error: stuNo can't assign -1.");
                //else if (exitCount > 0)
                //Console.WriteLine("Error: score can't assign -1.");
                else
                {
                    if (list.IsEmpty())
                    {
                        list.InsertAtFront(data);
                    }
                    else if (list.GetNodeByStuNo(data[0]) != null)
                    {
                        Console.WriteLine("Error: stuNo is Duplicated.");
                    }
                    else
                    {
                        list.InsertByAverage(data);
                    }
                }
            } while (true);
        }
    }
}
