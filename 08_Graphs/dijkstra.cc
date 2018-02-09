#include <iostream>
#include <queue>
using namespace std;

struct Pair
{
    int wt;
    int id;
    Pair() {}
    Pair(int i, int w)
    {
        wt = w;
        id = i;
    }

    // a fancy comparator
    bool operator()(const Pair &a, const Pair &b)
    {
        return a.wt > b.wt;
    }
};

class Graph
{
    vector<vector<Pair> > adjList;
    int nVtx;

  public:
    Graph(int n)
    {
        nVtx = n;
        adjList.resize(n, vector<Pair>());
    }

    void addEdge(int src, int dest, int wt)
    {
        adjList[src].push_back(Pair(dest, wt));
        adjList[dest].push_back(Pair(src, wt));
    }

    void print(){
        for(int i = 0; i < adjList.size(); ++i){
            cout << i <<  " ";
            for(int j = 0; j < adjList[i].size(); ++j){
                cout << adjList[i][j].id << "(" << adjList[i][j].wt << ") ";
            }
            cout << endl;
        }
    }

    void dijkstra(int src, int dest)
    {
        priority_queue<Pair, vector<Pair>, Pair> q; // minHeap
        vector<bool> visited(nVtx, false);
        int *dist = new int[nVtx];
        
        const int inf = 1e6;
        for(int i = 0; i < nVtx; ++i){
            dist[i] = inf;
        }

        Pair root(src, 0);
        q.push(root);
        visited[src] = true;

        while (!q.empty())
        {
            Pair cur = q.top();
            q.pop();

            // set the distance of unvisited vtx
            if (dist[cur.id] < cur.wt) continue;    // already visited
            dist[cur.id] = cur.wt;

            const auto &ngbrList = adjList[cur.id];
            for (int i = 0; i < ngbrList.size(); ++i)
            {
                Pair curNgbr = ngbrList[i];
                // if this is marked visited, then this applies that shorter edges will never be pushed
                // in case of 
                // 0-->1(10), 0-->2(80), 2 is marked visited; but in actual it is still alive; is hasnt
                // burnt
                // line 72 confirms that the element is visited
                // if (visited[curNgbr.id]){
                //     continue;
                // }
                curNgbr.wt += cur.wt;
                visited[curNgbr.id] = true;
                cout << curNgbr.id << " " << curNgbr.wt << endl;
                q.push(curNgbr);
            }
        }

        for (int i = 0; i < nVtx; ++i)
        {
            cout << dist[i] << " ";
        }
    }

};

int
main()
{
    Graph g(7);
    g.addEdge(0, 1, 10);
    g.addEdge(0, 2, 80);
    g.addEdge(1, 4, 20);
    g.addEdge(2, 3, 70);
    g.addEdge(1, 2, 6);
    g.addEdge(4, 5, 50);
    g.addEdge(4, 6, 10);
    g.addEdge(5, 6, 5);
    g.print();
    g.dijkstra(0, 6);
}