using System;
using System.Collections.Generic;

namespace DFA2
{
    public class StateInfoClass
    {
        //имя состояния
        public int NameOfState { get; set; }
        //состояния, доступные из данного
        public List<int> AvailableStates { get; set; }
        //сигналы для перехода между состояниями
        public List<List<char>> StateTransitionSignals { get; set; }

        public StateInfoClass(int nameOfState)
        {
            NameOfState = nameOfState;
            AvailableStates = new List<int>();
            StateTransitionSignals = new List<List<char>>();
        }

        public StateInfoClass(int nameOfState, List<int> availableStates, List<List<char>> stateTransitionSignals)
        {
            NameOfState = nameOfState;
            AvailableStates = new List<int>();
            StateTransitionSignals = new List<List<char>>();
            foreach (var state in availableStates)
            {
                AvailableStates.Add(state);
            }
            foreach (var signalList in stateTransitionSignals)
            {
                List<char> signalListForAdding = new List<char>();
                foreach (var signal in signalList)
                {
                   signalListForAdding.Add(signal);
                }
                StateTransitionSignals.Add(signalListForAdding);
            }
        }

        
    }
}