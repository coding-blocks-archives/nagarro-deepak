using System;

namespace BST
{
    class BinarySearchTree
    {

        public void InsertNode(ref TreeNode root, int data) {
            TreeNode newNode = new TreeNode(data);
            if (root == null) {
                // if tree is empty
                root = newNode;
                return;
            }
            TreeNode cur, prev;
            prev = cur = root;
            while (cur != null) {
                if (data < cur.data)
                {
                    prev = cur;
                    cur = cur.left;
                }
                else {
                    prev = cur;
                    cur = cur.right;
                }
            } // end of while loop
            // now we get the location where to add node
            if (data > prev.data)
                prev.right = newNode;
            else
                prev.left = newNode;

        }  // end of method

        public void PreOrderPrintTree(TreeNode root) {
            if (root == null)
                return;
            Console.Write($" {root.data} -->");
            PreOrderPrintTree(root.left);
            PreOrderPrintTree(root.right);
        }

    }
}
