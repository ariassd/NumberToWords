﻿using System;

namespace NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // var a = 1312313.13m;
            //var r = a.ToWords(showDecimals: true);
            //Console.WriteLine(r);

            //Console.WriteLine(101m.ToWords(false));

            //Console.WriteLine(1000001m.ToWords(false));

            decimal n = 20003004000;
            Console.WriteLine($"number: {n.ToString("#,#.00#;(#,#.00#)")}");
            Console.WriteLine(n.ToWords(false));

            Console.ReadLine();

        }
    }
}





