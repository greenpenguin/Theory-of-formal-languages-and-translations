using System;
using System.Collections.Generic;
using System.Linq;

namespace DFA2
{
    public class DfaClass
    {
        //множество состояний
        public List<StateInfoClass> States { get; set; }
        //множество входных сигналов (алфавит)
        //public List<char> Alphabet { get; set; }
        //функция переходов
        //public Dictionary<char, List<string>> TransitionFunction { get; set; }
        //public Dictionary<string, List<string>> TransitionFunction { get; set; }
        //множество начальных состояний
        public List<int> StartStates { get; set; }
        //множество заключительных состояний
        public List<int> FinalStates { get; set; }
        
        public DfaClass(List<string> informationFromFile)
        {
            States = new List<StateInfoClass>();
            foreach (var elem in informationFromFile)
            {
                List<string> stateInformation = elem.Split('|').ToList();
                if (stateInformation[0] == "start")
                {
                    
                    StartStates = new List<int>();
                    List<string> startStatesString = stateInformation[1].Split(' ').ToList();
                    foreach (var state in startStatesString)
                    {
                        StartStates.Add(int.Parse(state));
                    }
                }
                else if (stateInformation[0] == "final")
                {
                    FinalStates = new List<int>();
                    List<string> finalStatesString = stateInformation[1].Split(' ').ToList();
                    foreach (var state in finalStatesString)
                    {
                        FinalStates.Add(int.Parse(state));
                    }
                }
                else
                {
                    
                    int stateName = int.Parse(stateInformation[0]);

                    List<string> availableStatesString = stateInformation[1].Split(' ').ToList();
                    List<int> availableStatesInt = new List<int>();
                    foreach (var state in availableStatesString)
                    {
                        availableStatesInt.Add(int.Parse(state));
                    }

                    List<List<char>> stateTransitionSignals = new List<List<char>>();
                    for (int i = 2; i <= availableStatesInt.Count + 1; i++)
                    {
                        List<string> separatedStringOfSignals = stateInformation[i].Split(' ').ToList();
                        List<char> listForAddingSignals = new List<char>();
                        foreach (var signal in separatedStringOfSignals)
                        {
                            listForAddingSignals.Add(char.Parse(signal));
                        }

                        stateTransitionSignals.Add(listForAddingSignals);
                    }

                    StateInfoClass newState = new StateInfoClass(stateName, availableStatesInt, stateTransitionSignals); 
                    States.Add(newState);
                    
                }

            }
            
        }
        
        public KeyValuePair<bool, int> MaxString(string str, int pos)
        {
            KeyValuePair<bool, int> MaxStr = new KeyValuePair<bool, int>();
            int m = 0;
            bool res = false;
            int curState = TakeNewStartState(str[pos]);
            
            if (FinalStates.Contains(curState))
            {
                res = true;
            }
            int i = pos;
            while (i < str.Length)
            {
                if (IsStateTransitionSignalsContainsSignal(curState, str[i]))
                {
                    foreach (var state in States)
                    {
                        if (state.NameOfState == curState)
                        {
                            int newState = 0;
                            foreach (var list in state.StateTransitionSignals)
                            {
                                foreach (var elem in list)
                                {
                                    if (elem == str[i])
                                    {
                                        curState = state.AvailableStates[newState];
                                    }
                                }
                                newState++;
                            }
                        }
                    }

                    if (FinalStates.Contains(curState))
                    {
                        m = i - pos + 1;
                        res = true;
                        MaxStr = new KeyValuePair<bool, int>(res, m);
                    }

                    i++;
                }
                else
                {
                    return MaxStr;
                }
            }
            return MaxStr;
        }

        private bool IsStateTransitionSignalsContainsSignal(int stateName, char signal)
        {
            foreach (var state in States)
            {
                if (state.NameOfState == stateName)
                {
                    foreach (var list in state.StateTransitionSignals)
                    {
                        foreach (var elem in list)
                        {
                            if (elem == signal)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private int TakeNewStartState(char signal)
        {
            foreach (var startState in StartStates)
            {
                foreach (var state in States)
                {
                    if (state.NameOfState == startState)
                    {
                        foreach (var list in state.StateTransitionSignals)
                        {
                            foreach (var elem in list)
                            {
                                if (elem == signal)
                                {
                                    return startState;
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }
                
    }
}