using System;
namespace nagarro_deepak{
    public class Node{
        public int data;
        public Node next;

        public Node(int x){
            data = x;
            next = null;
        }

        // Node()
    }

    public class List{

        static Node insertAtEnd(Node head, int x, ref Node tail){
            if (head == null){
                head = new Node(x);
                tail = head; 
                return head;
            }

            // list already contain elements
            tail.next = new Node(x);
            tail = tail.next;
            return head;

        }

        public static Node createLL(){
            int x;
            Node head = null;
            Node tail = null;
            while(true){
                x = int.Parse(Console.ReadLine());
                if (x == -1){
                    break;
                }

                head = List.insertAtEnd(head, x, ref tail);
            }
            return head;
        }

        static Node search(Node head, int x){
            Node prevNode = null;
            Node cur = head;
           
            while(cur != null){
                if (cur.data == x){
                    break;
                }
                prevNode = cur;
                cur = cur.next;
            }
            return prevNode;
        }

        public static Node deleteNode(Node head, int x){
            Node prevNode = search(head, x);

            if (head == null){
                // empty list
                return head;
            }
            
            if (prevNode == null){
                // delete head
                return head.next;
            } else if (prevNode.next == null){
                // element not in the list
                return head;
            } else{
                // delete prevNode.next
                prevNode.next = prevNode.next.next;
                return head;
            }

        }

        public static void printLL(Node head){
            Node cur = head;
            while(cur != null){
                Console.Write(cur.data + "-->");
                cur = cur.next;
            }
            Console.WriteLine();
        }
    }
}