using System;

namespace nagarro_deepak
{
     class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // InversionCount.main2();

            // BinarySearch obj = new BinarySearch();
            // obj.main2();

            // Node head = List.createLL();
            // List.printLL(head);

            // int x = int.Parse(Console.ReadLine());
            // head = List.deleteNode(head, x);
            // List.printLL(head);

            // Node mid = List.midPoint(head);
            // Console.WriteLine(mid + " " + mid.data);

            // head = List.mergeSort(head);
            // List.printLL(head);

            // head = List.BubbleSort(head);
            // List.printLL(head);

            // List.waveSort(head);
            // List.printLL(head);

            // 02-Feb-2018
            TreeNode root = Tree.createTree();
            Tree.printLevelOrder(root);
            Console.WriteLine("\n----------------------");

            // int ans = Tree.height(root);
            // Console.WriteLine(ans);

            // Pair ans = Tree.heightBalanced(root);
            // Console.WriteLine(ans.height + " " + ans.isBal);

            // Tree.zigZagPrint(root);

            // Tree.TopView(root);     

        }
    }
}
