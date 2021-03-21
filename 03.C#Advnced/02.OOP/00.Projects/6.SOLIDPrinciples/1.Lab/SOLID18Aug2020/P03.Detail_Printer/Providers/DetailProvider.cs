namespace P03.Detail_Printer.Providers
{
    using System.Linq;
    using System.Collections.Generic;

    using Rulers;
    using Contracts;

    public class DetailProvider : IDetailProvider
    {
        private readonly ICollection<IDetailRuler> detailRulers;

        public DetailProvider()
        {
            this.detailRulers = new List<IDetailRuler>()
            {
                new EmployeeRuler(),
                new ManagerRuler()
            };
        }

        public string ProvideDetailInfo(IEmoloyee emoloyee)
        {
            return this.detailRulers
                .First(d => d.IsMatch(emoloyee))
                .GetInformation(emoloyee);
        }
    }
}
