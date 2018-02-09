using System;

namespace nagarro_deepak{
    public class InversionCount{

        static void copyArr(int[] x, int[] arr, int be, int en){
            while(be <= en){
                x[be] = arr[be];
                ++be;
            }
        }

        static int mergeForInv(int[] arr, int be, int en, int mid){
            int[] x = new int[100];
            int[] y = new int[100];

            copyArr(x, arr, be, mid);
            copyArr(y, arr, mid + 1, en);

            int i = be;
            int j = mid + 1;
            int k = be;

            int ans = 0;

            while(i <= mid && j <= en){
                if (x[i] < y[j]){
                    arr[k] = x[i];
                    ++i;
                    ++k;
                } else{
                    ans += (mid - i + 1);
                    arr[k++] = y[j++];
                }
            }

            while(i <= mid){
                arr[k++] = x[i++];
            }

            while(j <= en){
                arr[k++] = y[j++];
            }
            return ans;
        }

        static int calInvCount(int[] arr, int be, int en){
            if (be >= en){
                return 0;
            }

            int mid = (be + en) / 2;
            int left = calInvCount(arr, be, mid);
            int right = calInvCount(arr, mid + 1, en);
            int cur = mergeForInv(arr, be, en, mid);
            return left + cur + right;
        }

        // static void outputArr(int[] arr){
        //     for(int i = 0; i < arr.Length; ++i){
        //         Console.Write(arr[i] + " ");
        //     }
        //     Console.WriteLine();
        // }


        public static void main2(){
            // Console.WriteLine("Hi");

            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            var inp = Console.ReadLine().Split(' ');
            
            for(int i = 0; i < n; ++i){
                arr[i] = int.Parse(inp[i]);
            }

            int ans = calInvCount(arr, 0, n - 1);
            IO.outputArr(arr);
            Console.WriteLine(ans);
        }            

    }
}