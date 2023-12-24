using System;
using System.Collections;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[20];
            int[] B = new int[20];


            for (int i = 0; i < A.Length; i++)
            {
                A[i] = new Random().Next(0, 2000);
                ++i;
            }

            Console.WriteLine($"Massive A:");
        

            foreach (int item in A)
            {
                Console.Write($"{item}" + ";");
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <=888)
                {
                    B[i]=A[i];
                }              
                ++i;
            }         
            
            IComparer revComparer = new ReverseComparer();

            Array.Sort(B, revComparer);

            Console.WriteLine($"{Environment.NewLine}Massive B with numbers of the original array that satisfy the condition: A[i] <= 888:");
            foreach (int item in B)
            {
                Console.Write($"{item}" + ";");
            }
            Console.WriteLine();
        }
    }

    public class ReverseComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
}
