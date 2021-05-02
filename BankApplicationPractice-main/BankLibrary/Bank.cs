using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<T> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            if (typeof(T) == typeof(DepositAccount))
            {
                if(parameters.Type == AccountType.OnDemand)
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

        public void SkipDay(SkipDayAccountParameters parametrs)
        {
            if (_accounts.Count < 0)
            {
                throw new InvalidOperationException("Sorry, our bank has nothing to work with yet");
            }
            CalculationPercent(_accounts);
            var acc = _accounts[0];
            acc.Skip();            
        }

        private void AssertValidId(int Id)
        {
            if (Id < 0 || Id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
        }

        private void ExecuteOnAccount(int accountId, Action<T> action)
        {
            AssertValidId(accountId);
            var account = _accounts[accountId];
            action(account);
            _accounts.RemoveAt(accountId);
            _accounts.Insert(accountId, account);
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
            _accounts.Add(account);
        }

        // я искал как добавить к ForEach параметры поисканужного элемнта
        // при этом не использовать if, чисто методами "листа" но получилалось более громоздко
        private void CalculationPercent(List<T> accounts)
        {
            accounts.ForEach(x => PernissionToCredit(x));
        }

        private void PernissionToCredit(T credit)
        {
            if (credit.Type == AccountType.Deposit && credit._state == AccountState.Opened)
            {
                credit.AccrualedAmount();
            }
        }

    }
}
