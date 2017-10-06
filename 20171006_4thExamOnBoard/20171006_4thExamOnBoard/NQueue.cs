using System;
namespace _4thExamOnBoard
{
    public class NQueue
    {
        // Attributes
        private ListNode dummy;
        private ListNode front, rear;  //Pop從front取, Push從rear加
        private int dataCount;

        // Consructor
        public NQueue()
        {
            this.dummy = new ListNode("Dummy.");
            this.front = this.dummy;
            this.rear = this.dummy;
            this.dataCount = 0;
        }
        public NQueue(string d)
        {
            this.dummy = new ListNode("Dummy.");
            this.front = this.dummy;
            this.rear = new ListNode(d);
            this.dummy.SetLink(this.rear);
            this.dataCount = 1;
        }

        // Method
        public bool IsEmpty()
        {
            if (this.dataCount == 0)
                return true;
            return false;
        }
        public void Push(string d)
        {
            if (IsEmpty())
            {
                this.rear = new ListNode(d);
                this.dummy.SetLink(this.rear);
                this.dataCount++;
            }
            else
            {
                this.rear.SetLink(new ListNode(d));
                this.rear = this.rear.GetLink();
                this.dataCount++;
            }
        }
        public string Pop()
        {
            if (IsEmpty())
                return null;
            else
            {
                this.front = this.dummy.GetLink(); // dummy next
                this.dummy.SetLink(this.front.GetLink()); // dummy next next
                this.dataCount--;
                return this.front.GetData();
            }
        }
        public string RandomGet()
        {
			if (IsEmpty())
				return null;
			else
			{
                if(this.dataCount == 1)
                {
                    this.front = this.dummy.GetLink();
                    this.dummy.SetLink(this.front.GetLink());
                    this.dataCount--;
                    return this.front.GetData();
                }
                else
                {
                    Random rand = new Random();
                    int index = rand.Next(1, this.dataCount);
                    ListNode temp = this.dummy.GetLink();
                    ListNode prev = this.dummy;
                    for (int i = 2; i <= index;i++)
                    {
                        prev = temp;
                        temp = temp.GetLink();
                    }
                    prev.SetLink(temp.GetLink());
                    this.dataCount--;
                    return temp.GetData();
                }
			}
        }
        public void Output()
        {
            if (IsEmpty())
            {
                //Console.WriteLine("is Empty.");
                return;
            }
            ListNode temp = this.dummy.GetLink(); // dummy next
            while (temp != null)
            {
                Console.Write(temp.GetData() + " ");
                temp = temp.GetLink();
            }
            Console.WriteLine();
        }
        public int GetLength()
        {
            return this.dataCount;
        }
    }
}
