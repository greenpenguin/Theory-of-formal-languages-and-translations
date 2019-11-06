using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DFA2
{
    public class WorkWithFileClass
    {
        private readonly string _outputFileName = Directory.GetCurrentDirectory() + "/output.txt";
        
        public List<string> ReadDfaInformationFromFile(string inputFileName)
        {
            List<string> strFromFile;

            using (StreamReader reader = new StreamReader(inputFileName, true))
            {
                strFromFile = reader.ReadToEnd().Split('\n').ToList();
            }

            return strFromFile;
        }

        public string ReadFileForSecondTask(string inputFileName)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFileName, true))
            {
                var strFromFile = reader.ReadToEnd();
                byte[] bytes = Encoding.UTF8.GetBytes(strFromFile);

                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] == 10) //перевод строки
                    {
                        result.Append(@"\n");
                    }
                    else if (bytes[i] == 9) //табуляция
                    {
                        result.Append(@"\t");
                    }
                    else if (bytes[i] == 13) //возврат каретки
                    {
                        result.Append(@"\r");
                    }
                    else if (bytes[i] == 32) //пробел
                    {
                        result.Append(@"\s");
                    }
                    else
                    {
                        result.Append(strFromFile[i]);
                    }
                }
            }

            return result.ToString();
        }

        public void MakeFileEmpty(string outputFileName)
        {
            File.WriteAllText(outputFileName, String.Empty);
        }

        public void SecondTaskFileOutput(string dfaName, string word, string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine("<" + dfaName + "," + word + ">");
            }
        }
        
        public void PrintDfaToFile(DfaClass dfa)
        {
            File.WriteAllText(_outputFileName, String.Empty);
            using (StreamWriter writer = new StreamWriter(_outputFileName, true))
            {
                foreach (var stateForOutput in dfa.States)
                {
                    writer.WriteLine("Priority:");
                    writer.WriteLine(dfa.Priority);
                    writer.WriteLine("State:");
                    writer.WriteLine(stateForOutput.NameOfState);
                    if (stateForOutput.AvailableStates.Count > 0)
                    {
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
                            writer.Write(stateForOutput.NameOfState + " --> " + stateForOutput.AvailableStates[i] +
                                         " by signals: ");
                            foreach (var signal in signalList)
                            {
                                writer.Write(signal + " ");
                            }

                            writer.WriteLine();
                            i++;
                        }
                    }
                    else
                    {
                        writer.WriteLine("No Available States");
                        writer.WriteLine("No State Transition Signals");
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