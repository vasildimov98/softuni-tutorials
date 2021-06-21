namespace P02._Identity_Before.Contracts
{
    public interface IAccountManager
    {
        void ChangePassword(string oldPass, string newPass);
    }
}
