namespace DFA
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            DfaClass dfa = new DfaClass(workWithFileClass.ReadDfaInformationFromFile());
            
            workWithFileClass.PrintDfaToFile(dfa);

            string inputStr = workWithConsoleClass.ConsoleInput();
            dfa.OutputMax(inputStr);
        }
    }
}