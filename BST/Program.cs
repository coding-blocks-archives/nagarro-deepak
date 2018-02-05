using System;

namespace BST
{
    class xyz
    {
        static void main2(string[] args)
        {
            // TreeNode root = null;
            // BinarySearchTree bst = new BinarySearchTree();
            Console.WriteLine("Enter the number of nodes you want to enter:- ");
            int nodeNums = int.Parse(Console.ReadLine());
            for (int nodeNum = 0; nodeNum < nodeNums; nodeNum++)
            {
                Console.WriteLine($"Enter data No. {nodeNum + 1}");
                int data = int.Parse(Console.ReadLine());
                // bst.InsertNode(ref root, data);
            }
            // call the print method
            Console.WriteLine("Enter");
            // bst.PreOrderPrintTree(root);
            Console.ReadKey();
        }
    }
}