using System;
namespace _HashTable
{
    public class Node
    {
        public int data;
        public Node link;
        public Node(int d)
        {
            this.data = d;
            this.link = null;
        }
    }
}
