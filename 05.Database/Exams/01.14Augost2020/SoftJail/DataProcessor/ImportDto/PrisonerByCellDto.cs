namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;

    public class PrisonerByCellDto
    {
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string FullName { get; set; }

        public int CellNumber { get; set; }

        [JsonProperty("Officers")]
        public OfficerDto[] PrisonerOfficers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }

    public class OfficerDto
    {
        [JsonProperty("OfficerName")]
        public string OfficerFullName { get; set; }

        [JsonProperty("Department")]
        public string OfficerDepartmentName { get; set; }
    }

}
