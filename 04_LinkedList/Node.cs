using System;
namespace nagarro_deepak{
    public class Node{
        public int data;
        public Node next;
    }

    public class List{

        Node insertAtEnd(Node head, int x, ref Node tail){
            if (head == null){
                head = new Node(x);
                return head;
            }

            // list already contain elements

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

                head = insertAtEnd(head, x, ref tail);
            }
            return head;
        }


        public static bool deleteNode(){

        }

        public static void printLL(){

        }
    }
}L