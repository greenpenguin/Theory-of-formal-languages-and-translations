using System;
using System.Linq;

namespace DFA2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            DfaClass dfaClass = new DfaClass(workWithFileClass.ReadDfaInformationFromFile());
            
            workWithFileClass.PrintDfaToFile(dfaClass);
                
            string str = workWithConsoleClass.ConsoleInput();

            int k = 0;
            while (k < str.Length)
            {
                var MaxRes = dfaClass.MaxString(str, k);
                if (MaxRes.Key == true)
                {
                    workWithConsoleClass.ConsoleOutput(str.Substring(k, MaxRes.Value));
                    k += MaxRes.Value;
                }
                else
                {
                    k++;
                }
            }
        }
    }
}