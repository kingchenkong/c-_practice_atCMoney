using System;
namespace _CH_DS_LinkedList_Practice_Score.Properties
{
    public class Node
    {
        private int[] data = new int[3]; // [ stuNo, enScore, maScore]
        private int av;
        private Node link;
        public Node(int[] d)
        {
            this.data[0] = d[0];
            this.data[1] = d[1];
            this.data[2] = d[2];
            this.av = (data[0] + data[1]) / 2;
            this.link = null;
        }
        public void SetLink(Node link)
        {
            this.link = link;
        }
        public Node GetLink()
        {
            return this.link;
        }
        public int[] GetData()
        {
            return this.data;
        }
        public int GetAv()
        {
            return this.av;
        }
    }
}
