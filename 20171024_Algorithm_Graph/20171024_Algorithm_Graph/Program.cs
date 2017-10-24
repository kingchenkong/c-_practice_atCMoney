using System;

namespace _Algorithm_Graph
{
    class MainClass
    {
        static LinkedList[] headNode;
        public static void Main(string[] args)
        {
            int nodeCount = 0;
            do
            {
                Console.WriteLine(" Input node count(0 to Quit.): ");
                string scan = Console.ReadLine();
                bool isScanNum = int.TryParse(scan, out nodeCount);
                //Console.WriteLine(isScanNum);
                if (isScanNum)
                    if (nodeCount == 0)
                    {
                        Console.WriteLine("Bye~");
                        return;
                    }
                    else if (nodeCount < 0)
                    {
                        Console.WriteLine("Error: Invalid number.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                else
                    Console.WriteLine("Error: Input format error.");
            } while (true);

            // construct headNode.
            headNode = new LinkedList[nodeCount];

            // menu
            do
            {
                Console.WriteLine("1)Insert 2)Output 3) Delete -1)Quit:");
                string scanOp = Console.ReadLine();
                switch (scanOp)
                {
                    case "-1":
                        Console.WriteLine("Bye~");
                        return;
                    case "1":
                        bool isInputInvalid = false;
                        do
                        {
                            isInputInvalid = InsertEdge();
                        } while (!isInputInvalid);
                        break;
                    case "2":
                        OutputEdge();
                        break;
                    case "3":
                        DeleteEdge();
                        break;
                    default:
                        Console.WriteLine("Error: Input error.");
                        break;
                }

            } while (true);




        }
        public static void DeleteEdge()
        {
            Console.WriteLine("input Start-Vertex : ");
            string scanStr = Console.ReadLine();
            bool isScanNum = int.TryParse(scanStr, out int startVertex);
            if(!isScanNum)
            {
                Console.WriteLine("Error: input FORMAT error.");
                return;
            }
            if(startVertex <= 0)
            {
                Console.WriteLine("Error: input RANGE error.");
                return;
            }
            if (headNode[startVertex - 1] == null || headNode[startVertex - 1].IsEmpty())
            {
                Console.WriteLine("Error: headNode[" + (startVertex - 1) + "] => null");
                return;
            }

            Console.WriteLine("input End-Vertex : ");
            scanStr = Console.ReadLine();
            isScanNum = int.TryParse(scanStr, out int endVertex);
            if (!isScanNum)
            {
                Console.WriteLine("Error: input FORMAT error.");
                return;
            }
            if (endVertex <= 0)
            {
                Console.WriteLine("Error: input RANGE error.");
                return;
            }

            headNode[startVertex - 1].DeleteListEdge(endVertex);

        }
        public static void OutputEdge()
        {
            for (int i = 0; i < headNode.Length; i++)
            {
                //Console.Write("Vertex " + i + ": ");
                if(headNode[i] !=null)
                {
                    headNode[i].OutputListEdge(i);
                }
            }
        }
        public static bool InsertEdge()
        {
            int maxVertex = headNode.Length;
            int startVertex;
            int endVertex;

            int inputNum = 0;
            Console.WriteLine("input Start-Vertex (-1 to Quit) : ");
            string scanStr = Console.ReadLine();
            bool isScanNum = int.TryParse(scanStr, out inputNum);
            // quit input
            if (scanStr == "-1")
                return true;
            // not number, false
            if (!isScanNum)
            {
                Console.WriteLine("Error: input must be Int.");
                return false;
            }
            // out range, false
            if (inputNum <= 0 || inputNum > maxVertex)
            {
                Console.WriteLine("Error: input num out range.");
                return false;
            }
            startVertex = inputNum;

            inputNum = 0;
            Console.WriteLine("intput End-maxVertex :");
            scanStr = Console.ReadLine();
            isScanNum = int.TryParse(scanStr, out inputNum);
            // not number, false
            if (!isScanNum)
            {
                Console.WriteLine("Error: input must be Int.");
                return false;
            }
            // out range, false
            if (inputNum <= 0 || inputNum > maxVertex)
            {
                Console.WriteLine("Error: input num out range.");
                return false;
            }
            // refrence self, false
            if (inputNum == startVertex)
            {
                Console.WriteLine("Error: End must different to start.");
                return false;
            }
            // edge duplicated, false
            if (headNode[startVertex - 1] == null)
            {
                headNode[startVertex - 1] = new LinkedList(inputNum);
                Console.WriteLine("New a edge: ( {0}, {1})", startVertex, inputNum);
                return true;
            }
            else if (headNode[startVertex - 1].Search(inputNum) != null)
            {
                Console.WriteLine("Error: input duplicated.");
                return false;
            }
            // invalid.
            endVertex = inputNum;
            headNode[startVertex - 1].Insert(endVertex);
            Console.WriteLine("New a edge: ( {0}, {1})", startVertex, endVertex);
            return true;

        }
    }

}
