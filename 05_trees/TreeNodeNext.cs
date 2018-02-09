using System;
using System.Collections.Generic;

namespace nagarro_deepak
{
    public class TreeNodeNext
    {
        public TreeNodeNext left;
        public TreeNodeNext right;
        public TreeNodeNext next;
        public int data;
        public TreeNodeNext(int x) 
        {   
            data = x;
            this.left = null;
            this.right = null;
            this.next = null;
        }

        static void joinLevel(TreeNodeNext root){

            TreeNodeNext cur = root;
            while(cur != null){
                TreeNodeNext tmp = new TreeNodeNext(0);
                TreeNodeNext child = tmp;
                
                // curLevel
                while(cur != null){
                    if(cur.left != null){
                        child.next = cur.left;
                        child = child.next;
                    }
                    if (cur.right != null){
                        child.next = cur.right;
                        child = child.next;
                    }
                    cur = cur.next;
                }
                cur = tmp.next;
            }
            
        }

        public static TreeNodeNext createTree()
        {
            // dfs
            int x = int.Parse(Console.ReadLine());

            if (x == -1)
            {
                return null;
            }

            // TreeNode root = new TreeNode(x);
            TreeNodeNext root = new TreeNodeNext(x);
            // Console.WriteLine("Enter left child of "  + root.data + " ");
            root.left = createTree();
            // Console.WriteLine("Enter right child of "  + root.data + " ");
            root.right = createTree();
            return root;
        }
        public static void printLevelOrder(TreeNodeNext root){
            Queue<TreeNodeNext> q = new Queue<TreeNodeNext>();
            const TreeNodeNext MARKER = null;

            if (root != null) q.Enqueue(root);
            q.Enqueue(MARKER);

            // processing
            while (q.Count != 0)
            {
                TreeNodeNext cur = q.Dequeue();
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
                Console.Write(cur.data + "");
                if (cur.next != null) {
                    Console.Write("(" + cur.next.data + ") ");
                }
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
        } 

        static public void main2()
        {
            TreeNodeNext root = TreeNodeNext.createTree();
            TreeNodeNext.joinLevel(root);
            TreeNodeNext.printLevelOrder(root);

        }
    }
}