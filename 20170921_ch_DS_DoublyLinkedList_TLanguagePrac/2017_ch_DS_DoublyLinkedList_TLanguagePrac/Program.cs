using System;
using System.IO;

namespace _ch_DS_DoublyLinkedList_TLanguagePrac
{
    class MainClass
    {
        // static
        //static string sourceFile;
        //static string destinationFile;
        static DoublyLinkedList list;
        static Node currenNode;
        static int totalLineCount;
        static int currenLine;
        static int reg;

        public static void Main(string[] args)
        {
            //test();
            do
            {
                if (opCompile())
                    break;
            } while (true);
            menu();
        }
        public static void menu()
        {
            do
            {
                Console.WriteLine("1. Next Step, 2. Last Step, 3. Compile, -1. Quit: ");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        opNextStep();
                        break;
                    case "2":
                        opLastStep();
                        break;
                    case "3":
                        do
                        {
                            if (opCompile())
                                break;
                        } while (true); 
                        break;
                    case "-1":
                        Console.WriteLine(" Exit. ");
                        return;
                    default:
                        Console.WriteLine("Error: option input invalid.");
                        break;
                }
            } while (true);

        }
        public static void opNextStep()
        {
            if (currenNode.GetNextLink() == null)
            {
                Console.WriteLine("Here's End of Code. \nResult = " + reg);
            }
            else
            {
                currenNode = currenNode.GetNextLink();
                currenLine++;
                Console.WriteLine("Line code: " + currenNode.GetData());
                Console.WriteLine("Result: " + currenNode.GetRegister());
            }
        }
        public static void opLastStep()
        {
            if (currenLine > totalLineCount)
            {
                currenLine--;
                Console.WriteLine("Line code: " + currenNode.GetData());
                Console.WriteLine("Result: " + currenNode.GetRegister());
            }
            else if (currenNode.GetPrevLink().GetData() == "Dummy")
            {
                Console.WriteLine("Here's Begin of Code. \nResult = 0");
            }
            else
            {
                currenNode = currenNode.GetPrevLink();
                currenLine--;
                Console.WriteLine("Line code: " + currenNode.GetData());
                Console.WriteLine("Result: " + currenNode.GetRegister());
            }
        }
        public static bool opCompile()
        {
			// reset static
			list = new DoublyLinkedList();
			currenLine = 0;
			reg = 0;

            Console.WriteLine("Command: ");
            string scan = Console.ReadLine();
            if (scan.StartsWith("T "))
            {
                string scanFileName = scan.Substring(2);
                string[] arrS = scanFileName.Split(' ');
                if (arrS.Length < 2)
                {
                    if (scanFileName.EndsWith(".t"))
                    {
                        try
                        {
                            FileStream fromStream = new FileStream(scanFileName, FileMode.Open, FileAccess.Read);
                        }
                        catch 
                        {
                            Console.WriteLine("Command error!\n");
                            return false;
                        }
                        if(loadInAndCompile(scanFileName))
                         return true;
                    }
                }
            }
            Console.WriteLine("Command error!");
            return false;
        }
        public static bool loadInAndCompile(string sourceFile)
        {
            Console.WriteLine(" load in " + sourceFile + ", and compile.");
            try
            {
                FileStream fromStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fromStream);
                string readStr;
                while ((readStr = sw.ReadLine()) != null)
                {
                    if (readStr == "")
                        continue;
                    // check last is ";"
                    if (readStr.EndsWith(";"))
                    {
                        readStr = readStr.Substring(0, readStr.Length - 1);
                        string[] token = readStr.Split(' ');
                        if (String.Compare(token[0], "load", true) == 0)
                        {
                            if (token.Length > 2)
                            {
                                Console.WriteLine("Synax Error. ");
                                return false;
                            }
                            // check have args
                            int args = Int32.Parse(token[1]);
                            reg = args;
                            list.InsertAtRear(new Node(readStr, token[0], args, reg));
                        }
                        else if (String.Compare(token[0], "add", true) == 0)
                        {
                            if (token.Length > 2)
                            {
                                Console.WriteLine("Synax Error. ");
                                return false;
                            }
                            int args = Int32.Parse(token[1]);
                            reg += args;
                            list.InsertAtRear(new Node(readStr, token[0], args, reg));
                        }
                        else if (String.Compare(token[0], "prt", true) == 0)
                        {
                            if (token.Length > 1)
                            {
                                Console.WriteLine("Synax Error. ");
                                return false;
                            }
                            list.InsertAtRear(new Node(readStr, token[0], -1, reg));
                        }
                        else
                        {
                            Console.WriteLine(" Synax Error. ");
                            return false;
                        }
                    }
                    // compelete one line
                    currenLine++;
                }
                totalLineCount = currenLine;
                currenLine++;
                currenNode = list.GetRearNode();
                Console.WriteLine("result: " + reg);

                // test
                //Node temp = list.GetHeadNode();
                //while(temp != null)
                //{
                //    Console.WriteLine(temp.GetData());
                //    temp = temp.GetNextLink();
                //}

                // close
                fromStream.Close();
                sw.Close();
            }
            catch
            {
                Console.WriteLine(" Synax Error. ");
                return false;
            }
            return true;
        }
        public static void test()
        {
            // - load in file
            Console.WriteLine(" ------ load in file ------");
            string readFile = "program.t";
            int reg = 0;
            try
            {
                FileStream fromStream = new FileStream(readFile, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fromStream);
                string readStr;
                while ((readStr = sw.ReadLine()) != null)
                {
                    //Console.WriteLine(readStr);
                    if (readStr == "")
                        continue;
                    // check last is ";"
                    if (readStr.EndsWith(";"))
                    {
                        Console.Write(readStr + "  \tOK.\t");
                        readStr = readStr.Substring(0, readStr.Length - 1);
                        //Console.WriteLine(readStr);
                        string[] token = readStr.Split(' ');
                        //int args = Int32.Parse(token[1]);
                        if (String.Compare(token[0], "load", true) == 0)
                        {
                            int args = Int32.Parse(token[1]);
                            reg = args;
                        }
                        else if (String.Compare(token[0], "add", true) == 0)
                        {
                            int args = Int32.Parse(token[1]);
                            reg += args;
                        }
                        else if (String.Compare(token[0], "prt", true) == 0)
                        {
                            Console.Write(" -call print.\t");
                        }
                        else
                        {
                            Console.WriteLine(" Synax Error. ");
                            break;
                        }
                        Console.WriteLine("reg = " + reg);
                    }
                }
                // close
                fromStream.Close();
                sw.Close();
            }
            catch
            {
                //Console.WriteLine(e);
                Console.WriteLine(" Synax Error. ");
            }

            // - DoublyLinkedList
            Console.WriteLine(" ------ Doubly Linked List ------");
            DoublyLinkedList testList = new DoublyLinkedList();
            Node keyNode = new Node("key1", "key", 1, 0);
            // Check
            Console.WriteLine(testList.IsEmpty());
            // Delete
            Console.WriteLine(testList.Delete("key1"));
            // Insert "key1" - at rear
            testList.InsertAtRear(keyNode);
            // Get
            Console.WriteLine(testList.GetNodeByKey("key1").GetData());

            // Check
            Console.WriteLine(testList.IsEmpty());
            // Delete
            Console.WriteLine(testList.Delete("key1"));
            Console.WriteLine(testList.IsEmpty());

            // Insert more node
            testList.InsertAtRear(new Node("key2", "key", 2, 0));
            testList.InsertAtRear(new Node("key3", "key", 3, 0));
            testList.InsertAtRear(new Node("key4", "key", 4, 0));
            Node search = testList.GetNodeByKey("key3");

            Console.WriteLine("--------------------");
            Console.WriteLine(testList.IsEmpty());
            Console.WriteLine(search.GetData());
            Console.WriteLine("--");
            Console.WriteLine(search.GetPrevLink().GetData());
            Console.WriteLine(search.GetPrevLink().GetPrevLink().GetData());
            //Console.WriteLine(search.GetPrevLink().GetPrevLink().GetPrevLink().GetPrevLink().GetData());
            Console.WriteLine("--");
            Console.WriteLine(search.GetNextLink().GetData());
            //Console.WriteLine(search.GetNextLink().GetNextLink().GetData());
            //Console.WriteLine(search.GetNextLink().GetNextLink().GetNextLink().GetData());
        }
    }
}
