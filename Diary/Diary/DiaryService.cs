using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class DiaryService
    {
        static readonly PriorityTask[] weeklyTasks = new PriorityTask[100];
        int taskNumber = 0;
        internal int RecodrTask()
        {
            Console.WriteLine("Entered task parametrs: ");
            var taskParametrs = AddTask();
            CheckParametrs(taskParametrs, taskNumber);
            taskNumber++;
            return taskNumber;
        }

        internal void ShowTasks()
        {
            Console.WriteLine("Your entries: ");
            for (int i = 0; i < taskNumber + 1; i++)
            {
                Console.WriteLine("task " + (i + 1) + ": "
                                   + weeklyTasks[i].Name
                                   + " "
                                   + weeklyTasks[i].TaskDate
                                   + " "
                                   + weeklyTasks[i].TaskTime
                                   + " "
                                   + weeklyTasks[i].Priority);
            }
        }

        internal void FiltrTask()
        {
            Console.Write("By date or by priority?");
            string filter = Console.ReadLine();

            switch (filtr.ToLower())
            {
                case "date":
                    FiltrToDate(taskNumber);
                    break;

                case "priority":
                    FiltrToPriority(taskNumber);
                    break;

                default:
                    Console.WriteLine("so something went wrong");
                    break;
            }
        }

        internal void ChangeParametrs()
        {
            int numberTaskChange = SelectNumberTask();
            Console.WriteLine("enter new parameters");
            var taskParametrs = AddTask();
            CheckParametrs(taskParametrs, numberTaskChange);
        }

        private static string[] AddTask()
        {
            {
                string text = Console.ReadLine();
                string[] words = text.Split(new char[] { ',' });
                return words;
            }
        }
        private static void CheckParametrs(string[] taskParametrs, int numberTask)
        {
            switch (taskParametrs.Length)
            {
                case 4:
                    Record4Parametrs(taskParametrs, numberTask);
                    break;

                case 3:
                    Records3Parametrs(taskParametrs, numberTask);
                    break;

                case 2:
                    Records2Parametrs(taskParametrs, numberTask);
                    break;

                case 1:
                    Records1Parametr(taskParametrs, numberTask);
                    break;

                default:
                    Console.WriteLine("incorrect parameter format");
                    break;
            }
        }

        private static void Records1Parametr(string[] taskParametrs, int numberTask)
        {
            PriorityTask diaryTask = new(taskParametrs[0]);
            weeklyTasks[numberTask] = diaryTask;
        }

        private static void Records2Parametrs(string[] taskParametrs, int numberTask)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                   (taskParametrs[1]));
            weeklyTasks[numberTask] = diaryTask;

        }

        private static void Records3Parametrs(string[] taskParametrs, int numberTask)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                      DateTime.Parse(taskParametrs[1]),
                                                      DateTime.Parse(taskParametrs[2]));
            weeklyTasks[numberTask] = diaryTask;
            diaryTask.GetAlarm();
        }

        private static void Record4Parametrs(string[] taskParametrs, int numberTask)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                                          DateTime.Parse(taskParametrs[1]),
                                                                          DateTime.Parse(taskParametrs[2]),
                                                                          taskParametrs[3]);
            weeklyTasks[numberTask] = diaryTask;
            diaryTask.GetAlarm();
        }

        private void FiltrToPriority(int numberTask)
        {
            Console.WriteLine("select priority");
            string filtr = Console.ReadLine();
            PriorityTask[] filtrTask = new PriorityTask[numberTask];
            var i = 0;
            var x = 0;

            do
            {
                if (weeklyTasks[i].Priority == filtr)
                {
                    filtrTask[x] = weeklyTasks[i];
                    x++;
                }
                i++;
            }
            while (i < numberTask);

            Console.WriteLine("tasks with the selected priority:");
            ShowFiltr(x, filtrTask);
        }
               
        private void FiltrToDate(int numberTask)
        {
            Console.WriteLine("select a date");
            string filtr = Console.ReadLine();
            PriorityTask[] filtrTask = new PriorityTask[numberTask];
            var i = 0;
            var x = 0;
            do
            {
                if (weeklyTasks[i].TaskDate == filtr)
                {
                    filtrTask[x] = weeklyTasks[i];
                    x++;
                }
                i++;
            }
            while (i < numberTask);
            Console.WriteLine("tasks with the selected data:");
            ShowFiltr(x, filtrTask);
        }
        private static void ShowFiltr(int x, PriorityTask[] filtrTask)
        {
            Console.WriteLine("Your entries: ");
            for (int i = 1; i < x + 1; i++)
            {
                Console.WriteLine("task " + i + ": "
                                   + filtrTask[x - 1].Name
                                   + " "
                                   + filtrTask[x - 1].TaskDate
                                   + " "
                                   + filtrTask[x - 1].TaskTime
                                   + " "
                                   + filtrTask[x - 1].Priority);
            }
        }

        private static int SelectNumberTask()
        {
            Console.Write("select the task number: ");
            var change = Console.ReadLine();
            var numberTaskChange = int.Parse(change) - 1;
            return numberTaskChange;
        }
    }
}
