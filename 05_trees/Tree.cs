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
                if (cur == MARKER)
                {
                    if (q.Count != 0)
                    {
                        Console.WriteLine();
                        q.Enqueue(MARKER);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write(cur.data + " ");
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
        }

        static public int height(TreeNode root)
        {
            if (root == null) return 0;

            int leftHeight = height(root.left);
            int rightHeight = height(root.right);

            int ans = Math.Max(leftHeight, rightHeight) + 1;
            return ans;

        }
        static public Pair heightBalanced(TreeNode root)
        {
            if (root == null)
            {
                Pair p = new Pair();
                p.isBal = true;
                p.height = 0;
                return p;
            }

            Pair lt = heightBalanced(root.left);
            Pair rt = heightBalanced(root.right);
            bool isRootBal = Math.Abs(lt.height - rt.height) <= 1;
            
            int curHt = Math.Max(lt.height, rt.height) + 1;
            bool isCurBal = isRootBal && lt.isBal && rt.isBal;

            Pair ans = new Pair();
            ans.height = curHt;
            ans.isBal = isCurBal;

            return ans;          

        }


        // arrToBinary(){}
        // zigZag(){}
        // TopView(){}
        // nextRightPointers(){}

        // LowestCommonAncestor(){}
        // binaryTreeFromInorder(){}

    }
}