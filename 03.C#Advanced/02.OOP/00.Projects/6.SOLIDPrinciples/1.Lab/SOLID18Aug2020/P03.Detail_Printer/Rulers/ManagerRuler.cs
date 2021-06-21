namespace P03.Detail_Printer.Rulers
{
    using System;
    using System.Text;

    using Contracts;
    using P03.DetailPrinter;

    public class ManagerRuler : IDetailRuler
    {
        public string GetInformation(IEmoloyee emoloyee)
        {
            var manager = emoloyee as Manager;

            var sb = new StringBuilder();

            sb
                .AppendLine(manager.Name)
                .AppendLine(string.Join(Environment.NewLine, manager.Documents));

            return sb.ToString().TrimEnd();
        }

        public bool IsMatch(IEmoloyee emoloyee)
        {
            return emoloyee is Manager;
        }
    }
}
