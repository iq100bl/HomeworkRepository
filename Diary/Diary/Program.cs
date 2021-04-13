using System;
enum Priority : int
{
    Low = 1,
    Medium = 2,
    Hight =3,
}

namespace Diary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberTask = 0;
            WeeklyTask[] weeklyTasks = new WeeklyTask[100];
            while (true)
            {
                Console.Write("Enter action: ");
                var text = Console.ReadLine();

                switch (text.ToLower())
                {
                    case "task":
                        Console.WriteLine("Entered task parametrs: ");
                        var taskParametrs = AddTask();
                        CheckParametrs(taskParametrs, numberTask, weeklyTasks);
                        numberTask++;
                        
                        break;
                    case "show":
                        Console.WriteLine("Your entries: ");

                        for (int i = 0; i < numberTask; i++)
                        {
                            Console.WriteLine(weeklyTasks[i].name
                                              + " "
                                              + weeklyTasks[i].dataTask.ToShortDateString() // кривой показ даты и время.
                                              + " "
                                              + weeklyTasks[i].timeTask.ToLongTimeString()  //я хз каким способом их нормально показать
                                              + " "
                                              + weeklyTasks[i].priority);
                        }
                        break;

                }
            }
        }
        public static string[] AddTask()
        {
            {
                string text = Console.ReadLine();
                string[] words = text.Split(new char[] { ',' });
                return words;
            }
        }
        private static void CheckParametrs(string[] taskParametrs, int numberTask, WeeklyTask[] weeklyTasks)
        {
            switch (taskParametrs.Length)
            {
                case 4:
                    WeeklyTask diaryTask4 = new WeeklyTask(taskParametrs[0],
                                                              DateTime.Parse(taskParametrs[1]),
                                                              DateTime.Parse(taskParametrs[2]),
                                                              (taskParametrs[3]));
                    weeklyTasks[numberTask] = diaryTask4;
                    break;

                case 3:
                    WeeklyTask diaryTask3 = new WeeklyTask(taskParametrs[0],
                                                              DateTime.Parse(taskParametrs[1]),
                                                              DateTime.Parse(taskParametrs[2]));
                    weeklyTasks[numberTask] = diaryTask3;
                    break;
                case 2:
                    WeeklyTask diaryTask2 = new WeeklyTask(taskParametrs[0],
                                                           (taskParametrs[1]));
                    weeklyTasks[numberTask] = diaryTask2;
                    break;
                case 1:
                    WeeklyTask diaryTask1 = new WeeklyTask(taskParametrs[0]);
                    weeklyTasks[numberTask] = diaryTask1;
                    break;
                default:
                    Console.WriteLine("incorrect parameter format");
                    break;
            }
        }     
       
        public class WeeklyTask
        {
            public string name;
            public DateTime dataTask;
            public DateTime timeTask;
            public string priority;
            private static int counter = 0; // на будущее
            public WeeklyTask(string n, DateTime d, DateTime t, string p)
            {
                name = n;
                dataTask = d;
                timeTask = t;
                priority = p;
                counter++;
            }
            public WeeklyTask(string n, DateTime d, DateTime t)
            {
                name = n;
                dataTask = d;
                timeTask = t;
                priority = "low";
                counter++;
            }
            public WeeklyTask(string n, string p)
            {
                name = n;
                priority = p;
                dataTask = DateTime.Now;
                timeTask = DateTime.Now;
                counter++;
            }
            public WeeklyTask(string n)
            {
                name = n; 
                dataTask = DateTime.Now;
                timeTask = DateTime.Now;
                priority = "low";
                counter++;
            }         
        }
    }
}

