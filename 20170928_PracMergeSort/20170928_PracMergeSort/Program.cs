using System;

namespace _PracMergeSort
{
    class MainClass
    {
        static int executeCount = 0;
        public static void Main(string[] args)
        {
            // Test
            Test();


        }

        public static void Test()
        {
            long t1 = DateTime.Now.ToFileTime();
            int[] arr1 = { 5, 26, 77, 1, 61, 11, 15, 59, 19, 48 };
            nMergeSort(arr1, 0, arr1.Length - 1);
            PrintArr(arr1);
            long t2 = DateTime.Now.ToFileTime();
            Console.WriteLine("arr1 - Execute Count = " + executeCount + " time:" + (t2 - t1));
            executeCount = 0;


            int[] arr2 = { 26, 5, 77, 1, 61, 11, 59, 15, 48, 19 };
            nMergeSort(arr2, 0, arr2.Length - 1);
            PrintArr(arr2);
            Console.WriteLine("arr2 - Execute Count = " + executeCount);
            executeCount = 0;

            int[] arr3 = { 1, 5, 11, 15, 19, 26, 48, 59, 61, 77 };
            nMergeSort(arr3, 0, arr3.Length - 1);
            PrintArr(arr3);
            Console.WriteLine("arr3 - Execute Count = " + executeCount);
            executeCount = 0;

            int[] arr4 = { 77, 61, 59, 48, 26, 19, 15, 11, 5, 1 };
            nMergeSort(arr4, 0, arr4.Length - 1);
            PrintArr(arr4);
            Console.WriteLine("arr4 - Execute Count = " + executeCount);
            executeCount = 0;
        }
        public static void nMergeSort(int[] a, int start, int end)
        {
            for (int j = 0; j < a.Length / 2; j++)
            {
                int spSta = start;
                int spMid = 0;
                int spCount = 0;
                for (int i = start; i < end; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        spCount++;
                        if (spCount % 2 == 1)
                        {
                            spMid = i;
                            if (i == end - 1)
                            {
                                MergeList(a, spSta, spMid, end);
                            }
                        }
                        else
                        {
                            MergeList(a, spSta, spMid, i);
                            spSta = i + 1;
                        }
                    }
                }
                if (spCount == 1)
                    MergeList(a, start, spMid, end);
                if (spCount == 0)
                    break;
            }
        }
        public static void MergeList(int[] a, int s, int m, int e)
        {
            int[] temp = new int[a.Length];
            int i = s;
            int j = m + 1;
            int k = i;
            while (i <= m && j <= e)
            {
                if (a[i] < a[j])
                    temp[k++] = a[i++];
                else
                    temp[k++] = a[j++];
            }
            if (i > m)
                for (int t = j; t <= e; t++)
                    temp[k++] = a[t];
            else
                for (int t = i; t <= m; t++)
                    temp[k++] = a[t];
            for (int l = s; l <= e; l++)
            {
                a[l] = temp[l];
            }
            executeCount++;
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
