
using System;
using System.Data;

    internal class Program
    {
        static void Main(string[] args)
        {

            int t;
            int q=0;
            Console.WriteLine("Enter the number of elements in the array!");
            var input = Console.ReadLine();

              //Console.WriteLine($"Input: {input}");

              bool success = int.TryParse(input, out t);         
            

            if (success)
            {
                int[] massive = new int[t];
                for (int i = 0; i < massive.Length; i++)
                {
                    massive[i] = new Random().Next(-200, 200);
                    ++i;                   
                }

                Console.WriteLine($"The massive have {t} elements:");

                foreach (int item in massive)
                             
                {
                    Console.Write($"{item}"+";");
                    if (-100<item && item<100)  {
                        q++;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}But number of elements whose values are in the range -100 to +100 is {q}");


            }
            else { Console.WriteLine("You are not entering a number!!!"); }
            
            

           
        
        }
    }

