using System;
namespace _ch_DS_DoublyLinkedList_TLanguagePrac
{
    public class Node
    {
        private string data;
        private Node prevLink;
        private Node nextLink;

        public Node(string str)
        {
            this.data = str;
        }

        // Getter
        public Node GetPrevLink()
        {
            return this.prevLink;
        }
        public Node GetNextLink()
        {
            return this.nextLink;
        }
        public string GetData()
        {
            return this.data;
        }

        // Setter
        public void SetData(string str)
        {
            this.data = str;
        }
        public void SetPrevLink(Node newPrev){
            this.prevLink = newPrev;
        }
        public void SetNextLink(Node newNext)
        {
            this.nextLink = newNext;
        }
    }
}
