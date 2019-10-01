using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DFA
{
    public class WorkWithFileClass
    {
        private readonly string _inputFileName = Directory.GetCurrentDirectory() + "/input.txt";
        private readonly string _outputFileName = Directory.GetCurrentDirectory() + "/output.txt";
        
        public List<string> ReadDfaInformationFromFile()
        {
            List<string> strFromFile;

            using (StreamReader reader = new StreamReader(_inputFileName, true))
            {
                strFromFile = reader.ReadToEnd().Split('\n').ToList();
            }

            return strFromFile;
        }

        public void PrintDfaToFile(DfaClass dfa)
        {
            File.WriteAllText(_outputFileName, String.Empty);
            using (StreamWriter writer = new StreamWriter(_outputFileName, true))
            {
                foreach (var elem in dfa.States)
                {
                    writer.Write(elem + " ");
                }

                writer.WriteLine();
                
                foreach (var elem in dfa.Alphabet)
                {
                    writer.Write(elem + " ");
                }
                
                writer.WriteLine();
                
                foreach (var elem in dfa.TransitionFunction)
                {
                    writer.Write(elem.Key + " ");
                    foreach (var elemValue in dfa.TransitionFunction[elem.Key])
                    {
                        writer.Write(elemValue + " ");
                    }
                    writer.WriteLine();
                }
                
                foreach (var elem in dfa.StartStates)
                {
                    writer.Write(elem + " ");
                }
                
                writer.WriteLine();
                
                foreach (var elem in dfa.FinalStates)
                {
                    writer.Write(elem + " ");
                }
            }
        }
        
        
    }
}