namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;
    using SoftJail.XmlHelper;

    using Newtonsoft.Json;
    using AutoMapper.QueryableExtensions;

    using Data;
    using ImportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .ProjectTo<PrisonerByCellDto>()
                .OrderBy(x => x.FullName)
                .ToArray();

            var jsonOutput = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonerNamesCheck = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var prisoners = context.Prisoners
                .Where(x => prisonerNamesCheck.Contains(x.FullName))
                .ProjectTo<PrisonerMessagesDto>()
                .OrderBy(x => x.FullName)
                .ThenBy(x => x.Id)
                .ToArray();

            var output = XmlConvert.Serialize("Prisoners", prisoners);

            return output;
        }
    }
}