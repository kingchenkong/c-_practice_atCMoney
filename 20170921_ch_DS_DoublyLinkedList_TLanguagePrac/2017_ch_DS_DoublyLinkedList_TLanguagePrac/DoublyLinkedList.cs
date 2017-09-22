using System;
namespace _ch_DS_DoublyLinkedList_TLanguagePrac
{
    public class DoublyLinkedList
    {
        private Node headNode;
        private Node rearNode;
        private Node dummyNode;

        //public static string dummy = "Dummy";

        public DoublyLinkedList()
        {
            this.dummyNode = new Node("Dummy", "Dummy", 0, 0);
            this.headNode = dummyNode;
            this.rearNode = dummyNode;
        }
        // Getter
        public Node GetNodeByKey(string key)
        {
            // empty list
            if (this.IsEmpty())
                return null;
            // search key's node
            Node temp = this.rearNode;
            while (temp != this.dummyNode)
            {
                if (temp.GetData() == key)
                    return temp;
                else
                    temp = temp.GetPrevLink();
            }
            // key is not found
            return null;
        }
        public Node GetHeadNode()
        {
            return this.headNode;
        }
        public Node GetRearNode()
        {
            return this.rearNode;
        }
        // Insert
        public void InsertAtHead(Node newNode)
        {
            if (this.headNode == this.dummyNode)
            {
                newNode.SetPrevLink(this.dummyNode); // newNode link to dummy
                this.headNode.SetNextLink(newNode); // dummy link to newNode
                this.headNode = newNode; // posHead set pos
                this.rearNode = newNode; // posRear set pos
            }
            else
            {
                // dummyNode
                this.dummyNode.SetNextLink(newNode);
                // newNode
                newNode.SetPrevLink(this.dummyNode); // newNode link to dummy
                newNode.SetNextLink(this.headNode); // newNode link to headNode
                // headNode
                this.headNode.SetPrevLink(newNode);
                this.headNode = newNode;
            }
        }
        public void InsertAtRear(Node newNode)
        {
            if (this.rearNode == this.dummyNode)
            {
                // dummyNode
                this.dummyNode.SetNextLink(newNode);
                // newNode
                newNode.SetPrevLink(this.dummyNode);
                // position
                this.headNode = newNode;
                this.rearNode = newNode;
            }
            else
            {
                // newNode
                newNode.SetPrevLink(this.rearNode);
                newNode.SetNextLink(null); // end
                // rearNode
                this.rearNode.SetNextLink(newNode);
                this.rearNode = newNode;
            }
        }
        // Delete
        public bool Delete(string key)
        {
            // search key node
            Node deleted = this.GetNodeByKey(key);
            // deleted is not found
            if (deleted == null)
                return false;
            // prev next
            Node prev = deleted.GetPrevLink();
            Node next = deleted.GetNextLink();
            // set link
            prev.SetNextLink(next);
            // key != rearNode
            if (deleted != this.rearNode)
            {
                next.SetPrevLink(prev);
            }
            else
            { // this.rearNode == deleted
                this.rearNode = this.rearNode.GetPrevLink();
            }

            // check
            if(this.rearNode == dummyNode)
            {
                this.headNode = dummyNode;
            }


            return true;
        }
        //

        // Check
        public bool IsEmpty()
        {
            if (this.headNode == this.dummyNode && this.rearNode == this.dummyNode)
            {
                return true;
            }
            return false;
        }
    }
}
