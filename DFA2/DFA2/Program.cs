﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DFA2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TasksClass tasksClass = new TasksClass();
            //tasksClass.FirstTask(); // +25-+7.8+ee9e5-7+4e8+39e4
            tasksClass.SecondTask();
            /*WorkWithFileClass workWithFileClass = new WorkWithFileClass();

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
                    Console.WriteLine("The symbol " + str[k] + " does not belong to any class of tokens");
                    k++;
                }
            }*/


        }
    }
}