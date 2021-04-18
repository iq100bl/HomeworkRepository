using System;
namespace Diary
{
     class Program
    {
        private static readonly DiaryService service = new();
        static void Main(string[] args)
        {
            var numberTask = 0;
            while (true)
            {
                Console.Write("Enter action: ");
                var text = Console.ReadLine();

                switch (text.ToLower())
                {
                    case "task":
                        numberTask = DiaryService.RecodrTask(numberTask);
                        break;
                    case "show":
                        service.ShowTasks(numberTask);
                        break;
                    case "filtr":
                         service.FiltrTask(numberTask);
                        break;
                    case "change":
                        service.ChangeParametrs();
                        break;
                }
            }
        }        
    }
}

