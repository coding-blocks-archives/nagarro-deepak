using System;
using System.Text;

namespace nagarro_deepak{
    public class IO{ 
        public static void inputArr(int[] arr){
            for(int i = 0; i < arr.Length; ++i){
                arr[i] = IO.readInt();
            }
        }

        public static void outputArr(int[] arr){
            for(int i = 0; i < arr.Length; ++i){
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        
        public static int readInt(){
            // StringBuilder sb = new StringBuilder();
            int c;

            int curNum = 0;

            while((c = Console.Read()) != -1){
                if (c == ' ' || c == '\n') break;
                // Console.WriteLine("X" + c + "X");
                c = c - '0';
                Console.WriteLine(c);
                curNum *= 10;
                curNum += c;
            }
            return curNum;            
        }
    }
} 