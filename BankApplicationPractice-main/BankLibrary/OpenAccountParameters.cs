﻿namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }
        
        public decimal Amount { get; set; }

        public AccountStatus AccountCreated { get; set; }
    }
}
