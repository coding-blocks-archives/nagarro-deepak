using System;
namespace BST
{
    class TreeNode
    {
        public int data;
        public TreeNode left, right;
        public TreeNode() { }
        public TreeNode(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
