using System;
using System.Collections.Generic;

namespace DFA
{
    public class WorkWithConsoleClass
    {
        public string ConsoleInput()
        {
            Console.WriteLine("Please input a world for check:");

            string inputStr = Console.ReadLine();

            return inputStr;
        }

        public void ConsoleOutput(string checkedStr, List<string> fixedStates)
        {
            Console.WriteLine(checkedStr + ":");
            foreach (var elem in fixedStates)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
    }
}