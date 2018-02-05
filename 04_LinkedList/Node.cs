using System;
using System.Collections.Generic;

namespace nagarro_deepak
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int x)
        {
            data = x;
            next = null;
        }

        // Node()
    }

    public class List
    {

        static Node insertAtEnd(Node head, int x, ref Node tail)
        {
            if (head == null)
            {
                head = new Node(x);
                tail = head;
                return head;
            }

            // list already contain elements
            tail.next = new Node(x);
            tail = tail.next;
            return head;

        }

        public static Node createLL()
        {
            int x;
            Node head = null;
            Node tail = null;
            while (true)
            {
                x = int.Parse(Console.ReadLine());
                if (x == -1)
                {
                    break;
                }

                head = List.insertAtEnd(head, x, ref tail);
            }
            return head;
        }

        static Node search(Node head, int x)
        {
            Node prevNode = null;
            Node cur = head;

            while (cur != null)
            {
                if (cur.data == x)
                {
                    break;
                }
                prevNode = cur;
                cur = cur.next;
            }
            return prevNode;
        }

        public static Node deleteNode(Node head, int x)
        {
            Node prevNode = search(head, x);

            if (head == null)
            {
                // empty list
                return head;
            }

            if (prevNode == null)
            {
                // delete head
                return head.next;
            }
            else if (prevNode.next == null)
            {
                // element not in the list
                return head;
            }
            else
            {
                // delete prevNode.next
                prevNode.next = prevNode.next.next;
                return head;
            }

        }

        public static void printLL(Node head)
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write(cur.data + "-->");
                cur = cur.next;
            }
            Console.WriteLine();
        }

        public static Node midPoint(Node head)
        {
            Node slow = head;
            Node fast = head;   // SET

            while (slow != null && fast != null && fast.next != null &&
                  fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        static Node mergeList(Node a, Node b)
        {
            if (a == null && b == null)
            {
                return null;
            }

            if (a == null) return b;
            if (b == null) return a;

            // we've atleast one element in each case
            if (a.data < b.data)
            {
                a.next = mergeList(a.next, b);
                return a;
            }
            else
            {
                b.next = mergeList(b.next, a);
                return b;
            }
        }

        public static Node mergeSort(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node middle = List.midPoint(head);
            Node a = head;
            Node b = middle.next;
            middle.next = null;

            a = mergeSort(a);
            b = mergeSort(b);
            Node ans = mergeList(a, b);
            return ans;
        }

        static int Length(Node head)
        {
            int cnt = 0;
            while (head != null)
            {
                ++cnt;
                head = head.next;
            }
            return cnt;
        }


        public static Node BubbleSort(Node head)
        {
            int len = List.Length(head);

            for (int i = 0; i < len; ++i)
            {
                Node cur = head;
                Node prevNode = null;

                while (cur != null && cur.next != null)
                {
                    // while I have atleast 2 nodes
                    Node ahead = cur.next;
                    if (cur.data > ahead.data)
                    {
                        //swapping
                        if (cur == head)
                        {
                            cur.next = ahead.next;
                            ahead.next = cur;
                            head = ahead;
                            prevNode = ahead;
                        }
                        else
                        {
                            prevNode.next = ahead;
                            cur.next = ahead.next;
                            ahead.next = cur;
                            prevNode = ahead;
                        }

                    }
                    else
                    {
                        prevNode = cur;
                        cur = ahead;
                    }
                }
            }
            return head;
        }

        public static void waveSort(Node head)
        {
            Stack<Node> s = new Stack<Node>();
            Node mid = List.midPoint(head);
            Node b = mid.next;
            mid.next = null;

            while (b != null)
            {
                s.Push(b);
                Node tmp = b.next;
                b.next = null;
                b = tmp;
            }

            // arrangement
            Node a = head;
            while (s.Count != 0)
            {
                Node cur = s.Peek();
                s.Pop();
                Node tmp = a.next;
                a.next = cur;
                cur.next = tmp;
                a = tmp;
            }
        }

        public static bool detectCycle(Node head)
        {
            //get, set
            var slow = head;
            var fast = head;

            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                // if (slow.next == fast.next){
                if (slow.next == fast.next)
                {
                    return true;
                }
            }
            return false;
        }
    }
}