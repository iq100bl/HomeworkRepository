namespace BankLibrary
{
    public class WithdrawAccountParametrs
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AccountStatus WithdrawAccount { get; set; }
    }
}
