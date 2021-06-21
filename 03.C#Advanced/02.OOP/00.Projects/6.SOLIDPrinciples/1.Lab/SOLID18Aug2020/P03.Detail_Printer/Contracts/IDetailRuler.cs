namespace P03.Detail_Printer.Contracts
{
    public interface IDetailRuler
    {
        bool IsMatch(IEmoloyee emoloyee);

        string GetInformation(IEmoloyee emoloyee);
    }
}
