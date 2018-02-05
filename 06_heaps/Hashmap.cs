using System;
using System.Collections.Generic;

namespace nagarro_hashmap
{
    public class Pair
    {
        public string name;
        public string phone_no;
        public Pair next;
        public Pair()
        {
            name = "";
            phone_no = "";
            next = null;
        }
        public Pair(string s, string p)
        {
            name = s;
            phone_no = p;
            next = null;
        }
    }


    public class Hashmap
    {
        int sze;
        int capacity;
        List<Pair> table;

        void setNull(List<Pair> l, int c){
            for(int i = 0; i < c; ++i){
                l.Add(null);
            }
        }
        public Hashmap()
        {
            sze = 0;
            capacity = 7;
            table = new List<Pair>(capacity);
            setNull(table, capacity); 
        }

        double LoadFactor()
        {
            return (double)sze / capacity;
        }

        void rehash()
        {
            // for every list
            // for every element within the list, insert into table

            List<Pair> oldTable = table;
            int oldCapacity = capacity;

            capacity = 2 * oldCapacity;
            table = new List<Pair>(capacity);
            setNull(table, capacity);

            for (int i = 0; i < oldCapacity; ++i)
            {
                Pair head = oldTable[i];
                while (head != null)
                {
                    Pair next = head.next;
                    head.next = null;

                    int idx = HashFunction(head.name);
                    Pair headNewTable = table[idx];
                    table[idx] = insertAtHead(headNewTable, head);

                    head = next;
                }
            }
        }


        int HashFunction(string name)
        {
            int ans = 0;
            int mul = 1;
            const int PRIME = 31;

            for (int i = 0; i < name.Length; ++i)
            {
                ans += ((name[i] % capacity) * mul % capacity) % capacity;
                ans %= capacity;
                mul = ((mul % capacity) * (PRIME % capacity)) % capacity;
            }
            return ans;
        }

        Pair insertAtHead(Pair head, Pair cur)
        {
            if (head == null) return cur;

            cur.next = head;
            return cur;
        }

        public void Add(string name, string number)
        {
            int idx = this.HashFunction(name);

            Pair cur = new Pair(name, number);
            // Console.WriteLine("idx" + idx);
            Pair head = table[idx];
            // insert cur at the head of list(head) 
            table[idx] = insertAtHead(head, cur);
            ++sze;

            if (LoadFactor() > 0.7)
            {
                rehash();
            }
        }
        public string GetNumber(string name)
        {
            int idx = HashFunction(name);
            Pair head = table[idx];
            // search name in a list
            while (head != null)
            {
                if (head.name == name)
                {
                    return head.phone_no;
                }
                head = head.next;
            }
            return "Not Found";

        }
        public void Remove(string name)
        {

        }

    }

    public class HashMain
    {
        public static void main2()
        {
            Hashmap map = new Hashmap();
            map.Add("abc", "123");
            Console.WriteLine(map.GetNumber("abc"));
            Console.WriteLine(map.GetNumber("def"));  
        }

    }


}