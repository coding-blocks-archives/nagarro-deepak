using System;
namespace nagarro_deepak{
    public class BinarySearch{

        int lowerBound(int[] arr, int x){
            int be = 0;
            int en = arr.Length - 1;
            int ans = int.MaxValue;

            while(be <= en){
                int mid = (en - be) / 2 + be;
                if (arr[mid] == x){
                    ans = Math.Min(ans, mid);
                } else if(arr[mid] < x){
                    // search in the right
                    be = mid + 1;
                } else {
                    en = mid - 1;
                }
            }
            return ans;
        }

        public void main2(){
            int n = IO.readInt();
            Console.WriteLine(n);
            int[] arr = new int[n];
            IO.inputArr(arr);
            IO.outputArr(arr);
            int elementToSearch = IO.readInt();
            int idx = lowerBound(arr, elementToSearch);
            Console.WriteLine(idx);
        }
    }
}