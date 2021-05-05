using System;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        private static Bank<Account> _bank = new Bank<Account>();
        
        static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                Console.Clear();
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Open Account \t 2. Withdraw sum \t 3. Add sum");
                Console.WriteLine("4. Close Account \t 5. Skip day \t 6. Exit program");
                Console.WriteLine("Enter the item number:");
                Console.ForegroundColor = color;
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            OpenAccount();
                            break;
                        case 2:
                            ActionLocker();
                            break;
                        case 3:
                            Withdraw();
                            break;
                        case 4:
                            Put();
                            break;
                        case 5:
                            CloseAccount();
                            break;
                        case 6:
                            SkipDay();
                            break;
                        case 7:
                            alive = false;
                            continue;
                    }
                    Console.ReadKey();
                    // CalculatePercentage

                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }
        
        private static void OpenAccount()
        {
            Console.WriteLine("Specify the sum to create an account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Select an account type: \n 1. On-Demand \n 2. Deposit");
            var type = Enum.Parse<AccountType>(Console.ReadLine()!);
            
            _bank.OpenAccount(new OpenAccountParameters
            {
                Amount = sum,
                Type = type,
                AccountCreated = NotifyAccountCreated
            });
        }

       
        private static void Withdraw()
        {
            Console.WriteLine("Specify the sum to withdraw from the account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter account id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _bank.WithdrawAccaunt(new WithdrawAccountParametrs
            {
                Amount = sum,
                Id = id - 1,
                WithdrawAccount = NotifyAccountCreated,
            });
            // Withdraw;
        }

        private static void Put()
        {
            Console.WriteLine("Specify the sum to put on the account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter account id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _bank.PutAmount(new PutAccountParameters
            {
                Amount = sum,
                Id = id - 1,
                PutAccount = NotifyAccountCreated                
            });
            // Put
        }
        
        private static void CloseAccount()
        {
            Console.WriteLine("Enter the account id to close: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _bank.ClosedAccount(new ClosedAccountParameters
            {
                Id = id - 1,
                AccountCloser = NotifyAccountCreated
            });
            // Close
        }
        private static void ActionLocker()
        {
            Console.WriteLine("1.Open locker \t 2.Open locker with password on clear\t 3.Pick up locker\t 4. Pick up something\t 5. Secret action");
            int choice = Convert.ToInt32(Console.ReadLine());

            int id;
            string keyword;
            object data;
            string password;

            switch (choice)
            {
                case 1:
                    DefiningParametersActionLoker(out id, out keyword, out data);
                    _bank.AddLocker(id, keyword, data);
                    break;
                case 2:
                    DefiningParametersActionLoker(out id, out keyword, out data, out password);
                    _bank.AddLocker(id, keyword, data, password);
                    break;
                case 3:
                    DefiningParametersActionLoker(out id, out keyword);
                    _bank.GetLockerData(id, keyword);
                    break;
                case 4:
                    DefiningParametersActionLoker(out id, out keyword, out data);
                    // _bank.GetLockerData(id, keyword, data.GetType()); не понял как реализовать передачу вида 
                    break;
                case 5:
                    SecretAction();
                    break;
                default:
                    break;
            }
        }

        private static void SecretAction()
        {
            string phrase = Console.ReadLine();
            _bank.SecretAction(phrase);
        }

        private static void DefiningParametersActionLoker(out int id, out string keyword, out object data)
        {
            Console.WriteLine("Enter id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter keyword: ");
            keyword = Console.ReadLine();
            Console.WriteLine("Enter data: ");
            data = Console.ReadLine();
        }

        private static void DefiningParametersActionLoker(out int id, out string keyword, out object data, out string password)
        {
            Console.WriteLine("Enter id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter keyword: ");
            keyword = Console.ReadLine();
            Console.WriteLine("Enter data: ");
            data = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();
        }

        private static void DefiningParametersActionLoker(out int id, out string keyword)
        {
            Console.WriteLine("Enter id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter keyword: ");
            keyword = Console.ReadLine();
            Console.WriteLine("Enter data: ");
        }


        private static void SkipDay() => _bank.SkipDay();

        private static void NotifyAccountCreated(string message)
        {
            Console.WriteLine(message);
        }
    }
}
