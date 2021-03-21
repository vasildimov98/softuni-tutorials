namespace P03.Detail_Printer.Rulers
{
    using Contracts;
    using P03.DetailPrinter;

    public class EmployeeRuler : IDetailRuler
    {
        public string GetInformation(IEmoloyee emoloyee)
        {
            return emoloyee.Name;
        }

        public bool IsMatch(IEmoloyee emoloyee)
        {
            return emoloyee is Employee;
        }
    }
}
