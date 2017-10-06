using System;
namespace _4thExamOnBoard
{
	public class LinkedList
	{
		private ListNode first;

		public LinkedList()
		{
			first = null;
		}
        public LinkedList(string data)
		{
			first = new ListNode(data);
		}
		public bool IsEmpty()
		{
			if (first == null)
				return true;
			return false;
		}
		// Get Node
		public ListNode GetNodeByStuNo(int stuNo)
		{
			ListNode tmp = first;
			while (tmp != null)
			{
				if (stuNo == tmp.GetData()[0]) // if stuNo == data[0]
					return tmp;
				tmp = tmp.GetLink(); // search next data
			}
			return null;
		}
		public ListNode GetNodeByIndex(int index)
		{
			ListNode tmp = first;
			int i = 0;
			while (i < index && tmp != null)
			{
				tmp = tmp.GetLink();
				i++;
			}
			return tmp;
		}
		// Insert
		public void InsertAtFront(int[] input)
		{
			ListNode newNode = new ListNode(input);
			newNode.SetLink(this.first);
			this.first = newNode;
		}
		public void InsertByAverage(int[] data)
		{
			ListNode tmp = first;
			ListNode prev = null;    //代表前一個節點
			int av = (data[0] + data[1]) / 2;
			while (tmp != null)
			{
				if (av > tmp.GetAv())
					break;
				prev = tmp;
				tmp = tmp.GetLink();
			}
			ListNode newNode = new ListNode(data);   //建置一個資料節點
			if (tmp == this.first)  //如果this.first是null，也在這個情況之中
			{   //新增到開頭
				newNode.SetLink(this.first);
				this.first = newNode;
			}
			else if (tmp == null)
			{   //新增在結尾
				prev.SetLink(newNode);
			}
			else
			{   //新增在中間
				newNode.SetLink(tmp);
				prev.SetLink(newNode);
			}

		}
		// Delete
		public bool DeleteByStuNo(int stuNo)
		{
			ListNode tmp = first;
			ListNode prev = null;    //代表前一個節點
			while (tmp != null)
			{
				if (stuNo == tmp.GetData()[0])
					break;
				prev = tmp;
				tmp = tmp.GetLink();
			}
			if (tmp == null)
				return false;   //代表串列為空的或者沒有找到資料   
			else if (tmp == this.first)
				this.first = this.first.GetLink();   //更新了鏈結串列的first參考
			else
				prev.SetLink(tmp.GetLink());
			return true;
		}
	}
}
