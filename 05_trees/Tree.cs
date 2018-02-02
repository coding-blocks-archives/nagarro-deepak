using System;
using System.Collections.Generic;

namespace nagarro_deepak
{

    class Tree
    {
        public static TreeNode createTree()
        {
            // dfs
            int x = int.Parse(Console.ReadLine());

            if (x == -1)
            {
                return null;
            }

            TreeNode root = new TreeNode(x);
            // Console.WriteLine("Enter left child of "  + root.data + " ");
            root.left = createTree();
            // Console.WriteLine("Enter right child of "  + root.data + " ");
            root.right = createTree();
            return root;
        }

        public static void printLevelOrder(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            const TreeNode MARKER = null;

            if (root != null) q.Enqueue(root);
            q.Enqueue(MARKER);

            // processing
            while (q.Count != 0)
            {
                TreeNode cur = q.Dequeue();
                if (cur == MARKER){
                    if (q.Count != 0){
                        Console.WriteLine();
                        q.Enqueue(MARKER);
                        continue;
                    }
                    else {
                        break;
                    }
                }
                Console.Write(cur.data + " ");
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
        }

        // height(){}
        // arrToBinary(){}
        // heightBalanced(){}
        // zigZag(){}
        // TopView(){}
        // LowestCommonAncestor(){}
        // nextRightPointers(){}
        // binaryTreeFromInorder(){}

    }
}