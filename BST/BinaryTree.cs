using System;
using System.Collections.Generic;
using System.Text;



namespace BinaryTree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int val)
        {
            value = val;
            left = null;
            right = null;
        }
    }

    class BinarySearchTree
    {
        Node root = null;

        //BST insertion
        public Node InsertNode(ref Node root, int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                return root;
            }

            if (value < root.value)
            {
                if (root.left == null)
                {
                    root.left = newNode;
                    return root;
                }
                InsertNode(ref root.left, value);
            }
            else if (value > root.value)
            {
                if (root.right == null)
                {
                    root.right = newNode;
                    return root;
                }
                InsertNode(ref root.right, value);
            }

            return root;
        }



        public void LevelOrderTraversal(Node root)
        {
            //using queue
            Queue<Node> queue = new Queue<Node>();
            const Node MARKER = null;

            if (root != null)
                queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node poppedNode = queue.Dequeue();


                Console.Write(poppedNode.value + " ");

                if (poppedNode.left != null)
                {
                    queue.Enqueue(poppedNode.left);
                }
                if (poppedNode.right != null)
                {
                    queue.Enqueue(poppedNode.right);
                }
            }

        }

        //preorder
        public void DepthFirstTraversal(Node root)
        {
            Console.Write(root.value + " ");
            if (root.left != null)
                DepthFirstTraversal(root.left);
            if (root.right != null)
                DepthFirstTraversal(root.right);
        }

        //postorder
        public void PostOrder(Node root)
        {

            if (root.left != null)
                PostOrder(root.left);
            if (root.right != null)
                PostOrder(root.right);
            Console.Write(root.value);
        }

        //inorder
        public void InOrder(Node root)
        {
            if (root.left != null)
                InOrder(root.left);
            Console.Write(root.value);
            if (root.right != null)
                InOrder(root.right);
        }


        public Node GetSuccessor(Node temp)
        {
            while (temp.right != null)
            {
                temp = temp.right;
            }
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }




        public int TreeHeight(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = TreeHeight(root.left);
            int rightHeight = TreeHeight(root.right);

            int count = 1 + Math.Max(leftHeight, rightHeight);
            return count;
        }

        public void SpiralOrderTraversal()                                      //Spiral order Traversal
        {
            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            Node nodeObj = null;
            stack1.Push(root);
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                while (stack1.Count != 0)
                {
                    nodeObj = stack1.Pop();
                    Console.Write(nodeObj.value + "  ");

                    if (nodeObj.right != null)
                        stack2.Push(nodeObj.right);
                    if (nodeObj.left != null)
                        stack2.Push(nodeObj.left);
                }

                while (stack2.Count != 0)
                {
                    nodeObj = stack2.Pop();

                    Console.Write(nodeObj.value + "  ");

                    if (nodeObj.left != null)
                        stack1.Push(nodeObj.left);
                    if (nodeObj.right != null)
                        stack1.Push(nodeObj.right);
                }
            }
        }

        public bool isHeightBalance(Node root)
        {
            if (root == null)
            {
                return true;
            }
            int LeftHeight = TreeHeight(root.left);
            int RightHeight = TreeHeight(root.right);

            if (Math.Abs(LeftHeight - RightHeight) <= 1 && isHeightBalance(root.left) && isHeightBalance(root.right))
            {
                return true;
            }
            else
                return false;
        }

        public void ModifiedBST(ref Node root, ref int sum)
        {
            if (root.right != null)
                ModifiedBST(ref root.right, ref sum);

            root.value = sum + root.value;
            sum = root.value;

            if (root.left != null)
                ModifiedBST(ref root.left, ref sum);
        }




        
    }
}

