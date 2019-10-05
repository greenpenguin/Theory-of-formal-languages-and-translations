using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DFA2
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
                foreach (var stateForOutput in dfa.States)
                {
                    writer.WriteLine("State:");
                    writer.WriteLine(stateForOutput.NameOfState);
                    writer.WriteLine("Available States:");
                    foreach (var state in stateForOutput.AvailableStates)
                    {
                        writer.Write(state + " ");
                    }
                    writer.WriteLine();
                    writer.WriteLine("State Transition Signals:");
                    int i = 0;
                    foreach (var signalList in stateForOutput.StateTransitionSignals)
                    {
                        writer.Write(stateForOutput.NameOfState + " --> " + stateForOutput.AvailableStates[i] + " by signals: ");
                        foreach (var signal in signalList)
                        {
                            writer.Write(signal + " ");
                        }
                        writer.WriteLine();
                        i++;
                    }
                    writer.WriteLine();
                }
                writer.WriteLine("Start States:");
                foreach (var elem in dfa.StartStates)
                {
                    writer.Write(elem + " ");
                }
                writer.WriteLine();
                writer.WriteLine("Final States:");
                
                foreach (var elem in dfa.FinalStates)
                {
                    writer.Write(elem + " ");
                }
                
            }
        }
    }
}