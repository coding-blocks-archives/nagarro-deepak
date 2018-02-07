using System;

namespace DP{
    class DynamicProgramming{

        static int fib(int[] memo, int n){
            if (n == 0 || n == 1){
                return n;
            }

            if (memo[n] != -1){
                return memo[n];
            }

            int ans = fib(memo, n-1) + fib(memo, n-2);
            memo[n] = ans;  // compute and store
            return ans;
        }


        static int maxProfitWine(int[] price, int be, int en, int year, int[,] memo){
            if (be > en){
                return 0;
            }

            if(memo[be, en] != -1) return memo[be, en];

            int soldFromBeg = year * price[be] + maxProfitWine(price, be + 1, en, year + 1, memo);
            int soldFromEnd = year* price[en] + maxProfitWine(price, be, en - 1, year + 1, memo);
            return memo[be, en] = Math.Max(soldFromBeg, soldFromEnd);
        }

        static void setArr(int[] arr, int val){
            for(int i = 0; i < arr.Length; ++i){
                arr[i] = val;
            }
        }

        static void set2DArr(int[,] arr, int val){
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            for(int i = 0; i < m; ++i){
                for(int j = 0; j < n; ++j){
                    arr[i,j] = val;
                }
            }
        }

        public static void main(){
            // int n = int.Parse(Console.ReadLine());
            // int[] memo = new int[n+1];
            // setArr(memo, -1);
            // int ans = fib(memo, n);
            // Console.WriteLine(ans);

            // wine profit
            int n = int.Parse(Console.ReadLine());
            int[] price = new int[n];
            var inp = Console.ReadLine().Split(' ');
            for(int i = 0; i < n; ++i){
                price[i] = int.Parse(inp[i]);
            }

            int[,] memo = new int[n,n];
            set2DArr(memo, -1);
 
            int ans = maxProfitWine(price, 0, n-1, 1, memo);
            Console.WriteLine(ans);
        }


    }



}