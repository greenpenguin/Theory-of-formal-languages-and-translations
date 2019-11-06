using System;
using System.Collections.Generic;
using System.Text;

namespace DFA2
{
    public class WorkWithConsoleClass
    {
        public string FirstTaskConsoleInput()
        {
            Console.WriteLine("Please input a world for check:");

            string inputStr = Console.ReadLine();

            return inputStr;
        }
        
        public void FirstTaskConsoleOutput(string str)
        {
            Console.WriteLine("Founded substring: " + str);
        }

    }
}