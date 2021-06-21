namespace Demo
{
    public class Bank
    {
        public Bank(IAccountManager accountManager)
        {
            this.AccountManager = accountManager;
        }

        public IAccountManager AccountManager { get; set; }
    }
}
