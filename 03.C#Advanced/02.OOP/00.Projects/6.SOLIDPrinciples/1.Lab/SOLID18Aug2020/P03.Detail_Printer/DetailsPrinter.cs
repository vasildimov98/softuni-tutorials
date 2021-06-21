namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;

    using P03.Detail_Printer.Contracts;

    public class DetailsPrinter
    {
        private readonly IList<IEmoloyee> employees;
        private readonly IDetailProvider detailProvider;

        public DetailsPrinter(IList<IEmoloyee> employees, 
            IDetailProvider detailProvider)
        {
            this.employees = employees;
            this.detailProvider = detailProvider;
        }

        public void PrintDetails()
        {
            foreach (var employee in this.employees)
            {
                Console.WriteLine(this.detailProvider.ProvideDetailInfo(employee));
            }
        }
    }
}
