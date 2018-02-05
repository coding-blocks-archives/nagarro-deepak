using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_deepak
{
    class HeapSort_Amit
    {

        private static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        private static void Heapify(int[] arr, int size, int indx)
        {
            int LeftChild = 2 * indx + 1;
            int RightChild = 2 * indx + 2;
            int smallest = indx;

            if (LeftChild < size && arr[LeftChild] > arr[smallest])
            {
                smallest = LeftChild;
            }

            if (RightChild < size && arr[RightChild] > arr[smallest])
            {
                smallest = RightChild;
            }

            if (smallest != indx)
            {
                Swap(arr, smallest, indx);

                Heapify(arr, size, smallest);
            }
        }

        private static void HeapSort(int[] arr, int size)
        {
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, size, i);
            }

            for (int i = size - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                Heapify(arr, i, 0);
            }

        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] temp = Console.ReadLine().Split(' ');
            int[] arr = new int[size];

            for (int i = 0; i < temp.Length; i++)
            {
                arr[i] = int.Parse(temp[i]);
            }

            HeapSort(arr, size);

            PrintArray(arr);

        }
    }
}
