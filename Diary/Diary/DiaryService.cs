using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class DiaryService
    {
        private static readonly WeeklyTask[] weeklyTasks = new WeeklyTask[100];
        private int taskNumber;
        internal delegate void TaskPrint();
        public delegate void UpdateTask(int numberTaskChange);
        delegate string ReadInput();

        private ReadInput readingInfo = ConsoleReadWrite.ReadingInfo;
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
            for (int i = 0; i < taskNumber; i++)
            {
                Console.WriteLine(weeklyTasks[i].TaskTostring(i));
            }
        }

        internal void FiltrTask()
        {
            Console.Write("By date or by priority?");
            string filter = readingInfo();

            switch (filter.ToLower())
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
            Console.WriteLine("enter new parameters");
            var taskParametrs = AddTask();
            int numberTaskChange = SelectNumberTask();
            CheckParametrs(taskParametrs, numberTaskChange);
            UpdateTask update = ConsoleReadWrite.PrintNumberUpdateTask;
            update(numberTaskChange);
        }

        private static string[] AddTask()
        {
            {
                // Я не могу в этом месте использовать метод через делегат, его не видно
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
            RegularTask diaryTask = new(taskParametrs[0]);
            weeklyTasks[numberTask] = diaryTask;
        }

        private static void Records2Parametrs(string[] taskParametrs, int numberTask)
        {
            PriorityTask diaryTask = new(taskParametrs[0],
                                                   taskParametrs[1]);
            weeklyTasks[numberTask] = diaryTask;

        }

        private static void Records3Parametrs(string[] taskParametrs, int numberTask)
        {
            RegularTask diaryTask = new(taskParametrs[0],
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
            string filtr = readingInfo();
            var filtrTask = new WeeklyTask[numberTask];
            var i = 0;
            var x = 0;

            do
            {
                if (weeklyTasks[i] is PriorityTask priorityTask && ((IPriorityTask)priorityTask).GetPriority() == filtr)
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
            string filtr = readingInfo();
            var filtrTask = new WeeklyTask[numberTask];
            var i = 0;
            var x = 0;
            do
            {
                if (weeklyTasks[i] is RegularTask regularTask && ((IRegularTask)regularTask).GetDate() >= DateTime.Parse(filtr))
                {
                    filtrTask[x] = weeklyTasks[i];
                    x++;
                }
                i++ ;
            }
            while (i < numberTask);
            Console.WriteLine("tasks with the selected data:");
            ShowFiltr(x, filtrTask);
        }
        private static void ShowFiltr(int x, WeeklyTask[] filtrTask)
        {
            for (int i = 0; i < x; i++)
            {
                // filterTask является строковым массивом, я не нашёл как обратиться через интерфейс
                Console.WriteLine(filtrTask[i].TaskTostring(i));
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
