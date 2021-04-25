namespace BankLibrary
{
    public class PutAccountParameters
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }

        public AccountStatus PutAccount { get; set; }
    }
}
