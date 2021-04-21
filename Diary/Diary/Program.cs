using System;
namespace Diary
{
     class Program
    {
        private static readonly DiaryService service = new();        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter action: ");
                string text = Console.ReadLine();

                switch (text.ToLower())
                {
                    case "task":
                        service.RecodrTask();
                        break;
                    case "show":
                        service.ShowTasks();
                        break;
                    case "filtr":
                         service.FiltrTask();
                        break;
                    case "change":
                        service.ChangeParametrs();
                        break;
                }
            }
        }        
    }
}

