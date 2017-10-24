using System;
namespace _Algorithm_Graph
{
    public class LinkedList
    {
        Node first;
        public LinkedList()
        {
            this.first = null;
        }
        public LinkedList(int d)
        {
            this.first = new Node(d);
        }
        public void Insert(int num)
        {
            if (this.first == null)
                first = new Node(num);
            else
            {
                Node temp = this.first;
                while (temp.link != null)
                {
                    temp = temp.link;
                }
                temp.link = new Node(num);
            }
        }
        public Node Search(int key)
        {
            if (this.first == null)
            {
                return null;
            }

            Node temp = this.first;
            while (temp != null)
            {
                if (temp.data == key)
                    break;
                else
                    temp = temp.link;
            }
            return temp;

        }
        public bool IsEmpty()
        {
            if (this.first == null)
                return true;
            return false;
        }
        public void OutputListEdge(int index)
        {
            if (this.first == null)
                return;
            Node temp = this.first;
            while(temp != null)
            {
                Console.WriteLine("Edge({0},{1})", index + 1, temp.data);
                temp = temp.link;
            }
        }
        public bool DeleteListEdge(int key)
        {
            if (this.first == null)
                return false;
            Node temp = this.first;
            if(temp.data == key)
            {
                this.first = temp.link;
                return true;
            }
            Node prev = temp;
            temp = temp.link;
            while(temp != null)
            {
                if(temp.data == key)
                {
                    prev.link = temp.link;
                    return true;
                }
                else
                {
                    prev = temp;
                    temp = temp.link;
                }
            }
            return false;
        }
    }
}
