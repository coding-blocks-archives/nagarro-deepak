using System;
using System.Linq;
namespace nagarro_deepak
{
    public class BinarySearch
    {

        int lowerBound(int[] arr, int x)
        {
            int be = 0;
            int en = arr.Length - 1;
            int ans = int.MaxValue;

            while (be <= en)
            {
                int mid = (be + en) / 2;
                if (arr[mid] == x)
                {
                    ans = Math.Min(ans, mid);
                    en = mid - 1;
                }
                else if (arr[mid] > x)
                {
                    en = mid - 1;
                }
                else
                {
                    be = mid + 1;
                }
            }
            return ans;
        }


        double SquareRoot(double num)
        {
            double be = 0;
            double en = num;
            const double EPS = 1e-6;
            while (be < en)
            {
                double root = (be + en) / 2;
                if (Math.Abs(root * root - num) < EPS)
                {
                    return root;
                }
                else if (root * root < num)
                {
                    be = root;
                }
                else
                {
                    en = root;
                }
            }
            return 0.0;
        }


        int searchElement(int[] arr, int elementToSearch)
        {
            int be = 0;
            int en = arr.Length - 1;

            while (be <= en)
            {
                // int mid = (be + en) / 2;
                int mid = (en - be) / 2 + be;
                if (arr[mid] == elementToSearch)
                {
                    return mid;
                }
                else if (arr[mid] > elementToSearch)
                {
                    en = mid - 1;
                }
                else
                {
                    be = mid + 1;
                }
            }
            return -1;
        }


        bool isTaskCompleted(int[] books, int nStudents, int pagesToRead){
            int numStud = 1;
            int curPages = 0;
            
            for(int i = 0; i < books.Length; ++i){
                if (books[i] > pagesToRead) return false;   // I can't allocate this book
                // this book has more pages than I can allocate to each child

                if (curPages + books[i] <= pagesToRead){
                    curPages += books[i];
                }
                else{
                    ++numStud;
                    curPages = books[i];
                }

                if (numStud > nStudents) return false;      // no more student whom I can allocate the book
            }
            return true;
        }


        int minPages(int[] books, int nStudnet){
            int be = 1;
            int en = books.Sum();
            int bestAns = en;

            while(be <= en){
                int curGuess = (be + en) / 2;
                // if the current guess is able to complete the desired task
                if (isTaskCompleted(books, nStudnet, curGuess)){
                    bestAns = Math.Min(curGuess, bestAns);
                    en = curGuess - 1;
                } 
                else{
                    be = curGuess + 1;
                }
            }
            return bestAns;

        }

        public void main2()
        {
            // int n = int.Parse(Console.ReadLine());
            // int[] arr = new int[n];
            // IO.inputArr(arr);
            // int elementToSearch = int.Parse(Console.ReadLine());

            // int idx = searchElement(arr, elementToSearch);
            // Console.WriteLine(idx);

            // int idx = lowerBound(arr, elementToSearch);
            // Console.WriteLine(idx);

            // int n = int.Parse(Console.ReadLine());
            // var ans = SquareRoot(n);
            // Console.WriteLine(ans);

            int nStudnet = int.Parse(Console.ReadLine());
            int nBooks = int.Parse(Console.ReadLine());
            int[] arr = new int[nBooks];
            IO.inputArr(arr);

            int ans = minPages(arr, nStudnet);
            Console.WriteLine(ans);
        }
    }
}