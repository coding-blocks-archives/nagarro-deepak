using System;

namespace BST
{
    class BinarySearchTree
    {

        // public void InsertNode(ref TreeNode root, int data) {
        //     TreeNode newNode = new TreeNode(data);
        //     if (root == null) {
        //         // if tree is empty
        //         root = newNode;
        //         return;
        //     }
        // TreeNode cur, prev;
        // prev = cur = root;
        // while (cur != null) {
        //     if (data < cur.data)
        //     {
        //         prev = cur;
        //         cur = cur.left;
        //     }
        //     else {
        //         prev = cur;
        //         cur = cur.right;
        //     }
        // } // end of while loop
        // // now we get the location where to add node
        // if (data > prev.data)
        //     prev.right = newNode;
        // else
        //     prev.left = newNode;

        // }  // end of method

        public static TreeNode insertIntoBst(TreeNode root, int x)
        {
            if (root == null)
            {
                root = new TreeNode(x);
                return root;
            }
            if (x < root.data)
            {
                root.left = insertIntoBst(root.left, x);
                return root;
            }
            else
            {
                root.right = insertIntoBst(root.right, x);
                return root;
            }
        }

        public static TreeNode createBST()
        {
            int x = int.Parse(Console.ReadLine());
            if (x == -1) return null;
            TreeNode root = null;

            while (x != -1)
            {
                root = insertIntoBst(root, x);
                x = int.Parse(Console.ReadLine());
            }
            return root;
        }

        static public void PreOrderPrintTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            PreOrderPrintTree(root.left);
            Console.Write($" {root.data} -->");
            PreOrderPrintTree(root.right);
        }

    }
}
