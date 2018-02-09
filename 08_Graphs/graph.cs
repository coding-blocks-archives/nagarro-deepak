using System;
using System.Collections.Generic;
using li = System.Collections.Generic.List<int>;

namespace GRAPH{
    class Graph{
        List<li> adjList;
        int nVtx;

        void setList(List<li> l, int n){
            for(int i = 0; i < n; ++i){
                l.Add(new li());
            }
        }

        public Graph(int n){
            nVtx = n;
            adjList = new List<li>(nVtx);
            setList(adjList, nVtx);
        }

        public void addEdge(int src, int dest){
            adjList[src].Add(dest);
            adjList[dest].Add(src);
        }

        public void printGraph(){
            int i = 0;
            foreach(var curList in adjList){
                Console.Write(i + ": ");
                foreach(var ngbr in curList){
                    Console.Write(ngbr + " ");
                }
                ++i;
                Console.WriteLine();
            }
        }

        void dfs(int src, bool[] visited){
            Console.Write(src + " ");
            visited[src] = true;
            
            for(int i = 0; i < adjList[src].Count; ++i){
                int ngbr = adjList[src][i];
                if (visited[ngbr] == false){
                    dfs(ngbr, visited);
                }
            } 
        }
        public void dfs(int src){
            bool[] visited = new bool[nVtx];
            dfs(src, visited);
        }

        public void bfs(int src){
            bool[] visited = new bool[nVtx];
            Queue<int> q = new Queue<int>();

            q.Enqueue(src);
            visited[src] = true;
            while(q.Count != 0){
                int cur = q.Dequeue();
                Console.Write(cur + " ");
                li curNgbrList = adjList[cur];
                for(int i = 0; i < curNgbrList.Count; ++i){
                    int ngbr = curNgbrList[i];
                    if(visited[ngbr] == false){
                        visited[ngbr] = true;
                        q.Enqueue(ngbr);
                    }
                }
            }
        }
    }
}