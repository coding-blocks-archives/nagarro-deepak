using System;

namespace DP
{
    class DynamicProgramming
    {

        static int fib(int[] memo, int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            if (memo[n] != -1)
            {
                return memo[n];
            }

            int ans = fib(memo, n - 1) + fib(memo, n - 2);
            memo[n] = ans;  // compute and store
            return ans;
        }


        static int maxProfitWine(int[] price, int be, int en, int year, int[,] memo)
        {
            if (be > en)
            {
                return 0;
            }

            if (memo[be, en] != -1) return memo[be, en];

            int soldFromBeg = year * price[be] + maxProfitWine(price, be + 1, en, year + 1, memo);
            int soldFromEnd = year * price[en] + maxProfitWine(price, be, en - 1, year + 1, memo);
            return memo[be, en] = Math.Max(soldFromBeg, soldFromEnd);
        }

        static void setArr(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = val;
            }
        }


        static int maxProfitWine2(int[] price, int be, int en)
        {
            int[,] dp = new int[en + 1, en + 1];
            set2DArr(dp, -1);

            // set base cases
            int yr = en - be + 1;
            for (int i = 0; i <= en; ++i)
            {
                dp[i, i] = yr * price[i];
            }

            for (int start = en - 1; start >= 0; --start)
            {
                for (int end = start + 1; end <= en; ++end)
                {
                    // current year
                    int currentYear = yr - (end - start);
                    dp[start, end] = Math.Max(
                        price[start] * currentYear + dp[start + 1, end],
                        price[end] * currentYear + dp[start, end - 1]
                     );
                }
            }
            return dp[0, en];
        }


        static void set2DArr(int[,] arr, int val)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    arr[i, j] = val;
                }
            }
        }

        static int cutRod(int[] price, int len)
        {
            if (len == 0)
            {
                return 0;
            }
            int bestProfit = -1;
            for (int cutAt = 0; cutAt < len; ++cutAt)
            {
                int curProfit = price[cutAt];
                int remProfit = cutRod(price, len - cutAt - 1);
                int netProfit = curProfit + remProfit;
                bestProfit = Math.Max(netProfit, bestProfit);
            }
            return bestProfit;
        }


        static int cutRod2(int[] price, int len)
        {

            int[] dp = new int[len + 1];
            
            for(int lenOfRodUnderConsideration = 1; lenOfRodUnderConsideration <= len; ++ lenOfRodUnderConsideration){
                for(int cut = lenOfRodUnderConsideration - 1; cut >= 0; --cut){
                    dp[lenOfRodUnderConsideration] = Math.Max(
                        dp[lenOfRodUnderConsideration],
                        price[cut] + dp[lenOfRodUnderConsideration - cut - 1]
                    );
                }
            }
            return dp[len];
        }


        static int editDistance(string from, int be, string to, int i){
            if (be == from.Length && i == to.Length){
                return 0;
            }
            
            if (be == from.Length){
                // only insertion can be done
                return to.Length - from.Length;
            }

            if(i == to.Length){
                // delete the chars from from
                return from.Length - to.Length;
            }

            if (from[be] == to[i]){
                return editDistance(from, be + 1, to, i + 1);
            }

            int replace = 1 + editDistance(from, be + 1, to, i + 1);
            int delete = 1 + editDistance(from, be + 1, to, i);
            int insert = 1 + editDistance(from, be, to, i + 1);
            return Math.Min(replace, Math.Min(delete, insert));
        }


        public static void main()
        {
            // int n = int.Parse(Console.ReadLine());
            // int[] memo = new int[n+1];
            // setArr(memo, -1);
            // int ans = fib(memo, n);
            // Console.WriteLine(ans);

            // wine profit
            // int n = int.Parse(Console.ReadLine());
            // int[] price = new int[n];
            // var inp = Console.ReadLine().Split(' ');
            // for (int i = 0; i < n; ++i)
            // {
            //     price[i] = int.Parse(inp[i]);
            // }

            // int[,] memo = new int[n,n];
            // set2DArr(memo, -1);

            // int ans = maxProfitWine(price, 0, n-1, 1, memo);
            // int ans = maxProfitWine2(price, 0, n - 1);
            // Console.WriteLine(ans);

            // int ans = cutRod2(price, n);
            // Console.WriteLine(ans);

            string from = Console.ReadLine();
            string to = Console.ReadLine();
            int ans = editDistance(from, 0, to, 0);
            Console.WriteLine(ans);
        }


    }



}