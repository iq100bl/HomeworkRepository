using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<Account> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            // TODO: check types compatibility
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit 
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }
        public void ClosedAccount(ClosedAccountParameters parameters)
        {
            if(parameters.Id < 0 || parameters.Id >= _accounts.Count)
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
            Account account = _accounts[parameters.Id];
            account.Close();

            _accounts.Insert(parameters.Id, account);
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }
    }
}
