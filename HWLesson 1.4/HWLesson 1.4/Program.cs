
namespace HWLesson14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter count of elements!");
            var countElements = Console.ReadLine();
            if (int.TryParse(countElements, out int count) && count > 0)
            {
                int[] massiveElem = new int[count];

                InputRandomElem(massiveElem);

                string[] evenNumber = new string[CountEven(massiveElem)];
                string[] oddNumber = new string[massiveElem.Length - CountEven(massiveElem)];
                int evenIndex = 0;
                int oddIndex = 0;

                foreach (var i in massiveElem)
                {
                    if (i % 2 == 0)
                    {
                        evenNumber[evenIndex] = IntToEngAlphabet(i);
                        evenIndex++;
                    }
                    else
                    {
                        oddNumber[oddIndex] = IntToEngAlphabet(i);
                        oddIndex++;
                    }
                }

                if (UpperCharCount(evenNumber) > UpperCharCount(oddNumber))
                {
                    Console.WriteLine($"Array 'evenNumber' has more uppercase letters ({UpperCharCount(evenNumber)}) then array 'oddNumber' ({UpperCharCount(oddNumber)})");
                }
                else if (UpperCharCount(evenNumber) < UpperCharCount(oddNumber))
                {
                    Console.WriteLine($"Array 'oddNumber' has more uppercase letters ({UpperCharCount(oddNumber)}) then array 'evenNumber' ({UpperCharCount(evenNumber)})");
                }
                else
                {
                    Console.WriteLine("Array 'oddNumber' and array 'evenNumber'  have an equal number uppercase letters");
                }

                Console.WriteLine($"{Environment.NewLine}Array 'evenNumber':");
                PrintArray(evenNumber);

                Console.WriteLine($"{Environment.NewLine}Array 'oddNumber':");
                PrintArray(oddNumber);
             }
            else
            {
                Console.WriteLine("You input not integer number or number less than 1");
            }
        }

        public static void InputRandomElem(int[] massive)
        {
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = new Random().Next(1, 26);
            }
        }

        public static int CountEven(int[] massive)
        {
            int count = 0;
            foreach (var i in massive)
            {
                if (i % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }

        public static string IntToEngAlphabet(int numb)
        {
            string upperList = "aeidhj";
            int asciiCode = 'a' + numb - 1;
            char myChar = (char)asciiCode;
            string myString = upperList.Contains(myChar.ToString()) ? myChar.ToString().ToUpper() : myChar.ToString().ToLower();
            return myString;
        }

        public static void PrintArray(string[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static int UpperCharCount(string[] array)
        {
            int count = 0;
            foreach (string i in array)
            {
               count = char.IsUpper((char)i[0]) ? count + 1 : count + 0;
            }

            return count;
        }
    }
}
