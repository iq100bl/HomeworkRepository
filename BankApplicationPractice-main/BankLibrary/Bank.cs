using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankLibrary
{
    public class AccountsCollection : IEnumerable<Account> // я создал нужный мне метод, но так и не понял что делать с методами, которые требует интерфейс, кроме как оставить эксепшены
    {
        public static IEnumerator<Account> GetEnumerator(IEnumerable<Account> enumerable)
        {
            return enumerable.GetEnumerator();
        }

        public IEnumerator<Account> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Bank<T> where T : Account
    {
        private AccountsCollection _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            if (typeof(T) == typeof(DepositAccount))
            {
                if (parameters.Type == AccountType.OnDemand)
                {
                    throw new InvalidOperationException("Sorry, this is a credit bank, you cannot create an on demand account");
                }
                CreateAccount(parameters.AccountCreated, () => new DepositAccount(parameters.Amount) as T);
            }
            else
            {
                // TODO: check types compatibility
                CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit
                    ? new DepositAccount(parameters.Amount) as T
                    : new OnDemandAccount(parameters.Amount) as T);
            }
        }

        public void ClosedAccount(ClosedAccountParameters parameters)
        {
            ExecuteOnAccount(parameters.Id, acc => acc.Close());
        }

        public void PutAmount(PutAccountParameters parameters)
        {
            ExecuteOnAccount(parameters.Id, acc => acc.Put(parameters.Amount));
        }

        public void WithdrawAccaunt(WithdrawAccountParametrs parameters)
        {
            ExecuteOnAccount(parameters.Id, acc => acc.Withdraw(parameters.Amount));
        }

        public void SkipDay()
        {
            if (_accounts.Any() == false)
            {
                throw new InvalidOperationException("Sorry, our bank has nothing to work with yet");
            }
            CalculationPercent(_accounts);
            foreach(var item in _accounts)
            {
                item.Skip();
            }
        }

        private void AssertValidId(int Id)
        {
            if (Id < 0 || Id >= _accounts.Count())
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
        }

        private void ExecuteOnAccount(int accountId, Action<T> action)
        {
            AssertValidId(accountId);
            while (AccountsCollection.GetEnumerator(_accounts).Current.Id != accountId)
            {
                AccountsCollection.GetEnumerator(_accounts).MoveNext(); //если я правильно понял, то указатель должен остановиться
            }
            action(AccountsCollection.GetEnumerator(_accounts).Current as T); // и мне не нужно ни создавать экзкмпляр класса, а по указалетю, дожен верно выбрать элемент
            AccountsCollection.GetEnumerator(_accounts).Reset(); // мб и лишнее, но всё же лучше вернуть в начало указатель
            CalculationPercent(_accounts);
        }

        private void CreateAccount(AccountStatus accountStatus, Func<T> creator)
        {
            var account = creator();
            account.Created += accountStatus;
            account.OnAccountClosed += accountStatus;
            account.OnAmountAdded += accountStatus;
            account.WithdrawAccount += accountStatus;
            account.Open();
            _accounts = (AccountsCollection)_accounts.Append(account); // не работает. пробовал через concat, с созданием новой коллекции. тоже не сработало. короче не разобрался
        }

            // в моей реализации только депозит аккаунты получают проценты
        private void CalculationPercent(AccountsCollection accounts)
        {
            foreach(var item in accounts)
            {
                AccountsCollection.GetEnumerator(accounts.Where(acc => acc.Type == AccountType.Deposit && acc._state == AccountState.Opened)).Current.AccrualedAmount();
            }
            AccountsCollection.GetEnumerator(_accounts).Reset();
        }
    }
}
