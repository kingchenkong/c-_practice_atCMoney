using System;

namespace _QuickSort_practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Test part
            Test();
            // Main part
            // - load in file
            Trader trader = new Trader("testfile.csv");
            // - sort file as "成交價"
            trader.SortByPrice(0, trader.GetDataCount() - 1);
            // - set output file name
            do
            {
                Console.WriteLine("input the Export File Name:");
                string scanFileName = Console.ReadLine();
                string[] arrSplit = scanFileName.Split('.');

                // - Foolproof
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
                trader.ExportFile();
            } while (true);

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
