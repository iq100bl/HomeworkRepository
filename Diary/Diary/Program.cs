using System;
namespace Diary
{
     class Program
    {
        private static readonly DiaryService service = new();
        static void Main(string[] args)
        {
            
            var numberTask = 0;
            PriorityTask[] weeklyTasks = new PriorityTask[100];
            while (true)
            {
                Console.Write("Enter action: ");
                var text = Console.ReadLine();

                switch (text.ToLower())
                {
                    case "task":
                        numberTask = service.RecodrTask(numberTask, weeklyTasks);
                        break;
                    case "show":
                        service.ShowTasks(numberTask, weeklyTasks);
                        break;
                    case "filtr":
                         service.FiltrTask(numberTask, weeklyTasks);
                        break;
                    case "change":
                        service.ChangeParametrs(weeklyTasks);
                        break;
                }
            }
        }        
    }
}

