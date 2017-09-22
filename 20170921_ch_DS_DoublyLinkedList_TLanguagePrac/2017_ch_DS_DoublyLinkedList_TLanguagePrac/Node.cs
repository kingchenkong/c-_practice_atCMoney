using System;
namespace _ch_DS_DoublyLinkedList_TLanguagePrac
{
    public class Node
    {
        private string data;
        private string command;
        private int args;
        private int reg;
        private Node prevLink;
        private Node nextLink;

        public Node(string line, string com, int a, int r)
        {
            this.data = line;
            this.command = com;
            this.args = a;
            this.reg = r;
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
        public string GetCommand()
        {
            return this.command;
        }
        public int GetArgs()
        {
            return this.args;
        }
        public int GetRegister()
        {
            return this.reg;
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
