using System;
using System.IO;
using System.Diagnostics;

namespace _ExternalSort
{
    class MainClass
    {
        // watch
        static Stopwatch watch = new Stopwatch();
        static string titleLine;
        static int dataCountOnePart = 50000;
        static string outputFileName = "output.csv";

        public static void Main(string[] args)
        {
            //初始化Stopwatch
            watch.Reset();

            // Test
            //TestForBuffer();
            //TestForSort();

            // watch start
            watch.Start();

            // split to - 'x' part
            string filePath = "timetable.csv";
            int partCount = SplitToXPart(filePath, dataCountOnePart);
            Console.WriteLine(partCount + " part.");

            // merge and sort to one file.

            MergeAndSortToOne(partCount);

            // watch stop
            watch.Stop();

            Console.WriteLine(" ----- test result ----- ");
            for (int i = 0; i < partCount;i++)
            {
                string fileName = string.Format("p{0}.csv", i);
                Console.WriteLine(fileName);

				FileStream fromStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				StreamReader srf = new StreamReader(fromStream);

				int errorCountf = 0;
				int nowLinef = 0;
                string readStrf;
				BusTable lastDataf = new BusTable(srf.ReadLine());
                BusTable nowDataf;
				while ((readStrf = srf.ReadLine()) != null)
				{
                    nowDataf = new BusTable(readStrf);
					if (nowDataf.offTime < lastDataf.offTime)
					{
                        errorCountf++;
						Console.WriteLine("errorLine: " + nowLinef + ", count: " + errorCountf);
					}
                    lastDataf.data = nowDataf.data;
                    lastDataf.offTime = nowDataf.offTime;
                    nowLinef++;
				}

            }

            // test sort is ok
            int errorCount = 0;
            int nowLine = 0;
            string readStr;
            outputFileName = "output.csv";
            FileStream fs = new FileStream(outputFileName, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(fs);
            sr.ReadLine();//title 
            BusTable lastData = new BusTable(sr.ReadLine());
            BusTable nowData;
            while((readStr = sr.ReadLine()) != null)
            {
                nowData = new BusTable(readStr);
                if (nowData.offTime < lastData.offTime)
				{
					errorCount++;
                    Console.WriteLine("errorLine: " + nowLine + ", count: " + errorCount);
                }
                lastData.data = nowData.data;
                lastData.offTime = nowData.offTime;
                nowLine++;
            }

            // output Total ms
            Console.WriteLine("Stopwatch Mathod: {0}ms", watch.Elapsed.TotalMilliseconds);
        }
        public static void MergeAndSortToOne(int partCount)
        {
            // 開 x 個串列
            // - from
            FileStream[] fromStream = new FileStream[partCount];
            StreamReader[] sr = new StreamReader[partCount];
            for (int i = 0; i < partCount; i++)
            {
                string fileName = string.Format("p{0}.csv", i);
                fromStream[i] = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr[i] = new StreamReader(fromStream[i]);
            }
            // - to
            FileStream toStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(toStream);
            sw.WriteLine(titleLine);

            // sort
            // buffer and index
            int lenBuf = 1000;
            int[] indexFile = new int[partCount];
            int[] indexBuf = new int[partCount];
            string[,] buf = new string[partCount, lenBuf];
            string readStr;
            for (int j = 0; j < partCount; j++)
            {
                for (int i = 0; i < lenBuf; i++)
				{
                    if ((readStr = sr[j].ReadLine()) == null)
                        break;
                    buf[j,i] = readStr;
                    indexFile[j]++;
                }
            }
            // Heap tree
            int[] arrMark = new int[partCount];
            BusTable[] arrTree = new BusTable[partCount];
            for (int i = 0; i < partCount; i++)
            {
                arrTree[i] = new BusTable(buf[i, 0]);
                arrMark[i] = i;
                indexBuf[i] = 1;
            }
			// test
			//for (int i = 0; i < partCount; i++)
			//{
			//  Console.WriteLine("arrBt[" + i + "] = " + arrBt[i].data);
			//	Console.WriteLine("arrMark[" + i + "] = " + arrMark[i]);
			//	Console.WriteLine("indexbuf[" + i + "] = " + indexbuf[i]);
			//  Console.WriteLine("indexFile[" + i + "] = " + indexFile[i]);
			//}

			// not empty part
			//int streamCount = partCount;
            int testCount = 0;
            while (true)
            {
                
                // adjust
                //for (int i = 0; i < (partCount - 1) / 2; i++)
                BTAdjustWithMark(arrTree, arrMark, 0, partCount);
                // output arrBt[0]
                sw.WriteLine(arrTree[0].data);
                testCount++;
                //if (testCount == 61)
                    //Console.WriteLine("is here.");
                // reloading Tree
                arrTree[0].data = buf[0, indexBuf[0]++];
                arrTree[0].SetOffTime();
                // check indexbuf
                for (int k = 0; k < partCount; k++)
                {
                    if (indexBuf[k] == lenBuf - 1)
                    {
                        // reloading buf
                        indexBuf[k] = 0;
                        for (int i = 0; i < lenBuf; i++)
                        {
							if ((readStr = sr[k].ReadLine()) == null)
							{
                                // file is empty
                                indexFile[k] = -1;
								break;
                            }
							buf[k, i] = readStr;
							indexFile[k]++;
						}
					}
                }
                // check indexFile
                for (int i = 0; i < partCount; i++)
                {
                    if (indexBuf[i] == 0 && indexFile[i] == -1)
                    {
						// buf & file is empty
						partCount--;

						// swap root and last child
                        // arrTree
                        BusTable tempBT = arrTree[i];
						arrTree[i] = arrTree[partCount];
						arrTree[partCount] = tempBT;
                        // sr
                        StreamReader tempSR = sr[i];
                        sr[i] = sr[partCount];
                        sr[partCount] = tempSR;
                        // arrMark
                        //temp = arrMark[i];
                        //arrMark[i] = arrMark[partCount];
                        //arrMark[partCount] = temp;
                        // indexFile
                        int temp = indexFile[i];
                        indexFile[i] = indexFile[partCount];
                        indexFile[partCount] = temp;
						// indexBuf
                        temp = indexBuf[i];
						indexBuf[i] = indexBuf[partCount];
						indexBuf[partCount] = temp;

						// close
                        sr[partCount].Close();
					}
                }
                // break?
                if (partCount == 0)
                    break;
            }
            sw.Close();
            toStream.Close();
        }
        public static void BTAdjustWithMark(BusTable[] arrBt, int[] mark, int root, int n)
		{
			BusTable temp = arrBt[root];
            int tempMark = root;
			int child = 2 * root + 1; // left child
			while (child < n) // 做到最後一層的子節點
			{
				if ((child < n - 1) && (arrBt[child].offTime > arrBt[child + 1].offTime))
					child++;
				if (temp.offTime < arrBt[child].offTime) // 比較 root 和 左右二子中 smaller者
					break;
				else
				{
					arrBt[(child - 1) / 2] = arrBt[child]; // 子節點 smaller 就交換
                    mark[(child - 1) / 2] = mark[child];
					child = 2 * child + 1;
				}
			}
			arrBt[(child - 1) / 2] = temp; // 回到前一個(終止會超過一層)  
            mark[(child - 1) / 2] = tempMark;
		}
        public static int SplitToXPart(string path, int n)
        {
            // one part, 'n' items.
            int x = 0;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            // get title
            titleLine = sr.ReadLine();
            // split
            string readStr;
            while ((readStr = sr.ReadLine()) != null)
            {
                BusTable[] arrBt = new BusTable[n];
                arrBt[0] = new BusTable(readStr);
                int c = 0;
                for (c = 1; c < n; c++)
                {
                    if ((readStr = sr.ReadLine()) == null)
                        break;

                    arrBt[c] = new BusTable(readStr);
                }

                // sort
                BTHeapSort(arrBt, c);

                // fomat: p{0}.csv, x
                string nameNewFile = string.Format("p{0}.csv", x);
                FileStream toStream = new FileStream(nameNewFile, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(toStream);

                for (int i = 0; i < n; i++)
                {
                    if (arrBt[i] == null)
                        break;
                    sw.WriteLine(arrBt[i].data);
                }
                sw.Flush();
                sw.Close();
                toStream.Close();
                x++;
            }
            return x;
        }
        public static void BTHeapSort(BusTable[] arr, int n)
        {
            for (int i = (n - 1) / 2; i >= 0; i--)
                BTAdjust(arr, i, n);
            for (int i = n - 2; i >= 0; i--)
            {
                BTSwap(arr, 0, i + 1);
                BTAdjust(arr, 0, i + 1);
            }
        }
        public static void BTSwap(BusTable[] arr, int i, int j)
        {
            BusTable temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void BTAdjust(BusTable[] arr, int root, int n)
        {
            BusTable temp = arr[root];
            int child = 2 * root + 1; // left child
            while (child < n) // 做到最後一層的子節點
            {
                if ((child < n - 1) && (arr[child].offTime < arr[child + 1].offTime))
                    child++;
                if (temp.offTime > arr[child].offTime) // 比較 root 和 左右二子中較大者
                    break;
                else
                {
                    arr[(child - 1) / 2] = arr[child]; // 子節點較大就交換
                    child = 2 * child + 1;
                }
            }
            arr[(child - 1) / 2] = temp; // 回到前一個(終止會超過一層)   
        }
        // Test
        public static void TestForBuffer()
        {
            FileStream fs = new FileStream("timetable.csv", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string title = sr.ReadLine();
            sr.Close();
            fs.Close();
            //string readStr = sr.ReadLine();
            //BusTable[] btArr = new BusTable[10];

            // Declare
            int alreadyLoadCount = 1;
            int arrLen = 10;
            BusTable[] bt0 = new BusTable[arrLen];
            BusTable[] bt1 = new BusTable[arrLen];
            BusTable[] bt2 = new BusTable[arrLen];
            BusTable[] bt3 = new BusTable[arrLen];
            BusTable[] bt4 = new BusTable[arrLen];
            BusTable[] bt5 = new BusTable[arrLen];
            BusTable[] bt6 = new BusTable[arrLen];
            // Initial
            InitBuf(bt0);
            InitBuf(bt1);
            InitBuf(bt2);
            InitBuf(bt3);
            InitBuf(bt4);
            InitBuf(bt5);
            InitBuf(bt6);
            // load in first time
            alreadyLoadCount = LoadInBuf(bt0, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt1, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt2, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt3, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt4, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt5, alreadyLoadCount);
            alreadyLoadCount = LoadInBuf(bt6, alreadyLoadCount);
            // alreadyLoadCount = 71, 1 = title;
            // Console.WriteLine("first loading - alreadyLoadCount = " + alreadyLoadCount);

            // heapSort? adj?

            // arrLen to ??

            // last time load in arr => nexttime load




        }
        public static int LoadInBuf(BusTable[] arr, int skip)
        {
            FileStream fs = new FileStream("timetable.csv", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            // skip
            for (int i = 0; i < skip; i++)
                sr.ReadLine();
            // load int
            int index = 0;
            int l = arr.Length;
            string readStr;
            while ((readStr = sr.ReadLine()) != null)
            {
                arr[index].data = readStr;
                arr[index++].SetOffTime();
                if (index == l)
                    return skip + l;
            }
            return -1;
        }
        public static void InitBuf(BusTable[] arr)
        {
            int index = 0;
            int l = arr.Length;
            while (index < l)
            {
                arr[index] = new BusTable("");
                index++;
            }
        }
        public static void TestForSort()
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

            // sort
            MyHeapSort(a0, countOnePart);
            MyHeapSort(a1, countOnePart);
            MyHeapSort(a2, countOnePart);
            MyHeapSort(a3, countOnePart);
            MyHeapSort(a4, countOnePart);



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
            int lastExportArrNo = 0;
            // register last in tree number come from
            // if out a0[i] then load a0[i+1]

            for (int i = 5; i < buf.Length; i++)
            {
                buf[i - 5] = tree[0];
                nowNo = lastExportNum;
                switch (nowNo)
                {
                    case 0:
                        tree[0] = a0[indexA0++];
                        lastExportNum = 0;
                        break;
                    case 1:
                        tree[0] = a1[indexA1++];
                        lastExportNum = 1;
                        break;
                    case 2:
                        tree[0] = a2[indexA2++];
                        lastExportNum = 2;
                        break;
                    case 3:
                        tree[0] = a3[indexA3++];
                        lastExportNum = 3;
                        break;
                    case 4:
                        tree[0] = a4[indexA4++];
                        lastExportNum = 4;
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
