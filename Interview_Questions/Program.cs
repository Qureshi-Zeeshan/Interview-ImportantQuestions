using Interview_Questions;
using System;
using System.Text;
namespace InterveiwQuestions
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 1. Write a program to reverse a string in c#.
            Console.WriteLine(ReverseString("Zeeshan Qureshi"));

            Console.WriteLine();

            // 2. Write a program to reverse a Number in c#.
            Console.WriteLine(ReverseNumber(797744083));

            Console.WriteLine();

            // 3. Write a program to check the string is Palindrome or not.
            Console.WriteLine(PalindromeChecker("madam"));

            Console.WriteLine();

            // 4. Write a program for Fibonacci Series.
            Console.WriteLine(FibonacciSeries(3));
            PrintFibonacciSeries(10);

            // 5. How to perform a right circular rotation of an array ?
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            PrintCollection(arr);
            RightCircularRotation(arr, 2);
            PrintCollection(arr);

            Console.WriteLine();

            // 6. How to perform a Left circular rotation of an array ?
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            PrintCollection(ar);
            LeftCircularRotation(ar, 2);
            PrintCollection(ar);

            //7. How to count the accurance of each characters in a string?
            string name = "Deeeeeeeepaaaaaaaaaaa";
            Console.WriteLine(AccuranceOfCharacters(name));
            AccuranceOfCharactersOptimized(name);
            Console.WriteLine();

            //8. How to remove duplicate characters from string ?
            Console.WriteLine(RemoveDuplicatInString("Deeeeeeeepaaaaaaaaaaa"));

            //9. How to find the third largest element in array using only one loop?
            int[] third = { 33,33,33,33,33,33,33};
            PrintCollection(third);
            Console.WriteLine(ThirdLargestElementInArray(third));

            //10. How to Swap two Numbers
            int one = 1,two = 2;
            SwapTwoNumbers(ref one, ref two);
            Console.WriteLine($"The value of one is {one} and two is {two}");

            Console.WriteLine();

            // 11. Finding two numbers in an array that  add up to a target
            int[] TwoSum = { 55, 32, 47, 98, 43,4,1 };
            _2SumProblem(TwoSum,99);

            Console.WriteLine();

            //12. Move all the Zeros to the end of an array.
            Console.WriteLine("Move Zeroes to the End");
            int[] Zeroes = { 0, 2, 0, 0, 6, 7 };
            MoveZerosAtEnd(Zeroes);
            PrintCollection(Zeroes);

            //13. Printing odd and Even with 2 threads
            Thread oddThread =new Thread(Multithreadingcls.Printodd);
            Thread EvenThread =new Thread(Multithreadingcls.Printeven);

            oddThread.Start();
            EvenThread.Start();

            oddThread.Join();
            EvenThread.Join();


        }
        public static void PrintCollection(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static string ReverseString(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                stringBuilder.Append(str[i]);
            }

            return stringBuilder.ToString();
            //char[] chars =str.ToCharArray();
            //Array.Reverse(chars);
            //string result = new string(chars);
            //return result;
        }

        public static int ReverseNumber(int num)
        {
            int result = 0;
            while (num > 0)
            {
                int lastdigit = num % 10;
                result = result * 10 + lastdigit;
                num = num / 10;
            }
            return result;
        }

        public static bool PalindromeChecker(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            int i = 0;
            int j = str.Length - 1;
            while (i < j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        public static int FibonacciSeries(int num)
        {
            //if(num == 0) return 0;
            //if(num == 1) return 1;
            if (num == 0 || num == 1) return num;
            return FibonacciSeries(num - 1) + FibonacciSeries(num - 2);
        }

        public static void PrintFibonacciSeries(int num)
        {
            int First = 0;
            int Second = 1;
            if (num < 0)
            {
                Console.WriteLine("Invalid ");
                return;
            }
            if (num == 0)
            {
                Console.Write($"Fibonacci series are : {First}");
                return;
            }
            if (num == 1)
            {
                Console.Write($"Fibonacci series are : {First} {Second}");
                return;
            }
            Console.Write($"Fibonacci series are : {First} {Second}");
            if (num > 1)
            {
                for (int i = 2; i < num; i++)
                {
                    int finalresult = First + Second;
                    Console.Write(" " + finalresult);
                    First = Second;
                    Second = finalresult;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void RightCircularRotation(int[] arr, int Times)
        {
            if (arr == null || Times == 0)
            {
                Console.WriteLine("Please correct the parameters");
                return;
            }
            Times = Times % arr.Length;
            for (int i = 1; i <= Times; i++)
            {
                int temp = arr[arr.Length - 1];
                for (int j = arr.Length - 1; j >= 1; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[0] = temp;
            }
        }

        public static void LeftCircularRotation(int[] arr, int Times)
        {
            if (arr == null || Times == 0)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            for (int i = 1; i <= Times; i++)
            {
                int temp = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = temp;
            }
        }

        public static string AccuranceOfCharacters(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "Empty or null string";
            StringBuilder sb = new StringBuilder();
            StringBuilder Copy = new StringBuilder(str.ToLower());
            for (int i = 0; i <= Copy.Length - 1; i++)
            {
                int count = 1;
                int j = i + 1;
                while (j < Copy.Length)
                {
                    if (char.ToLower(Copy[i]) == char.ToLower(Copy[j]))
                    {
                        count++;
                        Copy.Remove(j, 1);
                        j--;
                    }

                    j++;

                }
                sb.Append(Copy[i]);
                sb.Append(count);
            }
            return sb.ToString();
        }

        public static void AccuranceOfCharactersOptimized(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return;
            Dictionary<char,int>EachCounts = new Dictionary<char,int>();
            foreach(char c in str)
            {
                if (!EachCounts.ContainsKey(c))
                {
                    EachCounts.Add(c, 1);
                }
                else
                {
                    EachCounts[c]++;
                }
            }

            foreach(var c in EachCounts)
            {
                Console.WriteLine($"{c.Key} : {c.Value}");
            }
        }

        public static string RemoveDuplicatInString(string str)
        {
            StringBuilder Copy = new StringBuilder(str);
            for (int i = 0; i < Copy.Length - 1; i++)
            {
                int j = i + 1;
                while (j < Copy.Length)
                {
                    if (char.ToLower(Copy[i]) == char.ToLower(Copy[j]))
                    {
                        Copy.Remove(j, 1);
                        j--;
                    }
                    j++;
                }
            }
            return Copy.ToString();
        }

        public static string RemoveDuplicate(string str)
        {
            HashSet<char> set = new HashSet<char>();
            StringBuilder result = new StringBuilder();
            foreach(char c in str)
            {
                char charlower=char.ToLower(c);
                if (!set.Contains(charlower))
                {
                    set.Add(charlower);
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        public static int ThirdLargestElementInArray(int[] array)
        {
            if (array.Length < 3) return -1;
            int First = int.MinValue, Second = int.MinValue, Third = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] > First)
                {
                    Third= Second;
                    Second = First;
                    First= array[i];
                }
                else if(array[i] < First && array[i] > Second)
                {
                    Third = Second;
                    Second= array[i];
                }
                else if (array[i] < Second && array[i] > Third)
                {
                     Third = array[i];
                }

            }
            if(Third == int.MinValue)
            {
                return -1;
            }
            return Third;
        }

        public static void SwapTwoNumbers(ref int a,ref int b)
        {
             a = a + b;
            b = a - b;
            a = a - b;

            // Using Tuple
            //(a, b) = (b, a);
        }
       public static void _2SumProblem(int [] array,int Target)
        {
            Dictionary<int,int> Lefts = new Dictionary<int,int>();
            for(int i = 0;i < array.Length;i++)
            {
                int temp= Target - array[i];
                if (Lefts.ContainsKey(temp))
                {
                    Console.WriteLine($"The element at index {Lefts[temp]} and {i} make {Target}");
                    return;
                }
                 else if (!Lefts.ContainsKey(array[i]))
                {
                    Lefts[array[i]] = i;
                }
            }
            Console.WriteLine("No sum of Element can reach the Target");
        }

        public static void MoveZerosAtEnd(int [] array)
        {
            int InsertPosition = 0;
            for(int i=0;i<array.Length;i++)
            {
                if (array[i] != 0)
                {
                    array[InsertPosition] = array[i];
                    InsertPosition++;
                }
            }
            while(InsertPosition < array.Length)
            {
                array[InsertPosition] = 0;
                InsertPosition++;
            }
        }
        public static int BinaryToDecimal(int num)
        {
            int result = 0;
            int lastnum = 0;
            int i = 0;
           while(num >0)
            {
                lastnum = num % 10;
                result = result + lastnum * (int)Math.Pow(2, i);
                num = num / 10;
                i++;
            }
           return result;
        }
    }
}