using System;

namespace GRAPH
{
    class Main1
    {
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
            Graph g = new Graph(37);
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


            for (int box = 1; box <= 36; ++box)
            {
                if (snakeLadder[box] != 0){
                    // I cannot have dice here
                    g.addEdge(box, snakeLadder[box]);
                    continue;
                }
                for (int dice = 1; dice <= 6; ++dice)
                {
                    int src = box;
                    int dest = box + dice;
                    if (dest > 36) break;
                    if (snakeLadder[dest] != 0) dest = snakeLadder[dest];
                    g.addEdge(box, dest);
                }
            }

            int ans = g.shortestDist(1, 36);
            Console.WriteLine(ans);
        }
    }


}