using System;
namespace _BinaryTrees
{
    public class TreeNode
    {
        private string name;
        private string phone;
        private TreeNode leftChild, rightChild;

        public TreeNode(string n, string p)
        {
            this.SetData(n, p);
            this.leftChild = null;
            this.rightChild = null;
        }
        // Setter
        public void SetData(string n, string p)
        {
            this.name = n;
            this.phone = p;
        }
        public void SetLeftChild(TreeNode lc)
        {
            this.leftChild = lc;
        }
        public void SetRightChild(TreeNode rc)
        {
            this.rightChild = rc;
        }
        // Getter
        public string[] GetData()
        {
            string[] nameAndPhone = { this.name, this.phone };
            return nameAndPhone;
        }
        public TreeNode GetLeftChild()
        {
            return this.leftChild;
        }
        public TreeNode GetRightChild()
        {
            return this.rightChild;
        }


    }
}
