using System;
using System.Collections.Generic;

namespace DFA2
{
    public class WorkWithConsoleClass
    {
        public string ConsoleInput()
        {
            Console.WriteLine("Please input a world for check:");

            string inputStr = Console.ReadLine();

            return inputStr;
        }

        public void ConsoleOutput(string str)
        {
            Console.WriteLine("Founded substring: " + str);
        }

    }
}