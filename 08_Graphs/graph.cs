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
    }
}