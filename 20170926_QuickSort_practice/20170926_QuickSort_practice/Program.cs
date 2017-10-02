using System;

namespace _QuickSort_practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Test part
            //Test();
            // Main part
            // - load in file
            String importFileName = "testfile.csv";
            Trader trader = new Trader(importFileName);
            Console.WriteLine("file: " + importFileName);
            // - sort file as "成交價"
            do
            {
                Console.WriteLine("option: 1)Qucik Sort 2)Merge Sort-natural 3)MergeSort-Recusive 4)Heap Sort : ");
                string op = Console.ReadLine();
                if (op == "1")
                {
                    trader.QuickSortByPrice(0, trader.GetDataCount() - 1);
                    break;
                }
                else if (op == "2")
                {
                    trader.MergeSortByPrice(0, trader.GetDataCount() - 1);
                    break;
                }
                else if (op == "3")
                {
					trader.RecusiveMergeSortByPrice(0, trader.GetDataCount() - 1);
					break;
                }
                else if (op == "4")
                {
                    trader.HeapSortByPrice(trader.GetDataCount());
                    break;
                }
                else
                    Console.WriteLine("Error: input illegal.");
            } while (true);
            // - set output file name
            string scanFileName;
			do
            {
                Console.WriteLine("input the Export File Name:");
                scanFileName = Console.ReadLine();
                string[] arrSplit = scanFileName.Split('.');

                // - Foolproof
                if (arrSplit.Length == 1)
                {
                    scanFileName += ".csv";
                    break;
                }
                else if (arrSplit.Length > 2 || arrSplit.Length == 0)
                {
                    Console.WriteLine("Error: File Name illegal.");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);
            trader.SetDestinationFileName(scanFileName);
            trader.ExportFile();

        }
        public static void Test()
        {
            // test PracQuickSort
            int[] arr = { 5, 19, 10, 2, 1, 3, 2, 7, 2 };
            PracQuickSort(arr, 0, arr.Length - 1);
            PrintArr(arr);
        }
        public static Stock[] Resize(Stock[] arr)
        {
            Stock[] copy = new Stock[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
                copy[i] = arr[i];
            return copy;
        }
        public static void PracQuickSort(int[] a, int left, int right)
        {

            if (left >= right)
                return;
            int pivot = left;
            int i = left;
            int j = right + 1;
            while (i < j)
            {
                do i++; while (i < right + 1 && a[i] < a[pivot]);
                do j--; while (a[j] > a[pivot]);
                if (i < j)
                    PracSwap(a, i, j);
            }
            PracSwap(a, pivot, j);
            PracQuickSort(a, left, j - 1);  // Part left
            PracQuickSort(a, j + 1, right); // Part right
        }
        public static void PracSwap(int[] a, int index1, int index2)
        {
            int temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }
        public static void PrintArr(int[] a)
        {
            Console.Write("\n arr = { ");
            for (int i = 0; i < a.Length; i++)
            {

                if (i == a.Length - 1)
                    Console.Write(" {0}", a[i]);
                else
                    Console.Write(" {0},", a[i]);
            }
            Console.WriteLine(" }");
        }
    }
}
