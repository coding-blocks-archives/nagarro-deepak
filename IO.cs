using System;
using System.Text;

namespace nagarro_deepak{
    public class IO{ 
        public static void inputArr(int[] arr){
            var inp = Console.ReadLine().Split(' ');
            for(int i = 0; i < arr.Length; ++i){
                arr[i] = int.Parse(inp[i]);
            }
        }

        public static void outputArr(int[] arr){
            for(int i = 0; i < arr.Length; ++i){
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
} 