using System;
using System.Collections.Generic;
using System.Linq;

namespace DFA
{
    public class DfaClass
    {
        //множество состояний
        public List<string> States { get; set; }
        //множество входных сигналов (алфавит)
        public List<string> Alphabet { get; set; }
        //функция переходов
        public Dictionary<char, List<string>> TransitionFunction { get; set; }
        //множество начальных состояний
        public List<string> StartStates { get; set; }
        //множество заключительных состояний
        public List<string> FinalStates { get; set; }
        
        public DfaClass(List<string> informationFromFile)
        {
            States = informationFromFile[0].Split(',').ToList();
            
            Alphabet = informationFromFile[1].Split(',').ToList();
            
            TransitionFunction = new Dictionary<char, List<string>>();
            List<string> transitionFunList = informationFromFile[2].Split(',').ToList();
            for (int i = 0; i < transitionFunList.Count - 2; i+=3)
            {
                if(!TransitionFunction.ContainsKey(char.Parse(transitionFunList[i])))
                {
                    List<string> addingList = new List<string>();
                    addingList.Add(transitionFunList[i + 1]);
                    addingList.Add(transitionFunList[i + 2]);
                    TransitionFunction.Add(char.Parse(transitionFunList[i]), addingList);
                }
                else
                {
                    TransitionFunction[char.Parse(transitionFunList[i])].Add(transitionFunList[i + 1]);
                    TransitionFunction[char.Parse(transitionFunList[i])].Add(transitionFunList[i + 2]);
                }
            }
            
            StartStates = informationFromFile[3].Split(',').ToList();
            
            FinalStates = informationFromFile[4].Split(',').ToList();
        }

        //проходит по выделенному из строки слову и определяет, допускается ли оно автоматом
        //startPosition - состояние автомата, из которого начинаем движение
        //subStr - выделенное слово
        private bool SubstringCheck(string subStr, bool isOutput, string startPosition = "s0")
        {
            //делим выделенное слово по буквам
            List<char> elemsOfSubStr = new List<char>();
            foreach (var elem in subStr)
            {
                elemsOfSubStr.Add(elem);
            }
            
            //если начальное состояние, переданное в функцию, не входит в число начальных 
            //состояний автомата, этот автомат не допускает это слова
            if (!StartStates.Contains(startPosition))
            {
                return false;
            }
            
            //зафиксированные состояния автомата при проходе по слову
            List<string> fixedStates = new List<string>();
            
            //добавляем начальное состояние в число зафиксированных
            fixedStates.Add(startPosition);
            for (int i = 0; i < elemsOfSubStr.Count; i++)
            {
                //находим индекс начального состояния в списке состояний функции перехода у конкретного элемента подстроки
                int indexOfAddingState = TransitionFunction[elemsOfSubStr[i]].IndexOf(startPosition);
                //если имеется функция перехода из начального состояния при получении такой буквы слова
                if ((indexOfAddingState >= 0) && (TransitionFunction[elemsOfSubStr[i]][indexOfAddingState] == startPosition))
                {
                    //добавляем состояние, в которое при этом переходит автомат, в число зафиксированных состояний
                    fixedStates.Add(TransitionFunction[elemsOfSubStr[i]][indexOfAddingState + 1]);
                    //меняем начально состояние на то, в котором сейчас находимся
                    startPosition = TransitionFunction[elemsOfSubStr[i]][indexOfAddingState + 1];
                }
                else
                {
                    return false;
                }
            }

            //если последнее состояние, в котором оказался автомат после прохода по слову, не входит в число конечных 
            //состояний автомата, этот автомат не допускает это слова
            if (!FinalStates.Contains(fixedStates[fixedStates.Count - 1]))
            {
                return false;
            }
            
            if (isOutput)
            {
                WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
                workWithConsoleClass.ConsoleOutput(subStr, fixedStates);
            }
            
            return true;
        }

        Dictionary<int, string> _maxSubstrings = new Dictionary<int, string>();
        private int _idForAddingSubstrings = 0;
        
        private void FindWords(string inputWord)
        {
            if (inputWord.Length > 1)
            {
                for (int i = 1; i <= inputWord.Length; i++)
                {
                    if (SubstringCheck(inputWord.Substring(0, i), false))
                    {
                        if (!_maxSubstrings.ContainsKey(_idForAddingSubstrings))
                        {
                            _maxSubstrings.Add(_idForAddingSubstrings, inputWord.Substring(0, i));
                        }
                        else
                        {
                            _maxSubstrings[_idForAddingSubstrings] = inputWord.Substring(0, i);
                        }
                    }
                    else
                    {
                        _idForAddingSubstrings++;
                        FindWords(inputWord.Substring(i, inputWord.Length - i));
                    }
                }
            }
            else
            {
                SubstringCheck(inputWord, false);
            }

        }

        public void OutputMax(string inputWord)
        {
            FindWords(inputWord);
            foreach (var elem in _maxSubstrings)
            {
                SubstringCheck(elem.Value, true);
            }
        }
    }
}