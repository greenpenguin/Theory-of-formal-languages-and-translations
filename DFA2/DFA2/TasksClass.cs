using System;
using System.Collections.Generic;
using System.IO;

namespace DFA2
{
    public class TasksClass
    {
        public void FirstTask()
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();
            WorkWithConsoleClass workWithConsoleClass = new WorkWithConsoleClass();
            
            string realInputFileName = Directory.GetCurrentDirectory() + "/input.txt";
            DfaClass dfaClass = new DfaClass(workWithFileClass.ReadDfaInformationFromFile(realInputFileName));
            
            workWithFileClass.PrintDfaToFile(dfaClass);
                
            string str = workWithConsoleClass.FirstTaskConsoleInput();
            
            int k = 0;
            while (k < str.Length)
            {
                var maxRes = dfaClass.MaxString(str, k);
                if (maxRes.Key == true)
                {
                    workWithConsoleClass.FirstTaskConsoleOutput(str.Substring(k, maxRes.Value));
                    k += Math.Max(maxRes.Value, 1);
                }
                else
                {
                    k++;
                }
            }
        }

        public void SecondTask()
        {
            WorkWithFileClass workWithFileClass = new WorkWithFileClass();

            string[] inputFileNames = {"/kw_input.txt", "/op_eq_input.txt", "/op_input.txt", "/id_input.txt",
            "/opening_bracket_input.txt", "/closing_bracket_input.txt", "/semicolon_input.txt", "/ws_input.txt",
                "/input.txt", "/int_input.txt", "/str_input.txt", "/com_input.txt"};
            var dfaList = new List<DfaClass>();

            foreach (var elem in inputFileNames)
            {
                dfaList.Add(new DfaClass(workWithFileClass.ReadDfaInformationFromFile(Directory.GetCurrentDirectory() + elem)));
            }
            
            string secondTaskInputStrFileName = Directory.GetCurrentDirectory() + "/second_task_input.txt";
            
            string secondTaskOutputStrFileName = Directory.GetCurrentDirectory() + "/second_task_output.txt";
            workWithFileClass.MakeFileEmpty(secondTaskOutputStrFileName);
            
            string str = workWithFileClass.ReadFileForSecondTask(secondTaskInputStrFileName);
            
            int k = 0; // текущая позиция в строке
            while (k < str.Length)
            {
                //curLex??
                int curPriority = 0; // текущий приоритет автомата
                int maxTokenLength = 0; // текущая максимальная длина токена с данной позиции
                foreach (var elem in dfaList) // идем по всем автоматам
                {
                    var maxRes = elem.MaxString(str, k); // находим максимальный токен в данной позиции
                    if (maxRes.Key)
                    {
                        if (maxTokenLength < maxRes.Value) // если длина найденного токена больше зафиксированной ранее
                        {
                            //curLex = elem.Lex
                            curPriority = elem.Priority; // обновляем приорит на приоритет автомата, с которым нашли такой токен
                            maxTokenLength = maxRes.Value; // обновляем значение макисмальной длины
                        }
                        else if ((maxTokenLength == maxRes.Value) && (curPriority < elem.Priority))
                            // если найден токен уже зафиксированной длины, рассматриваем приоритет
                        // если приоритет автомата, с которым нашли данный токен, больше ранее зафиксированного
                        {
                            //curLex = elem.Lex
                            curPriority = elem.Priority; // обновляем значение приоритета
                        }
                    }
                }

                if (maxTokenLength > 0) // если найден какой-то токен
                {
                    workWithFileClass.SecondTaskFileOutput(TakeDfaNameByPriority(curPriority, dfaList), str.Substring(k, maxTokenLength), 
                        secondTaskOutputStrFileName);
                    k += Math.Max(maxTokenLength, 1); // переходим на позицию в строке уже после найденного токена
                }
                else if (maxTokenLength == 0)
                {
                    // иначе данный символ не подходит ни одному автомату, берем следующий
                    //Console.WriteLine("The symbol " + str[k] + " does not belong to any class of tokens");
                    k++;
                }
            }
        }
        
        private string TakeDfaNameByPriority(int priority, List<DfaClass> dfaList)
        {
            string result = String.Empty;
            foreach (var elem in dfaList)
            {
                if (elem.Priority == priority)
                {
                    result = elem.Name;
                }
            }
            return result;
        }
    }
}