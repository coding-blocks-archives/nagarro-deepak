using System;
using System.Collections.Generic;

namespace nagarro_deepak
{
    public class Heap
    {
        List<int> l;
        int nElements;


        int parent(int i) { return i >> 1; }
        int left(int i) { return i << 1; }
        int right(int i) { return (i << 1) + 1; }

        void swap(int a, int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        void heapify(int idx)
        {
            int pos = idx;
            if (left(idx) <= nElements && l[idx] < l[left(idx)])
            {
                pos = left(idx);
            }

            if (right(idx) <= nElements && l[pos] < l[right(idx)])
            {
                pos = right(idx);
            }

            if (pos != idx)
            {
                int tmp = l[pos];
                l[pos] = l[idx];
                l[idx] = tmp;
                heapify(pos);
            }
        }


        public Heap()
        {
            l = new List<int>();
            nElements = 0;
            l.Add(0);
        }

        public void insert(int e)
        {
            l.Add(e);
            ++nElements;

            int i = nElements;
            while (parent(i) >= 1 && l[parent(i)] < l[i])
            {
                // swap
                int tmp = l[parent(i)];
                l[parent(i)] = l[i];
                l[i] = tmp;
                i = parent(i);
            }
        }

        public bool Empty()
        {
            return nElements == 0;
        }

        public int Remove()
        {
            if (Empty()) return -1;

            // top element can be deleted
            int rootElement = l[1];
            
            //swap l[1] && l[l.size]
            int tmp = l[1];
            l[1] = l[nElements];
            l[nElements] = tmp;
            
            l.RemoveAt(nElements);
            --nElements;

            heapify(1);
            return rootElement;
        }

        public int Peek(){
            if (Empty()) return -1;
            return l[1];
        }

    }

    public class HeapMain{
        public static void main2(){
            Heap h = new Heap();

            h.insert(1);
            h.insert(5);
            h.insert(-2);
            Console.WriteLine("Top : " + h.Peek());
            h.insert(6);
            Console.WriteLine("Top : " + h.Peek());
            h.insert(4);
            h.insert(14);
            Console.WriteLine("Top : " + h.Peek());
            h.Remove();
            Console.WriteLine("Top : " + h.Peek());
            while(!h.Empty()){
                h.Remove();
            }
            Console.WriteLine("Top : " + h.Peek());

            


        }
    }
}