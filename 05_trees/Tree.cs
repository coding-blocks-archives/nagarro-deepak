using System;
using System.Collections.Generic;
using kvp = System.Collections.Generic.KeyValuePair<TreeNode, int>; // something fancy

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

            // TreeNode root = new TreeNode(x);
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

        static void push_left_right(Stack<TreeNode> cur, Stack<TreeNode> next){
            while(cur.Count != 0){
                var top = cur.Pop();
                Console.Write(top.data + " ");
                if (top.left != null) next.Push(top.left);
                if (top.right != null) next.Push(top.right);
            }
        }

        static void push_right_left(Stack<TreeNode> cur, Stack<TreeNode> next){
            while(cur.Count != 0){
                var top = cur.Pop();
                Console.Write(top.data + " ");
                if (top.right != null) next.Push(top.right);
                if (top.left != null) next.Push(top.left);
            }
        }


        public static void zigZagPrint(TreeNode root){
            Stack<TreeNode> curLevel = new Stack<TreeNode>();
            Stack<TreeNode> nextLevel = new Stack<TreeNode>();

            int level = 1;
            curLevel.Push(root);

            while(curLevel.Count != 0){
                if(level % 2 == 0){
                    push_right_left(curLevel, nextLevel);
                }
                else{
                    push_left_right(curLevel, nextLevel);
                }
                ++level;
                // swap stacks
                Stack<TreeNode> tmp = curLevel;
                curLevel = nextLevel;
                nextLevel = tmp;
            }
        }

        static int inf = (int)1e6;

        static void TopView(TreeNode root, bool[] visited, int offset, int hd){
            if (root == null){
                return;
            }

            TopView(root.left, visited, offset, hd - 1); // left
            if (visited[hd + offset] != true){
                visited[hd + offset] = true;
                Console.Write(root.data + " ");
            }
            TopView(root.right, visited, offset, hd + 1);
        }

        static void getSpan(TreeNode root, ref int minHd, ref int maxHd, int curHd){
            if (root == null){
                return;
            }

            minHd = Math.Min(minHd, curHd);
            maxHd = Math.Max(maxHd, curHd);

            getSpan(root.left, ref minHd, ref maxHd, curHd - 1);
            getSpan(root.right, ref minHd, ref maxHd, curHd + 1);
        }

        // static public void TopView(TreeNode root){
        //     int minHorizontalDist = inf;
        //     int maxHorizontalDist = -inf;

        //     getSpan(root, ref minHorizontalDist, ref maxHorizontalDist, 0);
        //     int n = maxHorizontalDist - minHorizontalDist + 1;
        //     bool[] visited = new bool[n];   // initially all false

        //     TopView(root, visited, Math.Abs(minHorizontalDist), 0);
        // }

        
       
        static public void TopView(TreeNode root){
            Queue<KeyValuePair<TreeNode, int> > q = new Queue<KeyValuePair<TreeNode, int> >();
            SortedDictionary<int, TreeNode> d = new SortedDictionary<int, TreeNode>();

            // kvp MARKER = new kvp(null, 0);

            q.Enqueue(new kvp(root, 0));
            q.Enqueue(new kvp(null, 0));

            while(q.Count != 0){
                kvp curPair = q.Dequeue();
                
                TreeNode cur = curPair.Key;
                int curDist = curPair.Value;

                if (d.ContainsKey(curDist) == false){
                    d.Add(curDist, cur);
                }

                if (cur == null){
                    if (q.Count != 0){
                        // end of the cur level
                        q.Enqueue(new kvp(null, 0)); 
                    }
                    continue;
                }

                if (cur.left != null){
                    q.Enqueue(new kvp(cur.left, curDist - 1));
                }
                if (cur.right != null){
                    q.Enqueue(new kvp(cur.right, curDist + 1));
                }
            }


            // print the dictionary
            foreach(var e in d){
                Console.Write(e.Value.data + " ");
            }
        }




        static int search(int[] arr, int be, int en, int data){
            while(be <= en){
                if (arr[be]== data) return be;
                ++be;
            }
            return -1;  // I am using input is always correct
        }
        public static TreeNode arrToBinary(int[] inOrder, int[] post, 
                                            int be, int en, ref int postIdx){

            if (be > en){
                return null;
            }

            TreeNode root = new TreeNode(post[postIdx]);
            postIdx--;
            int pos = search(inOrder, be, en, root.data);

            root.right = arrToBinary(inOrder, post, pos + 1, en, ref postIdx);
            root.left = arrToBinary(inOrder, post, be, pos-1, ref postIdx);
            return root;
        }
        // nextRightPointers(){}
        // LowestCommonAncestor(){}

    }
}