using System;
namespace _BinaryTrees
{
    public class BinaryTree
    {
        private TreeNode root;

        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(string n, string p)
        {
            this.SetRoot(n, p);
        }

        // Setter
        public void SetRoot(string n, string p)
        {
            this.root = new TreeNode(n, p);
        }
        // Getter
        public TreeNode GetRoot()
        {
            return this.root;
        }
        // insert
        public bool InsertNodeLoop(string name, string phone)
        {
            TreeNode newNode = new TreeNode(name, phone);
            if (this.root == null)
            {
                this.root = newNode;
                return true;
            }
            else
            {
                TreeNode current = this.root;
                TreeNode parent = null;
                while (current != null)
                {
                    parent = current;
                    if (string.Compare(current.GetData()[0], name) > 0)
                        current = current.GetLeftChild();
                    else if (string.Compare(current.GetData()[0], name) < 0)
                        current = current.GetRightChild();
                    else
                        return false;
                }
                if (string.Compare(parent.GetData()[0], name) > 0)
                    parent.SetLeftChild(newNode);
                else
                    parent.SetRightChild(newNode);
            }
            return true;
        }
        // Search
        // - Sequencial Search 
        public TreeNode SearchNodeRecusive(TreeNode temp, string name)
        {
            if (temp != null)
            {
                if (temp.GetData()[0] == name)
                    return temp;
                else
                {
                    temp = SearchNodeRecusive(temp.GetLeftChild(), name);
                    if (temp != null)   //在左子樹中有找到
                        return temp;
                    temp = SearchNodeRecusive(temp.GetRightChild(), name);
                    if (temp != null)   //在右子樹中有找到
                        return temp;
                }
            }
            return null;
        }
        // Delete
        public void DeleteRecusive(TreeNode ptr, TreeNode parent, string name)
        {
            if (ptr == null)
            {
				// is root?
				if (parent == null)
				{
					Console.WriteLine("is Empty list.");
					return;
				}
                return;
            }
            else
            {
                int compare = string.Compare(ptr.GetData()[0], name);
                if (compare > 0)
                    this.DeleteRecusive(ptr.GetLeftChild(), ptr, name);
                else if (compare < 0)
                    this.DeleteRecusive(ptr.GetRightChild(), ptr, name);
                else
                {
                    // is terminal
                    if (ptr.GetLeftChild() == null && ptr.GetRightChild() == null)
                    {
                        if (parent.GetLeftChild() == ptr)
                            parent.SetLeftChild(null);
                        if (parent.GetRightChild() == ptr)
                            parent.SetRightChild(null);
                        return;
                    }
                    // 節點 沒有 左子樹
                    if (ptr.GetLeftChild() == null)
                    {
                        // is root?
                        if (parent == null)
                        {
                            this.root = ptr.GetRightChild();
                            return;
                        }
                        else
                        {
                            if (parent.GetLeftChild() == ptr)
                                parent.SetLeftChild(ptr.GetRightChild());
                            if (parent.GetRightChild() == ptr)
                                parent.SetRightChild(ptr.GetRightChild());
                            return;
                        }
                    }
                    // 節點 沒有 右子樹
                    else if (ptr.GetRightChild() == null)
                    {
                        // is root?
                        if (parent == null)
                        {
                            this.root = ptr.GetLeftChild();
                            return;
                        }
                        else
                        {
                            if (parent.GetLeftChild() == ptr)
                                parent.SetLeftChild(ptr.GetLeftChild());
                            if (parent.GetRightChild() == ptr)
                                parent.SetRightChild(ptr.GetLeftChild());
                            return;
                        }
                    }
                    // 節點 有 左右子樹 
                    else
                    {
                        
                    }
				}
            }
        }
        // 二元樹的走訪（traverse）
        // - 中序走訪
        public void PrintInorder(TreeNode ptr)
        {
            if (ptr != null)
            {
                PrintInorder(ptr.GetLeftChild());
                System.Console.WriteLine("name: " + ptr.GetData()[0] + ",phone: " + ptr.GetData()[1]);
                PrintInorder(ptr.GetRightChild());
            }
        }
        // - 前序走訪
        public void PrintPreorder(TreeNode ptr)
        {
            if (ptr != null)
            {
                System.Console.WriteLine(ptr.GetData().ToString());
                PrintInorder(ptr.GetLeftChild());
                PrintInorder(ptr.GetRightChild());
            }
        }
        // - 後序走訪
        public void PrintPostorder(TreeNode ptr)
        {
            if (ptr != null)
            {
                PrintInorder(ptr.GetLeftChild());
                PrintInorder(ptr.GetRightChild());
                System.Console.WriteLine(ptr.GetData().ToString());
            }
        }
    }
}
