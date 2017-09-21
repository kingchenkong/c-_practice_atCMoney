using System;

namespace _ch_DS_DoublyLinkedList_TLanguagePrac
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            test();



        }


        public static void test()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            Node keyNode = new Node("key1");
            // Check
            Console.WriteLine(list.IsEmpty());
            // Delete
            Console.WriteLine(list.Delete("key1"));
            // Insert "key1" - at rear
            list.InsertAtRear(keyNode);
            // Get
            Console.WriteLine(list.GetNode("key1").GetData());

            // Check
            Console.WriteLine(list.IsEmpty());
            // Delete
            Console.WriteLine(list.Delete("key1"));
            Console.WriteLine(list.IsEmpty());

            // Insert more node
            list.InsertAtRear(new Node("key2"));
            list.InsertAtRear(new Node("key3"));
            list.InsertAtRear(new Node("key4"));
            Node search = list.GetNode("key3");

            Console.WriteLine("--------------------");
            Console.WriteLine(list.IsEmpty());
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
