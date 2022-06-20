using System;
using System.Collections.Generic;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while (true)
            {
                if (x % 2 == 0)
                {
                    System.Console.WriteLine(x);
                }

                if (x == 100)
                {
                    return;
                }

                x++;
            }
        }
    }
}
