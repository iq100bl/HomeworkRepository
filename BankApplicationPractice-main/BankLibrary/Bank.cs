using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<Account> _accounts = new();
        AccountAction accountAction;

        public void OpenAccount(OpenAccountParameters parameters)
        {
            // TODO: check types compatibility
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit 
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }
        public void ClosedAccount(ClosedAccountParameters parameters)
        {// в этом месте хотел создать метод, для повтроряющегося кода, но не знаю как передать
         //   "parametrs в метод
            if (parameters.Id < 0 || parameters.Id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
            var account = _accounts[parameters.Id];
            account.Close();
            _accounts.Insert(parameters.Id, account);
            //IdentificationAccount(action,account, parameters)
        }
       // private void IdentificationAccount( AccountAction action, Account account, parameters) этот метод
        public void PutAmount(PutAccountParameters parameters)
        {
            if (parameters.Id < 0 || parameters.Id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
            var account = _accounts[parameters.Id];
            account.Put(parameters.Amount);
            _accounts.Insert(parameters.Id, account);
        }
        public void WithdrawAccaunt(WithdrawAccountParametrs parameters)
        {
            var item = parameters.GetType();
            CheckedItems(item);
            if (parameters.Id < 0 || parameters.Id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
            var account = _accounts[parameters.Id];
            account.Withdraw(parameters.Amount);
            _accounts.Insert(parameters.Id, account);
        }
        public void CheckedItems(Type item)
        {
            switch (item)
            {
               // case WithdrawAccountParametrs:
                 //   break;
            }
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }
        private void CalculationPercent()
        {
            var percent =_accounts.FindAll(x => x == AccountState.Opened);
        }
    }
}
