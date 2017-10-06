using System;
namespace _4thExamOnBoard
{
    public class ListNode
    {
        private string data;
        private ListNode link;

        public ListNode(string s)
        {
            this.data = s;
            this.link = null;
        }
        // Setter
        public void SetLink(ListNode link)
        {
            this.link = link;
        }
        // Getter
        public ListNode GetLink()
        {
            return this.link;
        }
        public string GetData()
        {
            return this.data;
        }
    }
}
