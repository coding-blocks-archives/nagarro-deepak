using System;
using System.Collections.Generic;

namespace GRAPH
{
    class Main1
    {

        static int minMoves(int[] board, int n, int src, int dest)
        {
            // bfs
            // n = 37 for 36 boxes
            int[] dist = new int[n];
            bool[] visited = new bool[n];
            Queue<int> q = new Queue<int>();

            q.Enqueue(src);
            dist[src] = 0;
            visited[src] = true;

            while (q.Count != 0)
            {
                int cur = q.Dequeue();

                // visit all the neigbors
                for (int dice = 1; dice <= 6; ++dice)
                {
                    int destBox = dice + cur;
                    if (destBox >= n || dist[dest] != 0) break;

                    if (board[destBox] != 0)
                    {
                        // either snake or ladder
                        destBox = board[destBox];
                        if (visited[destBox] == false)
                        {
                            visited[destBox] = true;
                            dist[destBox] = 1 + dist[cur];
                            q.Enqueue(destBox);
                        }
                    }
                    else
                    {
                        if (visited[destBox] == false)
                        {
                            q.Enqueue(destBox);
                            dist[destBox] = 1 + dist[cur];
                            visited[destBox] = true;
                        }
                    }
                }
            }
            return dist[dest];
        }


        public static void main()
        {
            // int n = int.Parse(Console.ReadLine());
            // Graph g = new Graph(7);
            // g.addEdge(0, 1);
            // g.addEdge(0, 2);
            // g.addEdge(1, 2);
            // g.addEdge(1, 4);
            // g.addEdge(2, 3);
            // g.addEdge(4, 6);
            // g.addEdge(4, 5);
            // g.addEdge(5, 6);
            // g.printGraph();
            // Console.WriteLine("=============");

            // g.dfs(0);
            // g.bfs(2);
            // int ans = g.shortestDist(1, 3);
            // Console.WriteLine(ans);



            // Snake and Ladder
            // Graph g = new Graph(37);
            int[] snakeLadder = new int[37];
            snakeLadder[2] = 15;
            snakeLadder[5] = 7;
            snakeLadder[9] = 27;
            snakeLadder[17] = 4;
            snakeLadder[18] = 29;
            snakeLadder[20] = 6;
            snakeLadder[24] = 16;
            snakeLadder[25] = 35;
            snakeLadder[32] = 30;
            snakeLadder[34] = 12;


            // for (int box = 1; box <= 36; ++box)
            // {
            //     if (snakeLadder[box] != 0)
            //     {
            //         // I cannot have dice here
            //         g.addEdge(box, snakeLadder[box]);
            //         continue;
            //     }
            //     for (int dice = 1; dice <= 6; ++dice)
            //     {
            //         int src = box;
            //         int dest = box + dice;
            //         if (dest > 36) break;
            //         if (snakeLadder[dest] != 0) dest = snakeLadder[dest];
            //         g.addEdge(box, dest);
            //     }
            // }

            // int ans = g.shortestDist(1, 36);
            // int ans = minMoves(snakeLadder, 37, 8, 27);
            // Console.WriteLine(ans);
        }
    }


}