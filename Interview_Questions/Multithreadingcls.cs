using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Questions
{
    internal class Multithreadingcls
    {
        static int Start = 1;
        static int End = 10;
        static bool conditions = true;
        static object _Lock = new object();
        public static void Printodd()
        {
            while (Start < End)
            {
                lock (_Lock)
                {
                    //while (!conditions)
                    //{
                    //    Monitor.Wait(_Lock);
                    //}
                    if (Start % 2 != 0)
                    {
                        Console.WriteLine($"Odd number is {Start}");
                        Start++;
                        conditions = false;
                        Monitor.Pulse(_Lock);
                    }
                }

            }
        }
        public static void Printeven()
        {
            while (Start < End)
            {
                lock (_Lock)
                {
                    //while (conditions)
                    //{
                    //    Monitor.Wait(_Lock);
                    //}
                    if (Start % 2 == 0)
                    {
                        Console.WriteLine($"Even number is {Start}");
                        Start++;
                        conditions = true;
                        Monitor.Pulse(_Lock);
                    }
                }
            }
        }
    }
}
