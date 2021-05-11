using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<T> _accounts = new();

        public void AddLocker(int id, string keyword, object data)
        {
            var locker = new Locker(id, keyword);
            AddLockerToDictionary(data, locker);
        }

        public void AddLocker(int id, string keyword, object data, string passwordOfCleanData)
        {
            var locker = new Locker(id, keyword, passwordOfCleanData);
            AddLockerToDictionary(data, locker);
        }
        public void SecretAction(string phrase)
        {
            if(phrase == KgkPassPhrase)
            {
                VisitKgk(phrase);
            }
            else
            {
                DoCleaningData(phrase);
            }
        }


        public object GetLockerData(int id, string keyword)
        {
            var Key = new Locker(id, keyword);
            if (_lockers.ContainsKey(Key))
            {
                return _lockers[Key];
            }

            throw new InvalidOperationException($"Cannot find locker with ID or keyword does not match");
        }

        public TU GetLockerData<TU>(int id, string keyword, Type view)
        {
            return (TU)GetLockerData(id, keyword);
        }

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

        private void AddLockerToDictionary(object data, Locker locker)
        {
            _lockers.Add(locker, data);
        }

        private void VisitKgk(string passPhrase)             // да да. подсмотрено. но уже посмотрев, не на нашёл уже способ, реализовать проще
        {
            foreach (Locker key in _lockers.Keys)
            {
                _lockers[key] = null;
            }
        }

        private void DoCleaningData(string passwordOfCleanData)
        {
            foreach (KeyValuePair<Locker, object> locker in _lockers)
            {
                if (locker.Equals(passwordOfCleanData))
                {
                    _lockers[locker.Key] = null;
                }
            }
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
