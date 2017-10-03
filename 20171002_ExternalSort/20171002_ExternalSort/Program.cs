using System;
using System.Diagnostics;
using System.Threading;

namespace _ExternalSort
{
    class MainClass
    {
        // watch
        static Stopwatch sw = new Stopwatch();

        public static void Main(string[] args)
        {
            //初始化Stopwatch
            sw.Reset();

            // Test
            Test();

            // output Total ms
            Console.WriteLine("Stopwatch Mathod: {0}ms", sw.Elapsed.TotalMilliseconds);
        }
        public static void Test()
        {
            Console.WriteLine(" --- oridata :");
            int[] oriData = new int[100];
            Random ran = new Random();
            for (int i = 0; i < oriData.Length; i++)
                oriData[i] = ran.Next(100);
            //PrintArr(oriData);

            Console.WriteLine(" --- split :");
            // - split 7 part
            int part = 5;
            int countOnePart = oriData.Length / part;
            int indexStart = 0;
            int[] a0 = SplitPart(oriData, indexStart, countOnePart);
            indexStart += countOnePart;
            int[] a1 = SplitPart(oriData, indexStart, countOnePart);
            indexStart += countOnePart;
            int[] a2 = SplitPart(oriData, indexStart, countOnePart);
            indexStart += countOnePart;
            int[] a3 = SplitPart(oriData, indexStart, countOnePart);
            indexStart += countOnePart;
            int[] a4 = SplitPart(oriData, indexStart, countOnePart);
            indexStart += countOnePart;

            // print
            //PrintArr(a0);
            //PrintArr(a1);
            //PrintArr(a2);
            //PrintArr(a3);
            //PrintArr(a4);

            Console.WriteLine(" ------------------- sort ------------------- ");
            // watch start
            sw.Start();

            // sort
            MyHeapSort(a0, countOnePart);
            MyHeapSort(a1, countOnePart);
            MyHeapSort(a2, countOnePart);
            MyHeapSort(a3, countOnePart);
            MyHeapSort(a4, countOnePart);

            // watch stop
            sw.Stop();

            // //print
            PrintArr(a0);
            PrintArr(a1);
            PrintArr(a2);
            PrintArr(a3);
            PrintArr(a4);

            int[] buf = new int[50];
            int[] tree = { a0[0], a1[0], a2[0], a3[0], a4[0] };
            TreeAdj(tree, 0, 5);
            int nowNo = 0;
            int indexA0 = 1;
            int indexA1 = 1;
            int indexA2 = 1;
            int indexA3 = 1;
            int indexA4 = 1;
            int lastExportNum = tree[0];
            int lastExportArrNo = 

            for (int i = 5; i < buf.Length; i++)
            {
                buf[i-5] = tree[0];


                switch(nowNo)
                {
                    case 0:
                        tree[0] = a0[indexA0++];
                        break;
                    case 1:
                        tree[0] = a1[indexA1++];
                        break;
                    case 2:
                        tree[0] = a2[indexA2++];
                        break;
                    case 3:
                        tree[0] = a3[indexA3++];
						break;
					case 4:
                        tree[0] = a4[indexA4++];
                        break;
                    default:
                        Console.WriteLine("Error: switch error - " + nowNo);
                        break;
                }
                TreeAdj(tree, 0, 5);

            }

            Console.WriteLine(" ------------------- buf ------------------- ");
			PrintArr(buf);
        }
        public static void TreeAdj(int[] tree, int root, int n)
        {
            int index = 0;
            int temp = tree[root];
			int child = 2 * root + 1; // left child
            index = child;
			while (child < n) // 做到最後一層的子節點
			{
                if ((child < n - 1) && (tree[child] > tree[child + 1]))
                {
                    child++;

                }
				if (temp < tree[child]) 
					break;
				else
				{
                    tree[(child - 1) / 2] = tree[child];
					child = 2 * child + 1;
				}
			}
            tree[(child - 1) / 2] = temp; // 回到前一個(終止會超過一層)   
		}
        public static int[] SplitPart(int[] arr, int start, int countOnePart)
        {
            int[] temp = new int[countOnePart];
            for (int i = 0; i < countOnePart; i++)
            {
                temp[i] = arr[start + i];
            }
            return temp;
        }
        public static void MyHeapSort(int[] arr, int n)
        {
            for (int i = (n - 1) / 2; i >= 0; i--)
                Adjust(arr, i, n);
            for (int i = n - 2; i >= 0; i--)
            {
                Swap(arr, 0, i + 1);
                Adjust(arr, 0, i + 1);
            }
        }
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void Adjust(int[] arr, int root, int n)
        {
            int temp = arr[root];
            int child = 2 * root + 1; // left child
            while (child < n) // 做到最後一層的子節點
            {
                if ((child < n - 1) && (arr[child] < arr[child + 1]))
                    child++;
                if (temp > arr[child]) // 比較 root 和 左右二子中較大者
                    break;
                else
                {
                    arr[(child - 1) / 2] = arr[child]; // 子節點較大就交換
                    child = 2 * child + 1;
                }
            }
            arr[(child - 1) / 2] = temp; // 回到前一個(終止會超過一層)   
        }
        public static void PrintArr(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    Console.WriteLine(arr[i] + " }");
                else
                    Console.Write(arr[i] + ", ");
            }
        }

    }
}
