using System;
using System.Collections.Generic;

namespace Tree
{

    /// <summary>
    /// Class for node of tree
    /// </summary>
    class Node<T>
    {
        public T data;
        public Node<T> right;
        public Node<T> left;

        public Node(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    /// <summary>
    /// Binary Search Tree class
    /// </summary>
    class BinarySearchTree<T>
    {
        /// <summary>
        /// Delete's the node from binary search tree
        /// </summary>
        /// <param name="data">The value to be deleted</param>
        /// <param name="root">Root node of tree</param>
        /// <returns>New root node after insertion</returns>
        public static Node<T> DeleteNode(T data,Node<T> root)
        {
            if (root == null) return root;

            if(Comparer<T>.Default.Compare(data,root.data) < 0)
            {
                root.left =  DeleteNode(data, root.left);
            }

            else if(Comparer<T>.Default.Compare(data, root.data) > 0)
            {
                root.right =  DeleteNode(data, root.right);
            }


            // Single child , no child , or both childs
            else
            {

                if(root.left == null)
                {
                    Node<T> temp = root.right;
                    root = null;
                    return temp;
                }

                else if(root.right == null)
                {
                    Node<T> temp = root.left;
                    root = null;
                    return temp;
                }

                else
                {
                    Node<T> temp = FindMinimum(root.right);
                    root.data = temp.data;
                    root.right =  DeleteNode(temp.data, root.right);
                }
            }

            return root;
        }


        /// <summary>
        /// finds the minimum in Binary search tree
        /// </summary>
        /// <param name="root">Root node of tree</param>
        /// <returns>Node with minimum value</returns>
        public static Node<T> FindMinimum(Node<T> root)
        {
            Node<T> temp = root;

            while(temp.left!= null)
            {
                temp = temp.left;
            }
            return temp;
        }


        /// <summary>
        /// Finds the maximum in Binary seacrh tree
        /// </summary>
        /// <param name="root">Root Node tree</param>
        /// <returns>Maximum node in tree</returns>
        public static Node<T> FindMAximum(Node<T> root)
        {
            Node<T> temp = root;

            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }

        /// <summary>
        /// Inserts a new node in tree
        /// </summary>
        /// <param name="data">Value to be inserted</param>
        /// <param name="root">Root node of tree</param>
        /// <returns>New updated root node</returns>
        public static Node<T> InsertNode(T data, Node<T> root)
        {
            if (root == null)
            {
                root = new Node<T>(data);
                return root;
            }

            else if (Comparer<T>.Default.Compare(data, root.data) < 0)
                root.left = InsertNode(data, root.left);

            else
                root.right = InsertNode(data, root.right);

            return root;
        }


        /// <summary>
        /// Inorder traversal of tree
        /// </summary>
        /// <param name="root">Root node of tree</param>
        public static void InOrder(Node<T> root)
        {
            if (root != null)
            {

                InOrder(root.left);
                Console.Write("{0} ", root.data);
                InOrder(root.right);
            }
        }


        /// <summary>
        /// Preorder traversal of tree
        /// </summary>
        /// <param name="root">Root node of tree</param>
        public static void PreOrder(Node<T> root)
        {
            if (root != null)
            {

                Console.Write("{0} ", root.data);
                InOrder(root.left);
                InOrder(root.right);
            }
        }


        /// <summary>
        /// Post traversal of tree
        /// </summary>
        /// <param name="root">Root node of tree</param>
        public static void PostOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.left);
                InOrder(root.right);
                Console.Write("{0} ", root.data);
            }
        }

    }
}
