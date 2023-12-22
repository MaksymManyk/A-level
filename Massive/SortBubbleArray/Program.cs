namespace SortBubbleArray
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
                if (A[i] <= 888)
                {
                    B[i] = A[i];
                }
                ++i;
            }


            bubbleSort(B, B.Length);


            Console.WriteLine($"{Environment.NewLine}Massive B with numbers of the original array that satisfy the condition: A[i] <= 888:");
            foreach (int item in B)
            {
                Console.Write($"{item}" + ";");
            }
            Console.WriteLine();
        }

        static void bubbleSort(int[] arr, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {

                        // Swap arr[j] and arr[j+1]
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
        }
    }


}
