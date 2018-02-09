using System;

namespace GRAPH
{
    class Main1
    {
        public static void main()
        {
            // int n = int.Parse(Console.ReadLine());
            Graph g = new Graph(7);
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(1, 4);
            g.addEdge(2, 3);
            g.addEdge(4, 6);
            g.addEdge(4, 5);
            g.addEdge(5, 6);
            g.printGraph();
            Console.WriteLine("=============");

            // g.dfs(0);
            g.bfs(2);

        }
    }
}