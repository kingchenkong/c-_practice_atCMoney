using System;

namespace _HeapSort
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 5, 19, 10, 1, 3, 14, 7, 2 };
            int[] arr2 = { 5, 19, 10, 2, 1, 3, 2, 7, 2 };

            // run
            Console.WriteLine(" -- arr 1 ");
            PrintArr(arr1);
            Console.Write(" --- after Sort \n --- ");
            MyHeapSort(arr1, arr1.Length);
            PrintArr(arr1);

            Console.WriteLine(" -- arr 2 ");
            PrintArr(arr2);
			Console.Write(" --- after Sort \n --- ");
			MyHeapSort(arr2, arr2.Length);
			PrintArr(arr2);

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
        public static void Swap(int[] arr, int i, int j){
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
            Console.Write("arr = { ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1)
                    Console.Write(arr[i] + ", ");
                else
                    Console.WriteLine(arr[i] + " }");
            }
        }
    }
}
