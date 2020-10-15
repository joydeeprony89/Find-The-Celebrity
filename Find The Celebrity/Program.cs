using System;

namespace Find_The_Celebrity
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 4;
            int result = findCelebrity(n);
            if (result == -1)
            {
                Console.WriteLine("No Celebrity");
            }
            else
                Console.WriteLine("Celebrity ID " +
                                           result);
        }
        static int[,] MATRIX = {{ 0, 0, 0, 0 },
                                { 1, 0, 1, 1 },
                                { 1, 0, 0, 0 },
                                { 1, 0, 1, 0 }};

        // Returns true if a knows
        // b, false otherwise
        static bool knows(int a, int b)
        {
            bool res = (MATRIX[a, b] == 1) ?
                                      true :
                                      false;
            return res;
        }

        // Returns -1 if celebrity 
        // is not present. If present, 
        // returns id (value from 0 to n-1).
        static int findCelebrity(int n)
        {
            // Initialize two pointers 
            // as two corners
            int a = 0;
            int b = n - 1;

            while(a < b)
            {
                if (knows(a, b))
                    a++;
                else
                    b--;
            }
            // Keep moving while 
            // the two pointers
            // don't become same.
            for(int i = 0; i < n; i++)
            {
                if (i != a && (knows(a, i) || !knows(i, a))) return -1;
            }
            // Check if a is actually 
            // a celebrity or not
            return a;
        }
    }
}
