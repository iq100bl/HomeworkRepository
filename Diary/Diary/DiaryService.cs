using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class DiaryService
    {
        internal int RecodrTask(int numberTask, PriorityTask[] weeklyTasks)
        {
            Console.WriteLine("Entered task parametrs: ");
            var taskParametrs = AddTask();
            CheckParametrs(taskParametrs, numberTask, weeklyTasks);
            numberTask++;
            return numberTask;
        }
        private static string[] AddTask()
        {
            {
                string text = Console.ReadLine();
                string[] words = text.Split(new char[] { ',' });
                return words;
            }
        }
        private static void CheckParametrs(string[] taskParametrs, int numberTask, PriorityTask[] weeklyTasks)
        {
            switch (taskParametrs.Length)
            {
                case 4:
                    Record4Parametrs(taskParametrs, numberTask, weeklyTasks);
                    break;

                case 3:
                    Records3Parametrs(taskParametrs, numberTask, weeklyTasks);
                    break;

                case 2:
                    Records2Parametrs(taskParametrs, numberTask, weeklyTasks);
                    break;

                case 1:
                    Records1Parametr(taskParametrs, numberTask, weeklyTasks);
                    break;

                default:
                    Console.WriteLine("incorrect parameter format");
                    break;
            }
        }

        private static void Records1Parametr(string[] taskParametrs, int numberTask, PriorityTask[] weeklyTasks)
        {
            PriorityTask diaryTask = new(taskParametrs[0]);
            weeklyTasks[numberTask] = diaryTask;
        }

        private static void Records2Parametrs(string[] taskParametrs, int numberTask, PriorityTask[] weeklyTasks)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                   (taskParametrs[1]));
            weeklyTasks[numberTask] = diaryTask;

        }

        private static void Records3Parametrs(string[] taskParametrs, int numberTask, PriorityTask[] weeklyTasks)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                      DateTime.Parse(taskParametrs[1]),
                                                      DateTime.Parse(taskParametrs[2]));
            weeklyTasks[numberTask] = diaryTask;
            diaryTask.GetAlarm();
        }

        private static void Record4Parametrs(string[] taskParametrs, int numberTask, PriorityTask[] weeklyTasks)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                                          DateTime.Parse(taskParametrs[1]),
                                                                          DateTime.Parse(taskParametrs[2]),
                                                                          taskParametrs[3]);
            weeklyTasks[numberTask] = diaryTask;
            diaryTask.GetAlarm();
        }

        internal void ShowTasks(int numberTask, PriorityTask[] weeklyTasks)
        {
            Console.WriteLine("Your entries: ");
            for (int i = 1; i < numberTask + 1; i++)
            {
                Console.WriteLine("task " + i + ": "
                                   + weeklyTasks[i - 1].name
                                   + " "
                                   + CheckData(weeklyTasks, i)
                                   + " "
                                   + CheckTime(weeklyTasks, i)
                                   + " "
                                   + weeklyTasks[i - 1].priority);
            }
        }

        private static string CheckTime(PriorityTask[] weeklyTasks, int i)
        {
            if (weeklyTasks[i - 1].timeTask == default(DateTime))
            {
                return " ";
            }
            return weeklyTasks[i - 1].timeTask.ToLongTimeString();
        }

        private static string CheckData(PriorityTask[] weeklyTasks, int i)
        {
            if (weeklyTasks[i - 1].dataTask == default(DateTime))
            {
                return " ";
            }
            return weeklyTasks[i - 1].dataTask.ToShortDateString();
        }

        internal void FiltrTask(int numberTask, PriorityTask[] weeklyTasks)
        {
            Console.Write("By date or by priority?");
            string filtr = Console.ReadLine();

            switch (filtr.ToLower())
            {
                case "date":
                    FiltrToDate(weeklyTasks, numberTask);
                    break;

                case "prioryity":
                    FiltrToPriority(weeklyTasks, numberTask);
                    break;

                default:
                    Console.WriteLine("so something went wrong");
                    break;
            }
        }

        private void FiltrToPriority(PriorityTask[] weeklyTasks, int numberTask)
        {
            Console.WriteLine("select priority");
            string filtr = Console.ReadLine();
            PriorityTask[] filtrTask = new PriorityTask[numberTask];
            var i = 0;
            var x = 0;

            do
            {
                if (weeklyTasks[i].priority == filtr)
                {
                    filtrTask[x] = weeklyTasks[i];
                    x++;
                }
                i++;
            }
            while (i < numberTask);

            Console.WriteLine("tasks with the selected priority:");
            ShowTasks(x, filtrTask);
        }

        private void FiltrToDate(PriorityTask[] weeklyTasks, int numberTask) // я знаю код повторяется, но у меня не получается вытянуть из weeklyTasks[i].dataTask параметр для метода
        {
            Console.WriteLine("select a date");
            string filtr = Console.ReadLine();
            PriorityTask[] filtrTask = new PriorityTask[numberTask];
            var i = 0;
            var x = 0;
            do
            {
                if (weeklyTasks[i].dataTask == DateTime.Parse(filtr))
                {
                    filtrTask[x] = weeklyTasks[i];
                    x++;
                }
                i++;
            }
            while (i < numberTask);
            Console.WriteLine("tasks with the selected data:");
            ShowTasks(x, filtrTask);
        }

        internal void ChangeParametrs(PriorityTask[] weeklyTasks)
        {
            int numberTaskChange = SelectNumberTask();
            Console.WriteLine("enter new parameters");
            var taskParametrs = AddTask();
            CheckParametrs(taskParametrs, numberTaskChange, weeklyTasks);
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
