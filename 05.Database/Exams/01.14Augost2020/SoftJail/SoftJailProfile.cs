namespace SoftJail
{
    using System;
    using System.Globalization;
    using System.Linq;

    using AutoMapper;

    using Data.Models;
    using DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<Prisoner, PrisonerByCellDto>()
                .ForMember(x => x.PrisonerOfficers, opt =>
                    opt.MapFrom(y => y.PrisonerOfficers.OrderBy(x => x.Officer.FullName)))
                .ForMember(x => x.TotalOfficerSalary, opt =>
                    opt.MapFrom(y => decimal.Parse(y.PrisonerOfficers.Sum(z => z.Officer.Salary).ToString("F2"))))
                .ForMember(x => x.CellNumber, opt =>
                    opt.MapFrom(y => y.Cell.CellNumber));

            this.CreateMap<Prisoner, PrisonerMessagesDto>()
                .ForMember(x => x.IncarcerationDate, opt =>
                    opt.MapFrom(y => y.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)))
                .ForMember(x => x.EncryptedMessages, opt =>
                    opt.MapFrom(y => y.Mails
                        .Select(x => new MessageDto
                        {
                            Description = string.Join("", x.Description.Reverse())
                        })));
        }
    }
}
